// ---------------------------------------------------------------------------------
//                Copyright 2021 Induxsoft Data Services S de RL de CV
//                
//        Induxsoft is a trademark of Induxsoft Data Services S de RL de CV               
//                             https://induxsoft.net/
//                             
//         Licensed under the Apache License, Version 2.0 (the "License")
//         YOU MAY NOT USE THIS FILE EXCEPT IN COMPLIANCE WITH THE LICENSE.
//                       You may obtain a copy of the License at 
//                    http://www.apache.org/licenses/LICENSE-2.0
//
// ---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace capturaGranel
{
    public class ProductInfo
    {
        public string codigo { get; set; }

        public string descripcion { get; set; }

        public decimal precio { get; set; }

        public decimal cantidad { get; set; }

        public string unidad { get; set; }

        public string unidadbascula { get; set; }

        public IDictionary<string, decimal> unidades
        {
            get { return p_unidades; }
        }

        Dictionary<string, decimal> p_unidades = null;
        public ProductInfo()
        {
            p_unidades = new Dictionary<string, decimal>();
        }
    }

    public class ProducProc
    {
        private ProductInfo _prod = null;

        public ProductInfo producto { get { return _prod; } set { _prod = value; unidad = _prod.unidad; precio = _prod.precio; cantidad = _prod.cantidad; } }

        private string _unidad = "";

        public string unidad
        {
            get { return _unidad; }
            set
            {
                if (string.IsNullOrWhiteSpace(_unidad))
                {
                    _unidad = value;
                    return;
                }

                cantidad = convertirUnidad(_unidad, cantidad, value);

                precio = convertirPrecio(_unidad, precio, value);

                _unidad = value;



            }
        }

        //cant está expresada en unidad_ant y se calculará la cantidad que corresponde en la unidad_nueva
        public decimal convertirUnidad(string unidad_ant, decimal cant, string unidad_nueva)
        {
            decimal f1 = 1, f2 = 1;
            decimal r = cant;

            if (unidad_ant != _prod.unidad)
            {
                if (!_prod.unidades.ContainsKey(unidad_ant))
                    throw new Exception("Unidad actual indicada no es válida");

                f1 = _prod.unidades[unidad_ant];
            }

            if (unidad_nueva != _prod.unidad)
            {
                if (!_prod.unidades.ContainsKey(unidad_nueva))
                    throw new Exception("Unidad nueva no es válida");

                f2 = _prod.unidades[unidad_nueva];
            }

            try
            {
                r = Math.Round(cant / (f2 / f1), 3);
            }
            catch (Exception) { r = 0; }

            return r;
        }

        public decimal convertirPrecio(string unidad_ant, decimal precio, string unidad_nueva)
        {
            decimal f1 = 1, f2 = 1;
            decimal r = precio;

            if (unidad_ant != _prod.unidad)
            {
                if (!_prod.unidades.ContainsKey(unidad_ant))
                    throw new Exception("Unidad actual indicada no es válida");

                f1 = _prod.unidades[unidad_ant];
            }

            if (unidad_nueva != _prod.unidad)
            {
                if (!_prod.unidades.ContainsKey(unidad_nueva))
                    throw new Exception("Unidad nueva no es válida");

                f2 = _prod.unidades[unidad_nueva];
            }

            try
            {
                r = Math.Round(precio * (f2 / f1), 3);
            }
            catch (Exception) { r = 0; }

            return r;
        }



        public decimal cantidad
        {
            get;
            set;
        }

        public decimal precio { get; set; }
        public decimal total
        {
            get
            {
                return cantidad * precio;
            }
            set
            {
                try { precio = Math.Round(value / cantidad, 4); }
                catch (Exception) { }
            }
        }
    }

    public class Bascula
    {
        static bool completed = false;
        static string input = "";

        private static string LeerArg(string[] args, int numero)
        {
            string retorno = "";
            try
            {
                retorno = args[numero];
            }
            catch { }
            return retorno;
        }

        private static string mensaje;
        private static string puerto;
        private static string velocidad;
        private static string bits_datos;
        private static string paridad;
        private static string handshake;
        private static string timeout;
        private static string max_long;
        private static string opciones;

        public static void Inicializar()
        {


            string fconfig = Path.Combine(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "basculaserie.cfg");

            if (!File.Exists(fconfig))
                throw new Exception("No se pudo encontrar el archivo de configuración de la báscula: " + fconfig);

            string[] args = File.ReadAllLines(fconfig);

             mensaje = LeerArg(args, 0);
             puerto = LeerArg(args, 1);
             velocidad = LeerArg(args, 2);
             bits_datos = LeerArg(args, 3);
             paridad = LeerArg(args, 4);
             handshake = LeerArg(args, 5);
             timeout = LeerArg(args, 6);
             max_long = LeerArg(args, 7);
             opciones = LeerArg(args, 8);

        }

        public static string LeerPuerto()
        {
            SerialPort Puerto_serie = new SerialPort();
            input = "";
            try
            {
                
                Puerto_serie.PortName = Bascula.puerto;

                if (string.IsNullOrEmpty(velocidad))
                {
                    Puerto_serie.BaudRate = 9600;
                }
                else
                {
                    Puerto_serie.BaudRate = Convert.ToInt32(velocidad);
                }

                if (string.IsNullOrEmpty(bits_datos))
                {
                    Puerto_serie.DataBits = 8;
                }
                else
                {
                    Puerto_serie.DataBits = Convert.ToInt32(bits_datos);
                }

                switch (paridad)
                {
                    case "x-Ninguna":
                        Puerto_serie.Parity = Parity.None;
                        break;
                    case "p-Par":
                        Puerto_serie.Parity = Parity.Even;
                        break;
                    case "p-Space":
                        Puerto_serie.Parity = Parity.Space;
                        break;
                    case "p-Mark":
                        Puerto_serie.Parity = Parity.Mark;
                        break;
                    default:
                        Puerto_serie.Parity = Parity.None;
                        break;
                }

                switch (handshake)
                {
                    case "n-Ninguno":
                        Puerto_serie.Handshake = Handshake.None;
                        break;
                    case "x-XonXoff":
                        Puerto_serie.Handshake = Handshake.XOnXOff;
                        break;
                    default:
                        Puerto_serie.Handshake = Handshake.None;
                        break;
                }

                if (string.IsNullOrEmpty(timeout))
                {
                    Puerto_serie.ReadTimeout = 500;
                    Puerto_serie.WriteTimeout = 500;
                }
                else
                {
                    Puerto_serie.ReadTimeout = Convert.ToInt32(timeout);
                    Puerto_serie.WriteTimeout = Convert.ToInt32(timeout);
                }

                Puerto_serie.StopBits = StopBits.One;


                Puerto_serie.Open();


                Puerto_serie.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                System.Windows.Forms.Application.DoEvents();
                byte[] miBuffer1 = Encoding.ASCII.GetBytes(mensaje);
                input = "";

                Puerto_serie.Write(miBuffer1, 0, miBuffer1.Length);
                completed = false;

                do { }
                while (!completed);

                input = filterDigits(input);

                Puerto_serie.Close();
            }
            catch
            {
                if (Puerto_serie.IsOpen)
                    Puerto_serie.Close();
            }

            return input;
        }


        private static string filterDigits(string data)
        {
            string ndata = "";
            foreach (char c in data)
                if ("0123456789.".IndexOf(c) >= 0)
                    ndata += c;


            return ndata;
        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {

            concatInBuffer(sender);

            completed = true;

        }

        private static void concatInBuffer(object sender)
        {
            foreach (char c in ((SerialPort)sender).ReadExisting().Trim())
                    input += c;

        }

    }
}
