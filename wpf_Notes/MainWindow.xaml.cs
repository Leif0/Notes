using Notes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_Notes
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_GenererBulletins_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboBox_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
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
            btn_GenererBulletins.Click += delegate(object pSender, RoutedEventArgs pArgs)
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

        private void cbx_ChoixGroupe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_OuvrirDossier_Click(object sender, RoutedEventArgs e)
        {
            string l_DossierProjet = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            #if DEBUG
                l_DossierProjet += "\\bin\\Debug";
            #else
                Console.WriteLine("Mode=Release"); 
            #endif

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = l_DossierProjet,
                UseShellExecute = true,
                Verb = "open"
            });
        }
    }
}
