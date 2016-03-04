using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class cls_Appreciation
    {
        private string c_Texte;
        private cls_Eleve c_Eleve;
        private cls_Matiere c_Matiere;

        public cls_Appreciation(string pTexte, cls_Eleve pEleve, cls_Matiere pMatiere)
        {
            setTexte(pTexte);
            setEleve(pEleve);
            setMatiere(pMatiere);
            pEleve.ajouterAppreciation(this);
        }

        public void setTexte(string pTexte)
        {
            c_Texte = pTexte;
        }

        public string getTexte()
        {
            return c_Texte;
        }

        public void setEleve(cls_Eleve pEleve)
        {
            c_Eleve = pEleve;
        }

        public cls_Eleve getEleve()
        {
            return c_Eleve;
        }

        public void setMatiere(cls_Matiere pMatiere)
        {
            c_Matiere = pMatiere;
        }

        public cls_Matiere getMatiere()
        {
            return c_Matiere;
        }
    }
}
