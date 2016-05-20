using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dll_Notes;
using Notes;

namespace form_Notes
{
    /// <summary>
    /// Fenêtre d'ajout et de modification de note
    /// </summary>
    public partial class frm_AjouterModifierNote : Form
    {
        private cls_Devoir c_Devoir;
        private cls_Eleve c_Eleve;
        private cls_Note c_Note;

        public frm_AjouterModifierNote(cls_Note pNote = null)
        {
            InitializeComponent();

            // Ajouter les élèves au combobox
            AjouterEleves();

            // Ajouter les devoirs au combobox
            AjouterDevoirs();

            // Prérempli les champs si on modifie une note
            c_Note = pNote;

            if (c_Note != null)
            {
                RemplirChamps();
            }
        }

        private void RemplirChamps()
        {
            cbx_Devoir.SelectedItem = (cls_Devoir) c_Note.getDevoir();
            cbx_Eleve.SelectedItem =(cls_Eleve) c_Note.getEleve();
            tbx_Note.Text = c_Note.getValeur().ToString();
        }

        private void btn_Valider_Click(object sender, EventArgs e)
        {
            // Vérifier les données
            if (ValiderDonnees() == true)
            {
                if (c_Devoir == null && c_Note == null && c_Eleve == null)
                {
                    // Ajouter la note dans la base
                    cls_Note l_Note = new cls_Note(Convert.ToDouble(tbx_Note.Text), (cls_Eleve)cbx_Eleve.SelectedItem,
                        (cls_Devoir) cbx_Devoir.SelectedItem, Program.Modele.Semestre, cls_Devoir.NouvelId());
                    int resultat = Program.Controleur.addNote(l_Note);
                    if (resultat == 1)
                    {
                        MessageBox.Show("Note ajoutée");
                        Form1.RafraichirDonnees();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout de la note");
                    }
                }
                else
                {
                    int l_resultat = Program.Controleur.updateNote(
                            (cls_Devoir)cbx_Devoir.SelectedItem, 
                            (cls_Eleve)cbx_Eleve.SelectedItem, 
                            Convert.ToDouble(tbx_Note.Text)
                        );

                    if (l_resultat == 1)
                    {
                        MessageBox.Show("Note modifiée");
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la modification de la note");
                    }

                    Form1.RafraichirDonnees();
                    this.Close();
                }

            }
        }

        private void AjouterEleves()
        {
            Dictionary<int, cls_Eleve> l_Eleves = Program.Modele.ListeEleves;

            foreach (cls_Eleve l_Eleve in l_Eleves.Values)
            {
                cbx_Eleve.Items.Add(l_Eleve);
            }
        }

        private void AjouterDevoirs()
        {
            Dictionary<int, cls_Devoir> l_Devoirs = Program.Modele.ListeDevoirs;

            foreach (cls_Devoir l_Devoir in l_Devoirs.Values)
            {
                cbx_Devoir.Items.Add(l_Devoir);
            }
        }

        private bool ValiderDonnees()
        {
            if (tbx_Note.Text == "")
            {
                MessageBox.Show("Vous devez entrer une note");
            }
            else
            {
                if (cbx_Devoir.SelectedItem == null)
                {
                    MessageBox.Show("Vous devez selectionner un devoir");
                }
                else
                {
                    if (cbx_Eleve.SelectedItem == null)
                    {
                        MessageBox.Show("Vous devez sélectionner un élève");
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
