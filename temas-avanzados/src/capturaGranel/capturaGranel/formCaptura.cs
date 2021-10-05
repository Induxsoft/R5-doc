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

            if (!string.IsNullOrWhiteSpace(p.unidadbascula))
            {
                try
                {
                    Bascula.Inicializar();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                tmBascula.Enabled = true;
            }
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
                Producto.total.ToString() + "|" +
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

        private void cNumbers_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            
            HideIndicador();

            switch(((TextBox)sender).Name)
            {
                case "cCantidad":
                    sel2.Visible = true;
                    break;
                case "cPrecio":
                    sel3.Visible = true;
                    break;
                case "cTotal":
                    sel4.Visible = true;
                    break;
            }
        }

        private void formCaptura_Shown(object sender, EventArgs e)
        {
            this.Activate();
            cCantidad.Focus();
        }

        private void cUnidad_Enter(object sender, EventArgs e)
        {
            HideIndicador();
            sel1.Visible = true;
        }

        private void btnOk_Enter(object sender, EventArgs e)
        {
            HideIndicador();
            sel5.Visible = true;
        }

        private void btnOk_Leave(object sender, EventArgs e)
        {
            HideIndicador();
        }

        private void Everything_Leave(object sender, EventArgs e)
        {
            HideIndicador();
        }

        void HideIndicador()
        {
            sel1.Visible = false;
            sel2.Visible = false;
            sel3.Visible = false;
            sel4.Visible = false;
            sel5.Visible = false;
        }

        private string ultimoPeso="";

        private void tmBascula_Tick(object sender, EventArgs e)
        {
            if (Producto.producto.unidadbascula != cUnidad.Text)
                return;

            string p = Bascula.LeerPuerto();

            lblBascula.Text = p;

            if (p != ultimoPeso )
            {
                ultimoPeso = p;
                cCantidad.Text = p;
                cCantidad.SelectAll();
            }
        }

    }

   
}
