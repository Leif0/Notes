using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class cls_Matiere : cls_ObjetBase
    {
        private string c_Libelle;
        private cls_Groupe c_Groupe;
        private List<cls_Devoir> c_Devoirs;
        private int c_Coefficient;
        private string c_Professeur;

        /// <summary>
        /// Créer une nouvelle matière
        /// </summary>
        /// <param name="pLibelle">Libellé de la matière</param>
        /// <param name="pGroupe">Groupe de la matière</param>
        /// <param name="pCoefficient">Coefficient de la matière</param>
        /// <param name="pProfesseur">Professeur qui enseigne cette matière</param>
        public cls_Matiere(string pLibelle, cls_Groupe pGroupe, int pCoefficient, string pProfesseur, int pId):base(pId)
        {
            c_Libelle = pLibelle;
            c_Groupe = pGroupe;
            pGroupe.ajouterMatiere(this);
            c_Devoirs = new List<cls_Devoir>();
            c_Coefficient = pCoefficient;
            c_Professeur = pProfesseur;
        }

        public string Libelle
        {
            get { return c_Libelle; }
            set { c_Libelle = value; }
        }

        public int Coefficient
        {
            get { return c_Coefficient; }
            set { c_Coefficient = value; }
        }

        public string Professeur
        {
            get { return c_Professeur; }
            set { c_Professeur = value; }
        }

        public cls_Groupe Groupe
        {
            get { return c_Groupe; }
            set { c_Groupe = value; }
        }

        /// <summary>
        /// Ajoute un devoir à la matière
        /// </summary>
        /// <param name="pDevoir">Devoir à ajouter</param>
        public void ajouterDevoir(cls_Devoir pDevoir)
        {
            c_Devoirs.Add(pDevoir);
        }

        /// <summary>
        /// Retourne la liste des devoirs de la matière
        /// </summary>
        /// <returns>Liste des devoirs de la matière</returns>
        public List<cls_Devoir> getDevoirs()
        {
            return c_Devoirs;
        }

        public override string ToString()
        {
            return c_Libelle;
        }
    }
}
