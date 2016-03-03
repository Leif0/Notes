using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class cls_Groupe
    {
        private string c_Libelle;
        private List<cls_Eleve> c_ListeEleve;
        private List<cls_Matiere> c_Matieres;

        public cls_Groupe(string pLibelle)
        {
            setLibelle(pLibelle);
            c_ListeEleve = new List<cls_Eleve>();
            c_Matieres = new List<cls_Matiere>();
        }

        public void setLibelle(string pLibelle)
        {
            if (pLibelle != "")
            {
                c_Libelle = pLibelle;
            }
            else
            {
                throw new Exception("Le libelle ne peut pas être vide");
            }
            
        }

        public string getLibelle()
        {
            return c_Libelle;
        }

        public List<cls_Eleve> getListeEleve()
        {
            return c_ListeEleve;
        }

        public void ajouterEleve(cls_Eleve pEleve)
        {
            c_ListeEleve.Add(pEleve);
        }

        public void ajouterMatiere(cls_Matiere pMatiere)
        {
            c_Matieres.Add(pMatiere);
        }

        public List<cls_Matiere> getMatiere()
        {
            return c_Matieres;
        }

        public double MoyenneGroupePourMatiere(cls_Matiere pMatiere)
        {
            double cumul = 0;

            foreach (cls_Eleve eleve in c_ListeEleve)
            {
                cumul += eleve.MoyenneMatiere(pMatiere);
            }
            return cumul / c_ListeEleve.Count;
        }
    }
}
