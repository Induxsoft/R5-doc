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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capturaGranel
{
    static class Program
    {


        //Línea de comando: "codigo_producto" "descripcion_producto" "cantidad" "precio" "unidad" "unidad2:factor2,unidad3:factor3..." "unidad_usa_bascula"
        
        [STAThread]
        static void Main(string [] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ProductInfo p = new ProductInfo();

            if (args.Length<5)
            {
                MessageBox.Show("Faltan parámetros de la línea comando.\r\n\r\ncapturaGranel.exe \"codigo_producto\" \"descripcion_producto\" \"cantidad\" \"precio\" \"unidad\" \"unidad2:factor2,unidad3:factor3...\" \"unidad_usa_bascula\"","Captura a granel");
                return;
            }

            p.codigo = args[0];
            p.descripcion = args[1];
            p.cantidad = Convert.ToDecimal(args[2]);
            p.precio = Convert.ToDecimal(args[3]);

            p.unidad = args[4];

            if (args.Length>5)
                foreach(string u in args[5].Trim().Split(','))
                    if (u.Contains(':'))
                        p.unidades[u.Split(':')[0].Trim()] = Convert.ToDecimal(u.Split(':')[1].Trim());

            if (args.Length > 6)
                p.unidadbascula = args[6].Trim();

            Application.Run(new formCaptura(p));
        }
    }
}
