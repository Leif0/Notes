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
    public partial class frm_AjouterModifierDevoir : Form
    {
        private cls_Devoir c_Devoir;

        public frm_AjouterModifierDevoir(cls_Devoir pDevoir = null)
        {
            InitializeComponent();

            // Ajouter les matières au combobox
            AjouterMatieres();

            // Remplir les champs si on modifie un devoir
            if (pDevoir != null)
            {
                c_Devoir = pDevoir;
                RemplirChamps();
            }
        }

        private void RemplirChamps()
        {
            tbx_Libelle.Text = c_Devoir.Libelle;
            dtp_DateDevoir.Value = c_Devoir.getDateDevoir();
            cbx_Matiere.SelectedItem = c_Devoir.getMatiere();
        }

        private void btn_Valider_Click(object sender, EventArgs e)
        {
            // Vérifier les données
            if (ValiderDonnees() == true)
            {
                if (c_Devoir == null)
                {
                    // Ajouter le devoir dans la base
                    cls_Devoir l_Devoir = new cls_Devoir(tbx_Libelle.Text, dtp_DateDevoir.Value,
                        (cls_Matiere) cbx_Matiere.SelectedItem, cls_Devoir.NouvelId());
                    Program.Controleur.addDevoir(l_Devoir);
                }
                else
                {
                    c_Devoir.Libelle = tbx_Libelle.Text;
                    c_Devoir.setDateDevoir(dtp_DateDevoir.Value);
                    c_Devoir.setMatiere((cls_Matiere)cbx_Matiere.SelectedItem);

                    Program.Controleur.updateDevoir(c_Devoir);

                    Form1.RafraichirDonnees();
                    this.Close();
                }

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
                    if (cbx_Matiere.SelectedItem == null)
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
