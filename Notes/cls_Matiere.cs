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


        public cls_Matiere(string pLibelle, cls_Groupe pGroupe, int pCoefficient, string pProfesseur)
        {
            c_Libelle = pLibelle;
            c_Groupe = pGroupe;
            pGroupe.ajouterMatiere(this);
            c_Devoirs = new List<cls_Devoir>();
            setCoefficient(pCoefficient);
            setProfesseur(pProfesseur);
        }

        public string getLibelle()
        {
            return c_Libelle;
        }

        public void setLibelle(string pLibelle)
        {
            c_Libelle = pLibelle;
        }

        public void ajouterDevoir(cls_Devoir pDevoir)
        {
            c_Devoirs.Add(pDevoir);
        }

        public List<cls_Devoir> getDevoirs()
        {
            return c_Devoirs;
        }

        public void setCoefficient(int pCoefficient)
        {
            c_Coefficient = pCoefficient;
        }

        public int getCoefficient()
        {
            return c_Coefficient;
        }

        public string getProfesseur()
        {
            return c_Professeur;
        }

        public void setProfesseur(string pProfesseur)
        {
            c_Professeur = pProfesseur;
        }
    }
}
