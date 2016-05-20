using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Notes;

namespace form_Notes
{
    /// <summary>
    /// Fenêtre d'ajout et de modification de'élève
    /// </summary>
    public partial class frm_AjouterModifierEleve : Form
    {
        private cls_Eleve c_Eleve;

        public frm_AjouterModifierEleve(cls_Eleve pEleve = null)
        {
            InitializeComponent();

            foreach (cls_Groupe l_Groupe in Program.Modele.ListeGroupes.Values)
            {
                cbx_Groupe.Items.Add(l_Groupe);
            }

            if (pEleve != null)
            {
                c_Eleve = pEleve;
                RemplirChamps();
            }
        }

        private void RemplirChamps()
        {
            tbx_Nom.Text = c_Eleve.getNom();
            tbx_Prenom.Text = c_Eleve.getPrenom();
            dtp_DateDeNaissance.Value = c_Eleve.getDateNaissance();
            cbx_Groupe.SelectedItem = c_Eleve.getGroupe();
            rtb_Adresse.Text = c_Eleve.getAdresse();
        }

        private void btn_Valider_Click(object sender, EventArgs e)
        {
            // Si la saisie est valide (aucun champ vide)
            if (SaisieValide())
            {
                // On met à jour dans la base
                if (c_Eleve != null)
                {
                    // Récupération de la saisie
                    c_Eleve.setNom(tbx_Nom.Text);
                    c_Eleve.setPrenom(tbx_Prenom.Text);
                    c_Eleve.setDateNaissance(dtp_DateDeNaissance.Value);
                    c_Eleve.setGroupe((cls_Groupe)cbx_Groupe.SelectedItem);
                    c_Eleve.setAdresse(rtb_Adresse.Text);

                    int resultat = Program.Controleur.updateEleve(c_Eleve);

                    Form1.RafraichirDonnees();
                    this.Close();
                }
                // On créer l'élève
                else
                {
                    cls_Eleve l_Eleve = new cls_Eleve(tbx_Nom.Text, tbx_Prenom.Text, dtp_DateDeNaissance.Value, (cls_Groupe)cbx_Groupe.SelectedItem, rtb_Adresse.Text, cls_Eleve.NouvelId());
                    Program.Controleur.addEleve(l_Eleve);
                    Form1.RafraichirDonnees();
                    this.Close();
                }
            }
        }

        private bool SaisieValide()
        {
            if (tbx_Nom.Text.Trim() != "" && tbx_Prenom.Text.Trim() != "")
            {
                if (dtp_DateDeNaissance.Value != null && dtp_DateDeNaissance.Value.GetType() == typeof(DateTime))
                {
                    if (cbx_Groupe.SelectedIndex != -1)
                    {
                        if (rtb_Adresse.Text.Trim() != "")
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Vous devez indiquer une adresse !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez sélectionner un groupe");
                    }
                }
                else
                {
                    MessageBox.Show("Date de naissance incorrecte");
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom et un prénom");
            }
            return false;
        }
    }
}
