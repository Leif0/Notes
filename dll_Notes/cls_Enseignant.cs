using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes;

namespace dll_Notes
{
    public class cls_Enseignant : cls_ObjetBase
    {
        private string c_Nom;
        private string c_Prenom;
        private DateTime c_DateEntree;
        private string c_NumeroTelephone;
        private string c_Email;

        public cls_Enseignant(string pNom, string pPrenom, DateTime pDateEntree, string pNumeroTelephone, string pEmail,
            int pId) : base(pId)
        {
            c_Nom = pNom;
            c_Prenom = pPrenom;
            c_DateEntree = pDateEntree;
            c_NumeroTelephone = pNumeroTelephone;
            c_Email = pEmail;
        }

        /// <summary>
        /// Nom de l'enseignant, ne peut être null ou vide
        /// </summary>
        public string Nom
        {
            get
            {
                if (c_Nom != null && c_Nom != "")
                {
                    return c_Nom;
                }
                else
                {
                    throw new Exception("Nom ne peut être nul ou vide");
                }
            }
        }

        /// <summary>
        /// Prénom de l'enseignant, ne peut être null ou vide
        /// </summary>
        public string Prenom
        {
            get
            {
                if (c_Prenom != null && c_Prenom != "")
                {
                    return c_Prenom;
                }
                else
                {
                    throw new Exception("Prénom ne peut être nul ou vide");
                }
            }
        }

        /// <summary>
        /// Date d'entrée dans l'établissement
        /// Ne peut être null ou vide
        /// </summary>
        public DateTime DateEntree
        {
            get
            {
                if (c_DateEntree != null && c_DateEntree != DateTime.MinValue)
                {
                    return c_DateEntree;
                }
                else
                {
                    throw new Exception("Date d'entrée est vide ou nul");
                }
            }
            set
            {
                if (value != null && value != DateTime.MinValue)
                {
                    c_DateEntree = value;
                }
                else
                {
                    throw new Exception("Date d'entrée ne peut être null ou vide");
                }
            }
        }

        /// <summary>
        /// Numéro de téléphone de l'enseignant
        /// </summary>
        public string NumeroTelephone
        {
            get { return c_NumeroTelephone; }
            set { c_NumeroTelephone = value; }
        }

        /// <summary>
        /// Adresse email de l'enseignant
        /// </summary>
        public string Email
        {
            get { return c_Email; }
            set { c_Email = value; }
        }

        /// <summary>
        /// Retourne l'ancienneté en années
        /// </summary>
        public int getAnciennete()
        {
            DateTime l_Maintenant = DateTime.Now;
            int l_AncienneteEnJours = (l_Maintenant - this.DateEntree).Days;
            int l_AncienneteEnAnnees = l_AncienneteEnJours/365;

            return l_AncienneteEnAnnees;
        }

        /// <summary>
        /// Override de la méthode toString permetant l'affichage du nom, du prénom et du numéro de téléphone
        /// </summary>
        /// <returns>Nom Prénom (Numéro de téléphone)</returns>
        public override string ToString()
        {
            return this.Nom + " " + this.Prenom + " (" + this.NumeroTelephone + ")";
        }
    }
}
