using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class cls_Devoir : cls_ObjetBase
    {
        private string c_Libelle;
        private DateTime c_DateDevoir;
        private cls_Matiere c_Matiere;
        private List<cls_Note> c_Notes;

        /// <summary>
        /// Constructeur d'un devoir
        /// </summary>
        /// <param name="pLibelle">Libellé du devoir</param>
        /// <param name="pDateDevoir">Date à laquelle le devoir a eu lieu</param>
        /// <param name="pMatiere">Matière concerné par ce devoir</param>
        public cls_Devoir(string pLibelle, DateTime pDateDevoir, cls_Matiere pMatiere, int pId):base(pId)
        {
            c_Libelle = pLibelle;
            c_DateDevoir = pDateDevoir;
            c_Matiere = pMatiere;
            c_Notes = new List<cls_Note>();
        }

        public string Libelle
        {
            get { return c_Libelle; }
            set { c_Libelle = value; }
        }

        /// <summary>
        /// Retourne la matière du devoir
        /// </summary>
        /// <returns>Matière du devoir</returns>
        public cls_Matiere getMatiere()
        {
            return c_Matiere;
        }

        /// <summary>
        /// Modifie la matière du devoir
        /// </summary>
        /// <param name="pMatiere">Matière du devoir</param>
        public void setMatiere(cls_Matiere pMatiere)
        {
            c_Matiere = pMatiere;
        }

        /// <summary>
        /// Retourne la date du devoir
        /// </summary>
        /// <returns>Date à laquelle le devoir a eu lieu</returns>
        public DateTime getDateDevoir()
        {
            return c_DateDevoir;
        }

        /// <summary>
        /// Modifie la date à laquelle le devoir a eu lieu
        /// </summary>
        /// <param name="pDateDevoir">Date à laquelle le devoir a eu lieu</param>
        public void setDateDevoir(DateTime pDateDevoir)
        {
            c_DateDevoir = pDateDevoir;
        }
    }
}
