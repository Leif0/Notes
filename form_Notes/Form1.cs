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
using dll_Notes;
using Notes;

namespace form_Notes
{
    public partial class Form1 : Form
    {
        public string c_Path { get; set; }

        public cls_Modele c_Modele;
        public cls_Base c_Controleur;
        // Un seul semestre en dur
        private cls_Semestre c_Semestre1;

        /// <summary>
        /// Différents types de logs
        /// </summary>
        private enum TypeLog
        {
            ModificationEleve,
            AjoutEleve,
            SuppressionEleve
        }

        public Form1()
        {
            InitializeComponent();
            lbl_Emplacement.Hide();

            c_Semestre1 = new cls_Semestre(1, new DateTime(2016, 1, 1), new DateTime(2016, 6, 1));
            c_Modele = new cls_Modele();
            c_Controleur = new cls_Base("localhost", "postgres", "123456", "notes");

            // Créer les groupes
            c_Modele.ListeGroupes = c_Controleur.CreerGroupes();

            foreach (cls_Groupe l_Groupe in c_Modele.ListeGroupes.Values)
            {
                cbx_ChoixGroupe.Items.Add(l_Groupe);
            }

            
        }

        /// <summary>
        /// Ouvre l'emplacement de sauvegarde des PDFs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OuvrirDossier_Click_1(object sender, EventArgs e)
        {
            if (c_Path != null)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = c_Path,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
            else
            {
                MessageBox.Show(
                    "Merci de sélectionner un dossier d'enregistrement pour les fichiers PDF.", 
                    "Aucun dossier sélectionné", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );
            }
        }

        /// <summary>
        /// Choix du dossier de sauvegarde des PDFs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ChoixDossier_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            c_Path = fbd.SelectedPath;
            lbl_Emplacement.Text = c_Path;
        }

        /// <summary>
        /// Montre l'emplacement de sauvegarde des PDFs lors du hover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ChoixDossier_MouseEnter(object sender, EventArgs e)
        {
            lbl_Emplacement.Show();
        }

        /// <summary>
        /// Cache l'emplacement de sauvegarde des PDFs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ChoixDossier_MouseLeave(object sender, EventArgs e)
        {
            lbl_Emplacement.Hide();
        }

        /// <summary>
        /// Procédure lancée lors de la selection d'un groupe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_ChoixGroupe_SelectedValueChanged(object sender, EventArgs e)
        {
            // Remise à zéro
            dtg_Eleves.Rows.Clear();
            dtg_Eleves.Columns.Clear();

            cls_Groupe l_Groupe = (cls_Groupe) cbx_ChoixGroupe.SelectedItem;

            // Créer les élèves
            c_Modele.ListeEleves = c_Controleur.CreerEleves(l_Groupe);

            // Les matières
            List<cls_Matiere> l_Matieres = c_Controleur.CreerMatieres(l_Groupe);

            // Colonnes
            dtg_Eleves.Columns.Add("col_Id", "Id");
            // Impossible de modifier l'id d'un élève
            dtg_Eleves.Columns[0].ReadOnly = true;
            dtg_Eleves.Columns.Add("col_Nom", "Nom");
            dtg_Eleves.Columns.Add("col_Prenom", "Prénom");
            dtg_Eleves.Columns.Add("col_DateNaissance", "Date de naissance");
            dtg_Eleves.Columns.Add("col_Adresse", "Adresse");

            foreach (cls_Matiere l_Matiere in l_Matieres)
            {
                dtg_Eleves.Columns.Add(l_Matiere.getLibelle(), l_Matiere.getLibelle());
            }

            // Lignes

            foreach (cls_Eleve l_Eleve in c_Modele.ListeEleves.Values)
            {
                DataGridViewRow row_Eleve = new DataGridViewRow();

                // Id

                DataGridViewCell cell_Id = new DataGridViewTextBoxCell();
                cell_Id.Value = l_Eleve.getId();
                row_Eleve.Cells.Add(cell_Id);

                // Nom

                DataGridViewCell cell_Nom = new DataGridViewTextBoxCell();
                cell_Nom.Value = l_Eleve.getNom();
                row_Eleve.Cells.Add(cell_Nom);

                // Prénom

                DataGridViewCell cell_Prenom = new DataGridViewTextBoxCell();
                cell_Prenom.Value = l_Eleve.getPrenom();
                row_Eleve.Cells.Add(cell_Prenom);

                // Date de naissance

                DataGridViewCell cell_DateNaissance = new DataGridViewTextBoxCell();
                cell_DateNaissance.Value = l_Eleve.getDateNaissance();
                row_Eleve.Cells.Add(cell_DateNaissance);

                // Ajoute la colonne groupe

                // Adresse
                DataGridViewCell cell_Adresse = new DataGridViewTextBoxCell();
                cell_Adresse.Value = l_Eleve.getAdresse();
                row_Eleve.Cells.Add(cell_Adresse);

                // Créer les devoirs
                List<cls_Devoir> l_Devoirs = c_Controleur.CreerDevoirs(l_Matieres);

                // Créer les notes
                List<cls_Note> l_Notes = c_Controleur.CreerNotes(l_Devoirs, c_Modele.ListeEleves, c_Semestre1);

                foreach (cls_Matiere l_Matiere in l_Matieres)
                {
                    // La moyenne
                    DataGridViewCell cell_Matiere = new DataGridViewTextBoxCell();
                    double l_MoyenneEleve = l_Eleve.MoyenneMatiereSemestre(l_Matiere, c_Semestre1);

                    // Si il n'y a pas de moyenne, cellule vide
                    if (l_MoyenneEleve != -1)
                    {
                        cell_Matiere.Value = l_MoyenneEleve;
                    }
                    else
                    {
                        cell_Matiere.Value = null;
                    }
                    // Ajoute la cellule à la ligne
                    row_Eleve.Cells.Add(cell_Matiere);
                }

                // Ajoute la ligne au tableau
                dtg_Eleves.Rows.Add(row_Eleve);
            }
        }

