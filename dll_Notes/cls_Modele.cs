using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes;

namespace dll_Notes
{
    public class cls_Modele
    {
        private Dictionary<int, cls_Groupe> c_ListeGroupes;
        private Dictionary<int, cls_Eleve> c_ListeEleves;
        private Dictionary<int, cls_Matiere> c_ListeMatieres;
        private Dictionary<int, cls_Devoir> c_ListeDevoirs; 

        public cls_Modele()
        {
            c_ListeGroupes  = new Dictionary<int, cls_Groupe>();
            c_ListeEleves   = new Dictionary<int, cls_Eleve>();
            c_ListeMatieres = new Dictionary<int, cls_Matiere>();
            c_ListeDevoirs = new Dictionary<int, cls_Devoir>();
        }

        public Dictionary<int, cls_Groupe> ListeGroupes
        {
            get { return c_ListeGroupes; }
            set { c_ListeGroupes = value; }
        }

        public Dictionary<int, cls_Eleve> ListeEleves
        {
            get { return c_ListeEleves; }
            set { c_ListeEleves = value; }
        }

        public Dictionary<int, cls_Matiere> ListeMatieres
        {
            get { return c_ListeMatieres; }
            set { c_ListeMatieres = value; }
        }

        public Dictionary<int, cls_Devoir> ListeDevoirs
        {
            get { return c_ListeDevoirs; }
            set { c_ListeDevoirs = value; }
        } 

        public cls_Eleve getEleveById(int pIdEleve)
        {
            return c_ListeEleves[pIdEleve];
        }

        public cls_Matiere getMatiereById(int pIdMatiere)
        {
            return c_ListeMatieres[pIdMatiere];
        }

        public void ModifierEleve(cls_Eleve pEleve)
        {
            c_ListeEleves[pEleve.Id] = pEleve;
        }
    }
}
