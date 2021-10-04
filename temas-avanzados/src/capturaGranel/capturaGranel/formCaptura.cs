using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capturaGranel
{
    public partial class formCaptura : Form
    {
        ProducProc Producto = new ProducProc();

        public formCaptura(ProductInfo p)
        {
            Producto.producto = p;
            
            InitializeComponent();

            lblDescripcion.Text = p.descripcion;

            cUnidad.Items.Add(p.unidad);

            cUnidad.Items.AddRange(p.unidades.Keys.ToArray());

            cUnidad.SelectedIndex = 0;

            cCantidad.Text = p.cantidad.ToString();
            cPrecio.Text = p.precio.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("**CANCEL***");
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (Producto.cantidad<=0 || Producto.precio<=0 || Producto.total<=0)
            {
                MessageBox.Show("Datos incorrectos, verifique CANTIDAD, PRECIO Y TOTAL.");
                cCantidad.Focus();
                return;
            }

            string output = "***" + Producto.producto.codigo + "|" +
                Producto.convertirPrecio(Producto.unidad, Producto.total, Producto.producto.unidad).ToString() + "|" +
                Producto.convertirUnidad(Producto.unidad, Producto.cantidad, Producto.producto.unidad).ToString();

            //MessageBox.Show(output);
            Console.WriteLine(output);

            this.Close();
        }

        private void formCaptura_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Escape:
                    btnCancel_Click(this, null);
                    break;
                case Keys.F10:
                    btnOk_Click(this, null);
                    break;
            }
        }

        private void cUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cCantidad.Focus();

        }

        private string digits = "0123456789." + (char) 8;

        private void cCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cPrecio.Focus();
                e.Handled = true;
            }

            if (digits.IndexOf(e.KeyChar) < 0)
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
        }

        private void cPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { 
                cTotal.Focus();
                e.Handled = true;
            }

            if (digits.IndexOf(e.KeyChar) < 0)
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
        }

        private void cTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnOk.Focus();
                e.Handled = true;
            }

            if (digits.IndexOf(e.KeyChar) < 0)
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }

            
        }

        private void cTotal_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            { 
                case Keys.Up:
                    e.Handled = true;
                    cPrecio.Focus();
                    break;
                case Keys.Down:
                    e.Handled = true;
                    btnOk.Focus();
                    break;
            }
        }

        private void cPrecio_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    e.Handled = true;
                    cCantidad.Focus();
                    break;
                case Keys.Down:
                    e.Handled = true;
                    cTotal.Focus();
                    break;
            }
        }

        private void cCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    e.Handled = true;
                    cUnidad.Focus();
                    break;
                case Keys.Down:
                    e.Handled = true;
                    cPrecio.Focus();
                    break;
            }
        }


        private void Display()
        {
            lblUnidad.Text = Producto.unidad;
            lblCantidad.Text = cCantidad.Text;
            lblTotal.Text = cTotal.Text;
        }

        private void cUnidad_SelectedValueChanged(object sender, EventArgs e)
        {
            Producto.unidad = cUnidad.Text;
            try { Producto.cantidad = Convert.ToDecimal(cCantidad.Text.Replace("$", "").Replace(",", "")); }
            catch (Exception) { Producto.cantidad = 0; }

            cPrecio.Text = Producto.precio.ToString("$ #,#.00");

            Display();
        }

        private void cCantidad_TextChanged(object sender, EventArgs e)
        {
            decimal c = 0;

            try { c = Convert.ToDecimal(cCantidad.Text.Replace("$", "").Replace(",", "")); }
            catch (Exception) { }

            Producto.cantidad = c;

            cTotal.Text = Producto.total.ToString("$ #,#.00");
            Display();
        }


        private bool Freeze = false;
        private void cPrecio_TextChanged(object sender, EventArgs e)
        {
            if (Freeze) return;
            Freeze = true;
            decimal c = 0;

            try { c = Convert.ToDecimal(cPrecio.Text.Replace("$", "").Replace(",", "")); }
            catch (Exception) { }

            Producto.precio = c;

            cTotal.Text = Producto.total.ToString("$ #,#.00");
            Display();
            Freeze = false;
        }

        private void cTotal_TextChanged(object sender, EventArgs e)
        {
            if (Freeze) return;

            Freeze = true;
            decimal c = 0;

            try { c = Convert.ToDecimal(cTotal.Text.Replace("$", "").Replace(",", "")); }
            catch (Exception) { }

            Producto.total = c;

            cPrecio.Text = Producto.precio.ToString("$ #,#.00");
            Display();
            Freeze = false;
        }

        private void cCantidad_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

    }

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

        Dictionary<string, decimal> p_unidades=null;
        public ProductInfo()
        {
            p_unidades=new Dictionary<string,decimal>();
        }
    }

    public class ProducProc
    {
        private ProductInfo _prod = null;

        public ProductInfo producto { get { return _prod; } set { _prod = value; unidad = _prod.unidad; precio = _prod.precio; cantidad = _prod.cantidad; } }

        private string _unidad = "";

        public string unidad 
        { 
            get {return _unidad;}
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
            decimal f1 = 1, f2=1;
            decimal r = cant;

            if (unidad_ant!=_prod.unidad)
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
}
