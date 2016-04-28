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
    public partial class frm_AjouterDevoir : Form
    {

        public frm_AjouterDevoir()
        {
            InitializeComponent();

            // Ajouter les matières au combobox
            AjouterMatieres();
        }

        private void btn_Valider_Click(object sender, EventArgs e)
        {
            // Vérifier les données
            if (ValiderDonnees() == true)
            {
                // Ajouter le devoir dans la base
                cls_Devoir l_Devoir = new cls_Devoir(tbx_Libelle.Text, dtp_DateDevoir.Value, (cls_Matiere) cbx_Matiere.SelectedItem, cls_Devoir.NouvelId());
                Program.Controleur.addDevoir(l_Devoir);
            }
        }

        private void AjouterMatieres()
        {
            Dictionary<int, cls_Matiere> l_Matieres = Program.Modele.ListeMatieres;

            foreach (cls_Matiere l_Matiere in l_Matieres.Values)
            {
                cbx_Matiere.Items.Add(l_Matiere);
            }
        }

        private bool ValiderDonnees()
        {
            if (tbx_Libelle.Text == "")
            {
                MessageBox.Show("Vous devez spécifier un libellé");
            }
            else
            {
                if (dtp_DateDevoir.Value.Date == null)
                {
                    MessageBox.Show("Vous devez spécifier une date");
                }
                else
                {
                    if (cbx_Matiere.SelectedItem == null || cbx_Matiere.SelectedItem == "")
                    {
                        MessageBox.Show("Vous devez spécifier une matière");
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
