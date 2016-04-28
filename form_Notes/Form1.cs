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

        // Un seul semestre en dur
        private cls_Semestre c_Semestre1;

        /// <summary>
        /// Différents types de logs
        /// </summary>
        private enum TypeLog
        {
            ModificationEleve,
            AjoutEleve,
            SuppressionEleve,
            GenerationPDF,
            ChangementDossier,
            ChangementGroupe,
            OuvertureDossier
        }

        public Form1()
        {
            InitializeComponent();
            lbl_Emplacement.Hide();

            c_Semestre1 = new cls_Semestre(1, new DateTime(2016, 1, 1), new DateTime(2016, 6, 1));

            // Créer les groupes
            Program.Modele.ListeGroupes = Program.Controleur.CreerGroupes();

            foreach (cls_Groupe l_Groupe in Program.Modele.ListeGroupes.Values)
            {
                cbx_ChoixGroupe.Items.Add(l_Groupe);
                // Créer les eleves
                Program.Modele.ListeEleves = Program.Controleur.CreerEleves(l_Groupe);
                // Créer les matieres
                Program.Modele.ListeMatieres = Program.Controleur.CreerMatieres(l_Groupe);
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
                AjouterLog(TypeLog.OuvertureDossier, "Ouverture du dossier de sauvegarde des PDFs");
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
            AjouterLog(TypeLog.ChangementDossier, "Changement de l'emplacement de sauvegarde des PDFs");
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
            AjouterLog(TypeLog.ChangementGroupe, 
                       "Changement du groupe actif : " + cbx_ChoixGroupe.SelectedValue);

            RafraichirDonnees(this);
        }

        public static void RafraichirDonnees(Form1 pForm)
        {
            // Remise à zéro
            pForm.dtg_Eleves.Rows.Clear();
            pForm.dtg_Eleves.Columns.Clear();

            pForm.dtg_Matieres.Rows.Clear();
            pForm.dtg_Matieres.Columns.Clear();

            pForm.dgv_Devoirs.Rows.Clear();
            pForm.dgv_Devoirs.Columns.Clear();

            cls_Groupe l_Groupe = (cls_Groupe)pForm.cbx_ChoixGroupe.SelectedItem;

            // Créer les élèves
            Program.Modele.ListeEleves = Program.Controleur.CreerEleves(l_Groupe);

            // Les matières
            Program.Modele.ListeMatieres = Program.Controleur.CreerMatieres(l_Groupe);

            // Ajoute les colonnes des élèves
            pForm.AjouterColonnes(Program.Modele.ListeMatieres);

            // Ajoute les lignes des élèves au tableau
            pForm.AjouterLignesEleves(Program.Modele.ListeEleves.Values, Program.Modele.ListeMatieres);

            // Créer la liste des devoirs
            Program.Modele.ListeDevoirs = Program.Controleur.CreerDevoirs(Program.Modele.ListeMatieres);

            // Ajoute la liste des devoirs
            pForm.AjouterColonnesDevoirs(Program.Modele.ListeDevoirs);

            // Ajoute les lignes des devoirs
            pForm.AjouterLignesDevoirs(Program.Modele.ListeDevoirs.Values);

            // Ajoute les colonnes des matières
            pForm.AjouterColonnesMatieres(Program.Modele.ListeMatieres);

            // Ajoute les lignes des matières
            pForm.AjouterLignesMatieres(Program.Modele.ListeMatieres);
        }

        /// <summary>
        /// Ajoute les colonnes au tableau d'élèves
        /// </summary>
        /// <param name="pMatiere">Liste des matières</param>
        private void AjouterColonnes(Dictionary<int, cls_Matiere> pMatiere)
        {
            dtg_Eleves.Columns.Add("col_Id", "Id");
            dtg_Eleves.Columns[0].ReadOnly = true; // Impossible de modifier l'id d'un élève
            dtg_Eleves.Columns.Add("col_Nom", "Nom");
            dtg_Eleves.Columns.Add("col_Prenom", "Prénom");
            dtg_Eleves.Columns.Add("col_DateNaissance", "Date de naissance");
            dtg_Eleves.Columns.Add("col_Adresse", "Adresse");

            foreach (cls_Matiere l_Matiere in pMatiere.Values)
            {
                dtg_Eleves.Columns.Add(l_Matiere.Libelle, l_Matiere.Libelle);
            }
        }

        private void AjouterColonnesDevoirs(Dictionary<int, cls_Devoir> pDevoir)
        {
            dgv_Devoirs.Columns.Add("col_Id", "Id");
            dgv_Devoirs.Columns.Add("col_Libelle", "Libellé");
            dgv_Devoirs.Columns.Add("col_DateDevoir", "Date");
            dgv_Devoirs.Columns.Add("col_IdMatiere", "Matière");
        }

        private void AjouterColonnesMatieres(Dictionary<int, cls_Matiere> pMatieres)
        {
            dtg_Matieres.Columns.Add("col_Id", "Id");
            dtg_Matieres.Columns.Add("col_Libelle", "Libellé");
            dtg_Matieres.Columns.Add("col_Groupe", "Groupe");
            dtg_Matieres.Columns.Add("col_Coefficient", "Coefficient");
            dtg_Matieres.Columns.Add("col_Professeur", "Professeur");
        }

        private void AjouterLignesMatieres(Dictionary<int, cls_Matiere> pMatieres)
        {
            foreach (cls_Matiere l_Matiere in pMatieres.Values)
            {
                DataGridViewRow row_Matiere = new DataGridViewRow();

                // Id
                DataGridViewCell cell_Id = new DataGridViewTextBoxCell();
                cell_Id.Value = l_Matiere.Id;
                row_Matiere.Cells.Add(cell_Id);

                // Libellé
                DataGridViewCell cell_Libelle = new DataGridViewTextBoxCell();
                cell_Libelle.Value = l_Matiere.Libelle;
                row_Matiere.Cells.Add(cell_Libelle);

                // Groupe
                DataGridViewCell cell_Groupe = new DataGridViewTextBoxCell();
                cell_Groupe.Value = l_Matiere.Groupe;
                row_Matiere.Cells.Add(cell_Groupe);

                // Coefficient
                DataGridViewCell cell_Coefficient = new DataGridViewTextBoxCell();
                cell_Coefficient.Value = l_Matiere.Coefficient;
                row_Matiere.Cells.Add(cell_Coefficient);

                // Professeur
                DataGridViewCell cell_Professeur = new DataGridViewTextBoxCell();
                cell_Professeur.Value = l_Matiere.Professeur;
                row_Matiere.Cells.Add(cell_Professeur);

                dtg_Matieres.Rows.Add(row_Matiere);
            }
        }

        private void AjouterLignesDevoirs(Dictionary<int, cls_Devoir>.ValueCollection pDevoirs)
        {
            foreach (cls_Devoir l_Devoir in pDevoirs)
            {
                DataGridViewRow row_Devoir = new DataGridViewRow();

                // Id
                DataGridViewCell cell_Id = new DataGridViewTextBoxCell();
                cell_Id.Value = l_Devoir.Id;
                row_Devoir.Cells.Add(cell_Id);

                // Libellé
                DataGridViewCell cell_Libelle = new DataGridViewTextBoxCell();
                cell_Libelle.Value = l_Devoir.getLibelle();
                row_Devoir.Cells.Add(cell_Libelle);

                // Date
                DataGridViewCell cell_DateDevoir = new DataGridViewTextBoxCell();
                cell_DateDevoir.Value = l_Devoir.getDateDevoir();
                row_Devoir.Cells.Add(cell_DateDevoir);

                // Id matiere
                DataGridViewCell cell_Matiere = new DataGridViewTextBoxCell();
                cell_Matiere.Value = l_Devoir.getMatiere().ToString();
                row_Devoir.Cells.Add(cell_Matiere);

                dgv_Devoirs.Rows.Add(row_Devoir);
            }

            
        }

        /// <summary>
        /// Ajoute les élèves au tableau
        /// </summary>
        /// <param name="pEleves">Les élèves</param>
        /// <param name="pMatiere">Liste des matières</param>
        private void AjouterLignesEleves(Dictionary<int, cls_Eleve>.ValueCollection pEleves, Dictionary<int, cls_Matiere> pMatieres)
        {
            foreach (cls_Eleve l_Eleve in pEleves)
            {
                DataGridViewRow row_Eleve = new DataGridViewRow();

                // Id
                DataGridViewCell cell_Id = new DataGridViewTextBoxCell();
                cell_Id.Value = l_Eleve.Id;
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

                // Adresse
                DataGridViewCell cell_Adresse = new DataGridViewTextBoxCell();
                cell_Adresse.Value = l_Eleve.getAdresse();
                row_Eleve.Cells.Add(cell_Adresse);

                // Créer les devoirs
                Dictionary<int, cls_Devoir> l_Devoirs = Program.Controleur.CreerDevoirs(pMatieres);

                // Créer les notes
                List<cls_Note> l_Notes = Program.Controleur.CreerNotes(l_Devoirs, Program.Modele.ListeEleves, c_Semestre1);

                foreach (cls_Matiere l_Matiere in pMatieres.Values)
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
            // Pas de lignes sélectionnées
            if (dtg_Eleves.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                      "Merci de sélectionner des élèves",
                      "Aucun élève sélectionné",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information
                      );
            }

            // Aucun dossier sélectionné
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
            // Sinon on génére les PDFs
            else
            {
                cls_Groupe l_Groupe = (cls_Groupe)cbx_ChoixGroupe.SelectedItem;

                foreach (DataGridViewRow row in dtg_Eleves.SelectedRows)
                {
                    if (row.IsNewRow != true)
                    {
                        int l_IdEleve = Convert.ToInt32(row.Cells["col_Id"].Value.ToString());
                        cls_Pdf l_Pdf = new cls_Pdf(Program.Modele.ListeEleves[l_IdEleve], c_Semestre1, c_Path);
                    }
                }

                AjouterLog(TypeLog.GenerationPDF, "Génération PDF");
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
            cls_Eleve l_EleveModifie = Program.Modele.getEleveById(l_IdEleveModifie);

            // On modifie les données en fonction de la colonne modifiée
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
            Program.Modele.ModifierEleve(l_EleveModifie);
            Program.Controleur.ModifierEleve(l_EleveModifie);

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
                case TypeLog.ChangementDossier:
                    new_Log.Text = "Changement dossier";
                    break;
                case TypeLog.ChangementGroupe:
                    new_Log.Text = "Changement groupe";
                    break;
                case TypeLog.GenerationPDF:
                    new_Log.Text = "Génération PDF";
                    break;
                case TypeLog.OuvertureDossier:
                    new_Log.Text = "Ouverture dossier";
                    break;
                default:
                    new_Log.Text = "Log";
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

        //TODO
        private void dgv_Matieres_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           /* // On n'enregistre pas les modifications sur une nouvelle ligne ou sur l'id
            if (dgv_Matieres.Rows[e.RowIndex].IsNewRow || e.ColumnIndex == 0) { return; }

            // La colonne modifiée
            string l_ColonneModifie = dgv_Matieres.Columns[e.ColumnIndex].HeaderText;

            // Id de la matière modifiée
            int l_IdMatiereModifie = Convert.ToInt32(dgv_Matieres[0, e.RowIndex].Value);

            // La matière modifiée en elle meme
            cls_Matiere l_MatiereModifie = Program.Modele.getMatiereById(l_IdMatiereModifie);*/
        }

        private void btn_AjouterMatiere_Click(object sender, EventArgs e)
        {
            frm_AjouterModifierMatiere frm_AjouterModifierMatiere = new frm_AjouterModifierMatiere();
            frm_AjouterModifierMatiere.ShowDialog();
        }

        private void btn_AjouterDevoir_Click(object sender, EventArgs e)
        {
            frm_AjouterDevoir frm_AjouterDevoir = new frm_AjouterDevoir();
            frm_AjouterDevoir.ShowDialog();
        }

        private void btn_ModifierMatiere_Click(object sender, EventArgs e)
        {
            // Récupère la matière sélectionnée
            int l_IdMatiere = Convert.ToInt32(dtg_Matieres.CurrentRow.Cells[0].Value.ToString());
            cls_Matiere l_Matiere = Program.Modele.ListeMatieres[l_IdMatiere];
            frm_AjouterModifierMatiere frm_AjouterModifierMatiere = new frm_AjouterModifierMatiere(l_Matiere);
            frm_AjouterModifierMatiere.ShowDialog();
        }
    }
}
