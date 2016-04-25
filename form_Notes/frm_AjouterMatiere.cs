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
    public partial class frm_AjouterMatiere : Form
    {
        private cls_Modele c_Modele;
        private cls_Base c_Controleur;

        public frm_AjouterMatiere(cls_Modele pModele, cls_Base pControleur)
        {
            InitializeComponent();

            c_Modele = pModele;
            c_Controleur = pControleur;

            foreach (cls_Groupe l_Groupe in c_Modele.ListeGroupes.Values)
            {
                cbx_Groupes.Items.Add(l_Groupe);
            }
        }

        private void btn_Valider_Click(object sender, EventArgs e)
        {
            if (ValiderDonnees())
            {
                cls_Matiere l_Matiere = new cls_Matiere(tbx_Libelle.Text, (cls_Groupe)cbx_Groupes.SelectedItem, Convert.ToInt32(tbx_Coefficient.Text), lbl_Professeur.Text, cls_Matiere.NouvelId());
                c_Controleur.addMatiere(l_Matiere);
            }
            
        }

        private bool ValiderDonnees()
        {
            int l_coefficient = Convert.ToInt32(tbx_Coefficient.Text);

            if (tbx_Libelle.Text == "")
            {
                MessageBox.Show("Vous devez specifier un libellé");
            }
            else
            {
                if (cbx_Groupes.SelectedIndex == -1)
                {
                    MessageBox.Show("Vous devez selectionner un groupe");
                }
                else
                {
                    if (l_coefficient <= 0 || l_coefficient == null)
                    {
                        MessageBox.Show("Le coefficient doit être supérieur à zéro");
                    }
                    else
                    {
                        if (lbl_Professeur.Text == "")
                        {
                            MessageBox.Show("vous devez rentrer un professeur.");
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
