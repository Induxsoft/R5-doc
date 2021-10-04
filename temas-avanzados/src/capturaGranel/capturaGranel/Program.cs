using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capturaGranel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ProductInfo p = new ProductInfo();

            p.codigo = "MA001";
            p.descripcion = "Piña";
            p.precio = 45.50m;

            p.unidad = "Kg";
            p.unidadbascula = p.unidad;

            p.unidades["Reja"] = 25;
            p.unidades["Costal"] = 35;
            p.unidades["Tonelada"] = 1000;
            
            

            Application.Run(new formCaptura(p));
        }
    }
}
