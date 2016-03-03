using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class cls_Devoir
    {
        private string c_Libelle;
        private DateTime c_DateDevoir;
        private cls_Matiere c_Matiere;
        private List<cls_Note> c_Notes;

        public cls_Devoir(string pLibelle, DateTime pDateDevoir, cls_Matiere pMatiere)
        {
            c_Libelle = pLibelle;
            c_DateDevoir = pDateDevoir;
            c_Matiere = pMatiere;
            c_Notes = new List<cls_Note>();
        }

        public string getLibelle()
        {
            return c_Libelle;
        }

        public void setLibelle(string pLibelle)
        {
            c_Libelle = pLibelle;
        }

        public cls_Matiere getMatiere()
        {
            return c_Matiere;
        }

        public void setMatiere(cls_Matiere pMatiere)
        {
            c_Matiere = pMatiere;
        }

        public DateTime getDateDevoir()
        {
            return c_DateDevoir;
        }

        public void setDateDevoir(DateTime pDateDevoir)
        {
            c_DateDevoir = pDateDevoir;
        }
    }
}
