namespace capturaGranel
{
    partial class formCaptura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCaptura));
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.cTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cCantidad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cPrecio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cUnidad = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sel5 = new System.Windows.Forms.Label();
            this.sel4 = new System.Windows.Forms.Label();
            this.sel3 = new System.Windows.Forms.Label();
            this.sel2 = new System.Windows.Forms.Label();
            this.sel1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tmBascula = new System.Windows.Forms.Timer(this.components);
            this.lblBascula = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCantidad
            // 
            this.lblCantidad.BackColor = System.Drawing.Color.Black;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.Yellow;
            this.lblCantidad.Location = new System.Drawing.Point(4, 5);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(461, 98);
            this.lblCantidad.TabIndex = 0;
            this.lblCantidad.Text = "28000.000";
            this.lblCantidad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Black;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Lime;
            this.lblTotal.Location = new System.Drawing.Point(449, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(500, 98);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "$ 23,890.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUnidad
            // 
            this.lblUnidad.BackColor = System.Drawing.Color.Black;
            this.lblUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidad.ForeColor = System.Drawing.Color.Yellow;
            this.lblUnidad.Location = new System.Drawing.Point(56, 73);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(387, 30);
            this.lblUnidad.TabIndex = 2;
            this.lblUnidad.Text = "KG";
            this.lblUnidad.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(6, 103);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(936, 139);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Mango ataulfo";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.cTotal);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cCantidad);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cPrecio);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cUnidad);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.sel5);
            this.panel1.Controls.Add(this.sel4);
            this.panel1.Controls.Add(this.sel3);
            this.panel1.Controls.Add(this.sel2);
            this.panel1.Controls.Add(this.sel1);
            this.panel1.Location = new System.Drawing.Point(120, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 242);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(418, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "(F4 - desplegar/contraer)";
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnOk.Location = new System.Drawing.Point(131, 176);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(381, 51);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Confirmar (F10)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            this.btnOk.Enter += new System.EventHandler(this.btnOk_Enter);
            this.btnOk.Leave += new System.EventHandler(this.btnOk_Leave);
            // 
            // cTotal
            // 
            this.cTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cTotal.Location = new System.Drawing.Point(288, 127);
            this.cTotal.Name = "cTotal";
            this.cTotal.Size = new System.Drawing.Size(121, 26);
            this.cTotal.TabIndex = 3;
            this.cTotal.TextChanged += new System.EventHandler(this.cTotal_TextChanged);
            this.cTotal.Enter += new System.EventHandler(this.cNumbers_Enter);
            this.cTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cTotal_KeyPress);
            this.cTotal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cTotal_KeyUp);
            this.cTotal.Leave += new System.EventHandler(this.Everything_Leave);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(196, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Total:";
            // 
            // cCantidad
            // 
            this.cCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cCantidad.Location = new System.Drawing.Point(288, 55);
            this.cCantidad.Name = "cCantidad";
            this.cCantidad.Size = new System.Drawing.Size(121, 26);
            this.cCantidad.TabIndex = 1;
            this.cCantidad.TextChanged += new System.EventHandler(this.cCantidad_TextChanged);
            this.cCantidad.Enter += new System.EventHandler(this.cNumbers_Enter);
            this.cCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cCantidad_KeyPress);
            this.cCantidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cCantidad_KeyUp);
            this.cCantidad.Leave += new System.EventHandler(this.Everything_Leave);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(196, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Cantidad:";
            // 
            // cPrecio
            // 
            this.cPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cPrecio.Location = new System.Drawing.Point(288, 89);
            this.cPrecio.Name = "cPrecio";
            this.cPrecio.Size = new System.Drawing.Size(121, 26);
            this.cPrecio.TabIndex = 2;
            this.cPrecio.TextChanged += new System.EventHandler(this.cPrecio_TextChanged);
            this.cPrecio.Enter += new System.EventHandler(this.cNumbers_Enter);
            this.cPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cPrecio_KeyPress);
            this.cPrecio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cPrecio_KeyUp);
            this.cPrecio.Leave += new System.EventHandler(this.Everything_Leave);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(196, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Precio u.:";
            // 
            // cUnidad
            // 
            this.cUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUnidad.FormattingEnabled = true;
            this.cUnidad.Location = new System.Drawing.Point(288, 17);
            this.cUnidad.Name = "cUnidad";
            this.cUnidad.Size = new System.Drawing.Size(121, 28);
            this.cUnidad.TabIndex = 0;
            this.cUnidad.SelectedValueChanged += new System.EventHandler(this.cUnidad_SelectedValueChanged);
            this.cUnidad.Enter += new System.EventHandler(this.cUnidad_Enter);
            this.cUnidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cUnidad_KeyPress);
            this.cUnidad.Leave += new System.EventHandler(this.Everything_Leave);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(197, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Unidad:";
            // 
            // sel5
            // 
            this.sel5.BackColor = System.Drawing.Color.Lime;
            this.sel5.Location = new System.Drawing.Point(53, 197);
            this.sel5.Name = "sel5";
            this.sel5.Size = new System.Drawing.Size(527, 10);
            this.sel5.TabIndex = 12;
            this.sel5.Visible = false;
            // 
            // sel4
            // 
            this.sel4.BackColor = System.Drawing.Color.Lime;
            this.sel4.Location = new System.Drawing.Point(53, 133);
            this.sel4.Name = "sel4";
            this.sel4.Size = new System.Drawing.Size(527, 10);
            this.sel4.TabIndex = 11;
            this.sel4.Visible = false;
            // 
            // sel3
            // 
            this.sel3.BackColor = System.Drawing.Color.Lime;
            this.sel3.Location = new System.Drawing.Point(53, 97);
            this.sel3.Name = "sel3";
            this.sel3.Size = new System.Drawing.Size(527, 10);
            this.sel3.TabIndex = 10;
            this.sel3.Visible = false;
            // 
            // sel2
            // 
            this.sel2.BackColor = System.Drawing.Color.Lime;
            this.sel2.Location = new System.Drawing.Point(54, 63);
            this.sel2.Name = "sel2";
            this.sel2.Size = new System.Drawing.Size(527, 10);
            this.sel2.TabIndex = 9;
            this.sel2.Visible = false;
            // 
            // sel1
            // 
            this.sel1.BackColor = System.Drawing.Color.Lime;
            this.sel1.Location = new System.Drawing.Point(54, 26);
            this.sel1.Name = "sel1";
            this.sel1.Size = new System.Drawing.Size(527, 10);
            this.sel1.TabIndex = 8;
            this.sel1.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(807, 538);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 29);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancelar (ESC)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(117, 492);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "(Arriba - Campo anterior, Abajo - Siguiente campo, Enter - Siguiente campo)";
            // 
            // tmBascula
            // 
            this.tmBascula.Interval = 800;
            this.tmBascula.Tick += new System.EventHandler(this.tmBascula_Tick);
            // 
            // lblBascula
            // 
            this.lblBascula.AutoSize = true;
            this.lblBascula.ForeColor = System.Drawing.Color.White;
            this.lblBascula.Location = new System.Drawing.Point(14, 546);
            this.lblBascula.Name = "lblBascula";
            this.lblBascula.Size = new System.Drawing.Size(0, 13);
            this.lblBascula.TabIndex = 9;
            // 
            // formCaptura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(954, 579);
            this.ControlBox = false;
            this.Controls.Add(this.lblBascula);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblCantidad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "formCaptura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Granel";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.formCaptura_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.formCaptura_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox cTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox cCantidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cPrecio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cUnidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label sel5;
        private System.Windows.Forms.Label sel4;
        private System.Windows.Forms.Label sel3;
        private System.Windows.Forms.Label sel2;
        private System.Windows.Forms.Label sel1;
        private System.Windows.Forms.Timer tmBascula;
        private System.Windows.Forms.Label lblBascula;
    }
}