        /// <summary>
        /// Clic sur le bouton Générer PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Generer_Click(object sender, EventArgs e)
        {
            if (dtg_Eleves.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                      "Merci de sélectionner des élèves",
                      "Aucun élève sélectionné",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information
                      );
            }

            if (c_Path == null)
            {
                btn_ChoixDossier.FlatAppearance.BorderColor = Color.Cyan;

                MessageBox.Show(
                    "Merci de sélectionner un dossier d'enregistrement pour les fichiers PDF.",
                    "Aucun dossier sélectionné",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
            else
            {
                cls_Groupe l_Groupe = (cls_Groupe)cbx_ChoixGroupe.SelectedItem;

                foreach (DataGridViewRow row in dtg_Eleves.SelectedRows)
                {
                    if (row.IsNewRow != true)
                    {
                        int l_IdEleve = Convert.ToInt32(row.Cells["col_Id"].Value.ToString());
                        cls_Pdf l_Pdf = new cls_Pdf(c_Modele.ListeEleves[l_IdEleve], c_Semestre1, c_Path);
                    }
                }
            }
        }
        /// <summary>
        /// Sélectionne tous les élèves
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectionnerTout_Click(object sender, EventArgs e)
        {
            dtg_Eleves.SelectAll();
        }
        /// <summary>
        /// Validation d'une cellule lorsqu'elle est modifiée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtg_Eleves_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // On n'enregistre pas les modifications sur une nouvelle ligne ou sur l'id
            if (dtg_Eleves.Rows[e.RowIndex].IsNewRow || e.ColumnIndex == 0) {return;}

            // La colonne modifiée
            string l_ColonneModifie = dtg_Eleves.Columns[e.ColumnIndex].HeaderText;

            // Id de l'élève modifié
            int l_IdEleveModifie = Convert.ToInt32(dtg_Eleves[0, e.RowIndex].Value);

            // L'élève modifié en lui même
            cls_Eleve l_EleveModifie = c_Modele.getEleveById(l_IdEleveModifie);

            switch (l_ColonneModifie)
            {
                case "Nom":
                    l_EleveModifie.setNom(e.FormattedValue.ToString());
                    break;
                case "Prénom":
                    l_EleveModifie.setPrenom(e.FormattedValue.ToString());
                    break;
                case "Date de naissance":
                    l_EleveModifie.setDateNaissance(e.FormattedValue.ToString());
                    break;
                default:
                    break;
            }
            c_Modele.ModifierEleve(l_EleveModifie);
            c_Controleur.ModifierEleve(l_EleveModifie);

            // TODO : déplacer dans une procédure

            AjouterLog(TypeLog.ModificationEleve, "Eleve modifié : " + l_EleveModifie.getNom() + " " + l_EleveModifie.getPrenom() + " dans la colonne " + l_ColonneModifie);
        }

        /// <summary>
        /// Ajoute un bouton de log quand une action est effectuée
        /// </summary>
        /// <param name="pTypeLog">Type de log</param>
        /// <param name="pMessage">Message à afficher lors du clic</param>
        private void AjouterLog(TypeLog pTypeLog, string pMessage)
        {
            Button new_Log = new Button();

            switch (pTypeLog)
            {
                case TypeLog.ModificationEleve:
                    new_Log.Text = "Modification élève";
                    break;
                case TypeLog.AjoutEleve:
                    new_Log.Text = "Élève ajouté";
                    break;
                case TypeLog.SuppressionEleve:
                    new_Log.Text = "Élève supprimé";
                    break;
            }
            
            new_Log.Width = 120;
            new_Log.FlatAppearance.BorderSize = 0;
            new_Log.FlatStyle = FlatStyle.Flat;
            new_Log.FlatAppearance.BorderColor = Color.DimGray;
            new_Log.FlatAppearance.BorderSize = 1;
            new_Log.Click += delegate
            {
                MessageBox.Show(pMessage);
            };
            flp_Log.Controls.Add(new_Log);
        }
    }
}
