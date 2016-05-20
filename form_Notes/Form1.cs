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
    /// <summary>
    /// Fenêtre principale du programme
    /// </summary>
    public partial class Form1 : Form
    {
        // Chemin de sauvegarde des PDFs
        public string c_Path { get; set; }

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

            // Cache tous les boutons puis affiche uniquement les boutons des élèves
            CacherBoutons();

            btn_SelectionnerTout.Show();
            btn_ModifierEleve.Show();
            btn_AjouterEleve.Show();

            // Déplace les boutons au bon endroit
            PlacerBoutons();

            // Créer les enseignants
            Program.Modele.ListeEnseignants = Program.Controleur.CreerEnseignants();

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
        private void btn_OuvrirDossier_Click_1(object sender, EventArgs e)
        {
            // Si le chemin existe
            if (c_Path != null)
            {
                // Ouvre l'explorateur
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = c_Path,
                    UseShellExecute = true,
                    Verb = "open"
                });

                // Ajoute un log

                AjouterLog(TypeLog.OuvertureDossier, "Ouverture du dossier de sauvegarde des PDFs");
            }
            else
            {
                // L'utilisateur n'a pas choisis de dossier
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
        private void btn_ChoixDossier_MouseEnter(object sender, EventArgs e)
        {
            lbl_Emplacement.Show();
        }

        /// <summary>
        /// Cache l'emplacement de sauvegarde des PDFs
        /// </summary>
        private void btn_ChoixDossier_MouseLeave(object sender, EventArgs e)
        {
            lbl_Emplacement.Hide();
        }

        /// <summary>
        /// Procédure lancée lors de la selection d'un groupe
        /// </summary>
        private void cbx_ChoixGroupe_SelectedValueChanged(object sender, EventArgs e)
        {
            AjouterLog(TypeLog.ChangementGroupe, 
                       "Changement du groupe actif : " + cbx_ChoixGroupe.SelectedValue);

            RafraichirDonnees();
        }

        /// <summary>
        /// Rafraichie toutes les données du formulaire principale (data grid views)
        /// TODO : régler la duplication des données
        /// </summary>
        public static void RafraichirDonnees()
        {

            // Référence vers la fenetre

            Form1 l_Form = (Form1)Application.OpenForms["Form1"];

            // Remise à zéro des data grid views

            DataGridView[] l_DataGridViews =
            {
                l_Form.dgv_Eleves,
                l_Form.dgv_Matieres,
                l_Form.dgv_Devoirs,
                l_Form.dgv_Notes
            };

            foreach (DataGridView l_Control in l_DataGridViews)
            {
                l_Control.Rows.Clear();
                l_Control.Columns.Clear();
            }

            // Récupère le groupe sélectionné
            cls_Groupe l_Groupe = (cls_Groupe)l_Form.cbx_ChoixGroupe.SelectedItem;

            // Créer les élèves
            Program.Modele.ListeEleves = Program.Controleur.CreerEleves(l_Groupe);

            // Les matières
            Program.Modele.ListeMatieres = Program.Controleur.CreerMatieres(l_Groupe);

            // Créer la liste des devoirs
            Program.Modele.ListeDevoirs = Program.Controleur.CreerDevoirs(Program.Modele.ListeMatieres);

            // Créer les notes
            List < cls_Note > l_Notes = Program.Controleur.CreerNotes(Program.Modele.ListeDevoirs, Program.Modele.ListeEleves, Program.Modele.Semestre);

            // Ajoute les colonnes des élèves
            l_Form.AjouterColonnes(Program.Modele.ListeMatieres);

            // Ajoute les lignes des élèves au tableau
            l_Form.AjouterLignesEleves(Program.Modele.ListeEleves.Values, Program.Modele.ListeMatieres);

            // Ajoute la liste des devoirs
            l_Form.AjouterColonnesDevoirs(Program.Modele.ListeDevoirs);

            // Ajoute les lignes des devoirs
            l_Form.AjouterLignesDevoirs(Program.Modele.ListeDevoirs.Values);

            // Ajoute les colonnes des matières
            l_Form.AjouterColonnesMatieres(Program.Modele.ListeMatieres);

            // Ajoute les lignes des matières
            l_Form.AjouterLignesMatieres(Program.Modele.ListeMatieres);

            // Ajoute les colonnes des notes
            l_Form.AjouterColonnesNotes();

            // Ajoute les notes au data grid view des notes
            l_Form.AjouterLignesNotes(l_Notes);

            // Tri par ID des colonnes
            l_Form.TrierColonnesParId();
        }

        /// <summary>
        /// Ajoute les colonnes au tableau d'élèves
        /// </summary>
        /// <param name="pMatiere">Liste des matières</param>
        private void AjouterColonnes(Dictionary<int, cls_Matiere> pMatiere)
        {
            dgv_Eleves.Columns.Add("col_Id", "Id");
            dgv_Eleves.Columns[0].ReadOnly = true; // Impossible de modifier l'id d'un élève
            dgv_Eleves.Columns.Add("col_Nom", "Nom");
            dgv_Eleves.Columns.Add("col_Prenom", "Prénom");
            dgv_Eleves.Columns.Add("col_DateNaissance", "Date de naissance");
            dgv_Eleves.Columns.Add("col_Adresse", "Adresse");

            foreach (cls_Matiere l_Matiere in pMatiere.Values)
            {
                dgv_Eleves.Columns.Add(l_Matiere.Libelle, l_Matiere.Libelle);
            }
        }

        /// <summary>
        /// Ajoute les colonnes des devoirs
        /// </summary>
        /// <param name="pDevoir">Dictionnaire de devoirs</param>
        private void AjouterColonnesDevoirs(Dictionary<int, cls_Devoir> pDevoir)
        {
            dgv_Devoirs.Columns.Add("col_Id", "Id");
            dgv_Devoirs.Columns.Add("col_Libelle", "Libellé");
            dgv_Devoirs.Columns.Add("col_DateDevoir", "Date");
            dgv_Devoirs.Columns.Add("col_IdMatiere", "Matière");
        }

        /// <summary>
        /// Ajoute les colonnes des matières
        /// </summary>
        /// <param name="pMatieres">Dictionnaire de matières</param>
        private void AjouterColonnesMatieres(Dictionary<int, cls_Matiere> pMatieres)
        {
            dgv_Matieres.Columns.Add("col_Id", "Id");
            dgv_Matieres.Columns.Add("col_Libelle", "Libellé");
            dgv_Matieres.Columns.Add("col_Groupe", "Groupe");
            dgv_Matieres.Columns.Add("col_Coefficient", "Coefficient");
            dgv_Matieres.Columns.Add("col_Professeur", "Professeur");
        }

        /// <summary>
        /// Ajoute les colonnes des notes
        /// </summary>
        private void AjouterColonnesNotes()
        {
            dgv_Notes.Columns.Add("col_LibelleDevoir", "Devoir");
            dgv_Notes.Columns.Add("col_Eleve", "Élève");
            dgv_Notes.Columns.Add("col_Note", "Note");
        }

        /// <summary>
        /// Ajouter les lignes des notes au data grid view
        /// </summary>
        /// <param name="pNotes">Liste de notes</param>
        private void AjouterLignesNotes(List<cls_Note> pNotes)
        {
            foreach (cls_Note l_Note in pNotes)
            {
                DataGridViewRow row_Note = new DataGridViewRow();

                // Libellé Devoir
                DataGridViewCell cell_LibelleDevoir = new DataGridViewTextBoxCell();
                cell_LibelleDevoir.Value = l_Note.getDevoir();
                row_Note.Cells.Add(cell_LibelleDevoir);

                // Élève
                DataGridViewCell cell_Eleve = new DataGridViewTextBoxCell();
                cell_Eleve.Value = l_Note.getEleve();
                row_Note.Cells.Add(cell_Eleve);

                // Note de l'élève pour ce devoir
                DataGridViewCell cell_NoteValeur = new DataGridViewTextBoxCell();
                cell_NoteValeur.Value = l_Note;
                row_Note.Cells.Add(cell_NoteValeur);

                // Ajout de la ligne au DataGridView
                dgv_Notes.Rows.Add(row_Note);
            }
        }

        /// <summary>
        /// Ajoute les lignes des matières au DataGridView
        /// </summary>
        /// <param name="pMatieres">Dictionnaire des matières</param>
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

                // Ajoute la ligne au DataGridView
                dgv_Matieres.Rows.Add(row_Matiere);
            }
        }

        /// <summary>
        /// Ajoute les lignes des devoirs au datagridview
        /// </summary>
        /// <param name="pDevoirs">Dictionnaire de devoirs</param>
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
                cell_Libelle.Value = l_Devoir.Libelle;
                row_Devoir.Cells.Add(cell_Libelle);

                // Date
                DataGridViewCell cell_DateDevoir = new DataGridViewTextBoxCell();
                cell_DateDevoir.Value = l_Devoir.getDateDevoir();
                row_Devoir.Cells.Add(cell_DateDevoir);

                // Id matiere
                DataGridViewCell cell_Matiere = new DataGridViewTextBoxCell();
                cell_Matiere.Value = l_Devoir.getMatiere().ToString();
                row_Devoir.Cells.Add(cell_Matiere);

                // Ajoute la ligne au DataGridView
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
                cell_DateNaissance.Value = String.Format("{0:d}", l_Eleve.getDateNaissance());
                row_Eleve.Cells.Add(cell_DateNaissance);

                // Adresse
                DataGridViewCell cell_Adresse = new DataGridViewTextBoxCell();
                cell_Adresse.Value = l_Eleve.getAdresse();
                row_Eleve.Cells.Add(cell_Adresse);

                foreach (cls_Matiere l_Matiere in pMatieres.Values)
                {
                    // La moyenne
                    DataGridViewCell cell_Matiere = new DataGridViewTextBoxCell();
                    double l_MoyenneEleve = l_Eleve.MoyenneMatiereSemestre(l_Matiere, Program.Modele.Semestre);

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
                dgv_Eleves.Rows.Add(row_Eleve);
            }
        }

        /// <summary>
        /// Clic sur le bouton Générer PDF
        /// </summary>
        private void btn_Generer_Click(object sender, EventArgs e)
        {
            // Pas de lignes sélectionnées
            if (dgv_Eleves.SelectedRows.Count == 0)
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

                foreach (DataGridViewRow row in dgv_Eleves.SelectedRows)
                {
                    if (row.IsNewRow != true)
                    {
                        int l_IdEleve = Convert.ToInt32(row.Cells["col_Id"].Value.ToString());
                        cls_Pdf l_Pdf = new cls_Pdf(Program.Modele.ListeEleves[l_IdEleve], Program.Modele.Semestre, c_Path);
                    }
                }

                AjouterLog(TypeLog.GenerationPDF, "Génération PDF");
            }
        }

        /// <summary>
        /// Sélectionne tous les élèves
        /// </summary>
        private void btn_SelectionnerTout_Click(object sender, EventArgs e)
        {
            dgv_Eleves.SelectAll();
        }
        /// <summary>
        /// Validation d'une cellule lorsqu'elle est modifiée
        /// </summary>
        private void dtg_Eleves_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // On n'enregistre pas les modifications sur une nouvelle ligne ou sur l'id
            if (dgv_Eleves.Rows[e.RowIndex].IsNewRow || e.ColumnIndex == 0) {return;}

            // La colonne modifiée
            string l_ColonneModifie = dgv_Eleves.Columns[e.ColumnIndex].HeaderText;

            // Id de l'élève modifié
            int l_IdEleveModifie = Convert.ToInt32(dgv_Eleves[0, e.RowIndex].Value);

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

        /// <summary>
        /// Clic sur le bouton d'ajout de matière
        /// </summary>
        private void btn_AjouterMatiere_Click(object sender, EventArgs e)
        {
            if (UnGroupeEstSelectionne())
            {
                frm_AjouterModifierMatiere frm_AjouterModifierMatiere = new frm_AjouterModifierMatiere();
                frm_AjouterModifierMatiere.ShowDialog();
            }
        }

        /// <summary>
        /// Clic sur le bouton d'ajout de devoir
        /// </summary>
        private void btn_AjouterDevoir_Click(object sender, EventArgs e)
        {
            if (UnGroupeEstSelectionne())
            {
                frm_AjouterModifierDevoir frm_AjouterModifierDevoir = new frm_AjouterModifierDevoir();
                frm_AjouterModifierDevoir.ShowDialog();
            }
        }

        private void btn_ModifierMatiere_Click(object sender, EventArgs e)
        {
            // Récupère la matière sélectionnée
            try
            {
                int l_IdMatiere = Convert.ToInt32(dgv_Matieres.CurrentRow.Cells[0].Value.ToString());
                cls_Matiere l_Matiere = Program.Modele.ListeMatieres[l_IdMatiere];

                // Affiche la fenetre
                frm_AjouterModifierMatiere frm_AjouterModifierMatiere = new frm_AjouterModifierMatiere(l_Matiere);
                frm_AjouterModifierMatiere.ShowDialog();
            }
            catch (Exception erreur)
            {
                MessageBox.Show("Erreur : " + erreur.Message);
            }
        }

        /// <summary>
        /// Clic sur le bouton modifier devoir
        /// </summary>
        private void btn_ModifierDevoir_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupère le devoir sélectionné
                int l_IdDevoir = Convert.ToInt32(dgv_Devoirs.CurrentRow.Cells[0].Value.ToString());
                cls_Devoir l_Devoir = Program.Modele.getDevoirById(l_IdDevoir);

                // Affiche la fenetre d'ajout/modification
                frm_AjouterModifierDevoir frm_AjouterModifierDevoir = new frm_AjouterModifierDevoir(l_Devoir);
                frm_AjouterModifierDevoir.ShowDialog();
            }
            catch (Exception erreur)
            {
                MessageBox.Show("Erreur : " + erreur.Message);
            }
        }

        /// <summary>
        /// Evenement lors d'un changement d'onglet
        /// On cache tous les boutons puis on affiche ceux qui correspondent à l'onglet
        /// </summary>
        private void tc_ElevesDevoirs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // On cache tous les boutons
            CacherBoutons();

            // Boutons qui correspondent à chaque onglet

            // Boutons onglet "Élèves"
            Button[] l_BoutonsEleves =
            {
                btn_SelectionnerTout,
                btn_AjouterEleve,
                btn_ModifierEleve
            };

            // Boutons onglet "Matières"
            Button[] l_BoutonsMatieres =
            {
                btn_AjouterMatiere,
                btn_ModifierMatiere,
                btn_SupprimerMatiere
            };

            // Boutons onglet "Devoirs"
            Button[] l_BoutonsDevoirs =
            {
                btn_AjouterDevoir,
                btn_ModifierDevoir
            };

            // Boutons onglet "Notes"
            Button[] l_BoutonsNotes =
            {
                btn_AjouterNote,
                btn_ModifierNote,
                btn_SupprimerNote
            };

            // On regarde quel onglet a été sélectionné et on affiche les boutons

            switch (tc_ElevesDevoirs.SelectedTab.Text)
            {
                case "Élèves":
                    foreach (Button l_Button in l_BoutonsEleves)
                    {
                        l_Button.Show();
                    }
                break;

                case "Devoirs":
                    foreach (Button l_Button in l_BoutonsDevoirs)
                    {
                        l_Button.Show();
                    }
                    break;

                case "Matières":
                    foreach (Button l_Button in l_BoutonsMatieres)
                    {
                        l_Button.Show();
                    }
                    break;

                case "Notes":
                    foreach (Button l_Button in l_BoutonsNotes)
                    {
                        l_Button.Show();
                    }
                    break;
            }
        }

        /// <summary>
        /// Tri des colonnes par l'id
        /// </summary>
        private void TrierColonnesParId()
        {
            dgv_Matieres.Sort(dgv_Matieres.Columns[0], ListSortDirection.Ascending);
            dgv_Devoirs.Sort(dgv_Devoirs.Columns[0], ListSortDirection.Ascending);
            dgv_Eleves.Sort(dgv_Eleves.Columns[0], ListSortDirection.Ascending);
            dgv_Notes.Sort(dgv_Notes.Columns[0], ListSortDirection.Ascending);
        }

        /// <summary>
        /// Cache tous les boutons
        /// </summary>
        private void CacherBoutons()
        {
            btn_SelectionnerTout.Hide();
            btn_AjouterMatiere.Hide();
            btn_ModifierMatiere.Hide();
            btn_AjouterDevoir.Hide();
            btn_ModifierDevoir.Hide();
            btn_AjouterEleve.Hide();
            btn_ModifierEleve.Hide();
            btn_AjouterNote.Hide();
            btn_ModifierNote.Hide();
            btn_SupprimerNote.Hide();
            btn_SupprimerMatiere.Hide();
        }

        /// <summary>
        /// Place les boutons l'un en dessous de l'autre à la bonne place
        /// </summary>
        private void PlacerBoutons()
        {
            Array[] Boutons =
            {
                // Boutons en première position
                new Button[]
                {
                    btn_SelectionnerTout,
                    btn_AjouterMatiere,
                    btn_AjouterDevoir,
                    btn_AjouterNote
                },
                // Boutons en deuxième position
                new Button[]
                {
                    btn_ModifierMatiere,
                    btn_ModifierDevoir,
                    btn_AjouterEleve,
                    btn_ModifierNote
                },
                // Boutons en troisième position
                new Button[]
                {
                    btn_ModifierEleve,
                    btn_SupprimerNote,
                    btn_SupprimerMatiere
                }
            };

            // Pour chaque tableau de bouton, on regarde l'index
            // En index 0, on met une position Y
            // En index 1, une position un peu plus basse, etc.

            int i = 0;
            foreach (Button[] l_ArrayBoutons in Boutons)
            {
                Point l_Location = new Point();
                l_Location.X = 719;

                switch (i)
                {
                    case 0:
                        l_Location.Y = 120;
                        break;
                    case 1:
                        l_Location.Y = 180;
                        break;
                    case 2:
                        l_Location.Y = 230;
                        break;
                }

                // On assigne la position au bouton

                for (int j = 0; j < l_ArrayBoutons.Length; j++)
                {
                    l_ArrayBoutons[j].Location = l_Location;
                }

                i++;
            }
        }

        /// <summary>
        /// Clic sur le bouton ajouter élève
        /// </summary>
        private void btn_AjouterEleve_Click(object sender, EventArgs e)
        {
            if (UnGroupeEstSelectionne())
            {
                frm_AjouterModifierEleve l_frm_AjouterModifierEleve = new frm_AjouterModifierEleve();
                l_frm_AjouterModifierEleve.ShowDialog();
            }
        }

        /// <summary>
        /// Clic sur le bouton modifier eleve
        /// </summary>
        private void btn_ModifierEleve_Click(object sender, EventArgs e)
        {
            if (dgv_Eleves.Rows.Count > 0)
            {
                cls_Eleve l_Eleve = Program.Modele.getEleveById(Convert.ToInt32(dgv_Eleves.CurrentRow.Cells[0].Value));
                frm_AjouterModifierEleve l_frm_AjouterModifierEleve = new frm_AjouterModifierEleve(l_Eleve);
                l_frm_AjouterModifierEleve.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vous devez charger un groupe et sélectionner un élève");
            }

        }

        /// <summary>
        /// Clic sur le bouton ajouter noter
        /// </summary>
        private void btn_AjouterNote_Click(object sender, EventArgs e)
        {
            if (UnGroupeEstSelectionne())
            {
                frm_AjouterModifierNote l_frm_AjouterModifierNote = new frm_AjouterModifierNote();
                l_frm_AjouterModifierNote.ShowDialog();
            }
        }

        /// <summary>
        /// Clic sur le bouton modifier note
        /// </summary>
        private void btn_ModifierNote_Click(object sender, EventArgs e)
        {
            if (UnGroupeEstSelectionne())
            {
                cls_Note l_Note = (cls_Note) dgv_Notes.CurrentRow.Cells[2].Value;

                frm_AjouterModifierNote l_frm_AjouterModifierNote = new frm_AjouterModifierNote(l_Note);
                l_frm_AjouterModifierNote.ShowDialog();
            }
        }


        /// <summary>
        /// Vérifie qu'un groupe est bien selectionné
        /// </summary>
        /// <returns>Boolean</returns>
        private bool UnGroupeEstSelectionne()
        {
            if (cbx_ChoixGroupe.SelectedItem == null)
            {
                MessageBox.Show("Vous devez séléctionner un groupe !");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Clic sur le bouton supprimer note
        /// </summary>
        private void btn_SupprimerNote_Click(object sender, EventArgs e)
        {
            if (UnGroupeEstSelectionne() && dgv_Notes.CurrentRow != null)
            {
                cls_Note l_Note = (cls_Note)dgv_Notes.CurrentRow.Cells[2].Value;

                if (l_Note != null)
                {
                    int l_Resultat = Program.Controleur.supprimerNote(l_Note);

                    if (l_Resultat == 1)
                    {
                        MessageBox.Show("Note supprimée");
                        Form1.RafraichirDonnees();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la suppression de la note");
                    }
                }
                else
                {
                    MessageBox.Show("Aucune note selectionnée !");
                }
            }
        }

        /// <summary>
        /// Clic sur le bouton supprimer une matière
        /// </summary>
        private void btn_SupprimerMatiere_Click_1(object sender, EventArgs e)
        {
            if (UnGroupeEstSelectionne() && dgv_Matieres.CurrentRow != null)
            {
                // Récupère la matière selectionnée
                cls_Matiere l_Matiere = Program.Modele.getMatiereById(Convert.ToInt32(dgv_Matieres.CurrentRow.Cells[0].Value));

                if (l_Matiere != null)
                {
                    if (l_Matiere.getDevoirs().Count != 0)
                    {
                        MessageBox.Show("Impossible de supprimer une matière contenant des devoirs");
                    }
                    else
                    {
                        int l_Resultat = Program.Controleur.supprimerMatiere(l_Matiere);

                        if (l_Resultat == 1)
                        {
                            MessageBox.Show("Matière supprimée");
                            Form1.RafraichirDonnees();
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de la suppression de la matière");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Aucune matière selectionnée !");
                }
            }
        }

        /// <summary>
        /// Clic sur le bouton liste enseignants
        /// </summary>
        private void btn_ListeEnseignants_Click(object sender, EventArgs e)
        {
            frm_ListeEnseignants l_Frm_ListeEnseignants = new frm_ListeEnseignants();
            l_Frm_ListeEnseignants.ShowDialog();
        }
    }
}
