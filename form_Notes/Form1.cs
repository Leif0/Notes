using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Notes;

namespace form_Notes
{
    public partial class Form1 : Form
    {
        public string c_Path { get; set; }

        public Form1()
        {
            InitializeComponent();
            lbl_Emplacement.Hide();
        }

        private void btn_Generer_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Créer l'objet base de donnée et les groupes
            cls_Base l_Base = new cls_Base("localhost", "postgres", "123456", "notes");

            // Créer les groupes
            List<cls_Groupe> l_Groupes = l_Base.CreerGroupes();

            foreach (cls_Groupe l_Groupe in l_Groupes)
            {
                cbx_ChoixGroupe.Items.Add(l_Groupe.getLibelle());
            }

            // Un seul semestre en dur
            cls_Semestre l_Semestre1 = new cls_Semestre(1, new DateTime(2016, 1, 1), new DateTime(2016, 6, 1));

            // Clique sur le bouton de génération des PDF

            btn_Generer.Click += delegate(object pSender, EventArgs pArgs)
            {
                // Trouve le groupe selectionné
                cls_Groupe l_Groupe = l_Groupes.Find(
                    delegate (cls_Groupe groupe)
                    {
                        return groupe.getLibelle() == cbx_ChoixGroupe.Text;
                    }
                );

                // Créer les élèves
                List<cls_Eleve> l_Eleves = l_Base.CreerEleves(l_Groupe);

                // Créer les matières
                List<cls_Matiere> l_Matieres = l_Base.CreerMatieres(l_Groupe);

                // Créer les devoirs
                List<cls_Devoir> l_Devoirs = l_Base.CreerDevoirs(l_Matieres);

                // Créer les notes
                List<cls_Note> l_Notes = l_Base.CreerNotes(l_Devoirs, l_Eleves, l_Semestre1);

                cls_Pdf l_Pdf = new cls_Pdf(l_Groupe);
            };
        }


        private void btn_OuvrirDossier_Click_1(object sender, EventArgs e)
        {
            /*string l_DossierProjet = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            #if DEBUG
                l_DossierProjet += "\\bin\\Debug";
            #else
                Console.WriteLine("Mode=Release"); 
            #endif*/

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = c_Path,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void btn_ChoixDossier_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            c_Path = fbd.SelectedPath;
            lbl_Emplacement.Text = c_Path;
        }

        private void btn_ChoixDossier_MouseEnter(object sender, EventArgs e)
        {
            lbl_Emplacement.Show();
        }

        private void btn_ChoixDossier_MouseLeave(object sender, EventArgs e)
        {
            lbl_Emplacement.Hide();
        }
    }
}
