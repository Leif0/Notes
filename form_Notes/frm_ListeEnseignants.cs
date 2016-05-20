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

namespace form_Notes
{
    /// <summary>
    /// Fenêtre affichant la liste des enseignants de l'établissement
    /// </summary>
    public partial class frm_ListeEnseignants : Form
    {
        public frm_ListeEnseignants()
        {
            InitializeComponent();
            RemplirComboBox();
        }

        /// <summary>
        /// Met les enseignants dans le combobox
        /// </summary>
        private void RemplirComboBox()
        {
            foreach (cls_Enseignant l_Enseignant in Program.Modele.ListeEnseignants.Values)
            {
                cbx_Enseignants.Items.Add(l_Enseignant);
            }
        }

        /// <summary>
        /// Lorsque l'enseignant est selectionné, on remplie les champs
        /// </summary>
        private void cbx_Enseignants_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Récupère l'enseignant choisis
            cls_Enseignant l_Enseignant = (cls_Enseignant) cbx_Enseignants.SelectedItem;

            // Remplis les champs d'information
            tbx_Email.Text = l_Enseignant.Email;
            dtp_DateEntree.Value = l_Enseignant.DateEntree;

            // Ancienneté

            int l_Anciennete = l_Enseignant.getAnciennete();
            tbx_Anciennete.Text = Convert.ToString(l_Anciennete + " année");

            // On ajoute un "s" si il a plusieurs années
            if (l_Anciennete >= 2)
            {
                tbx_Anciennete.Text += 's';
            }
        }
    }
}
