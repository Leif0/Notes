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

        public cls_Modele()
        {
            c_ListeGroupes = new Dictionary<int, cls_Groupe>();
            c_ListeEleves = new Dictionary<int, cls_Eleve>();
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

        public cls_Eleve getEleveById(int pIdEleve)
        {
            return c_ListeEleves[pIdEleve];
        }

        public void ModifierEleve(cls_Eleve pEleve)
        {
            c_ListeEleves[pEleve.getId()] = pEleve;
        }
    }
}
