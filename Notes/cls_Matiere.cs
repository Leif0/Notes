using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class cls_Matiere
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
        public cls_Matiere(string pLibelle, cls_Groupe pGroupe, int pCoefficient, string pProfesseur)
        {
            c_Libelle = pLibelle;
            c_Groupe = pGroupe;
            pGroupe.ajouterMatiere(this);
            c_Devoirs = new List<cls_Devoir>();
            setCoefficient(pCoefficient);
            setProfesseur(pProfesseur);
        }

        /// <summary>
        /// Retourne le libellé de la matière
        /// </summary>
        /// <returns>Libellé de la matière</returns>
        public string getLibelle()
        {
            return c_Libelle;
        }

        /// <summary>
        /// Modifie le libellé de la matière
        /// </summary>
        /// <param name="pLibelle">Libellé de la matière</param>
        public void setLibelle(string pLibelle)
        {
            c_Libelle = pLibelle;
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

        /// <summary>
        /// Modifie le coefficient de la matière
        /// </summary>
        /// <param name="pCoefficient">Coefficient de la matière</param>
        public void setCoefficient(int pCoefficient)
        {
            c_Coefficient = pCoefficient;
        }

        /// <summary>
        /// Retourne le coefficient de la matière
        /// </summary>
        /// <returns>Coefficient de la matière</returns>
        public int getCoefficient()
        {
            return c_Coefficient;
        }

        /// <summary>
        /// Retourne le professeur qui enseigne la matière
        /// </summary>
        /// <returns>Professeur qui enseigne la matière</returns>
        public string getProfesseur()
        {
            return c_Professeur;
        }

        /// <summary>
        /// Modifie le professeur qui enseigne la matière
        /// </summary>
        /// <param name="pProfesseur">Professeur qui enseigne la matière</param>
        public void setProfesseur(string pProfesseur)
        {
            c_Professeur = pProfesseur;
        }
    }
}
