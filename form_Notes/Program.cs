using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using dll_Notes;
using Notes;

namespace form_Notes
{
    static class Program
    {
        private static cls_Modele s_Modele;
        private static cls_Base s_Controleur;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static Program()
        {
            s_Modele = new cls_Modele();
            s_Controleur = new cls_Base("localhost", "postgres", "123456", "notes");
        }

        public static cls_Base Controleur 
        {
            get { return s_Controleur; }
        }

        public static cls_Modele Modele
        {
            get { return s_Modele; }
        }
    }
}
