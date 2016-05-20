using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes;

namespace dll_Notes
{
    /// <summary>
    /// Modèle contenant les données
    /// </summary>
    public class cls_Modele
    {
        private Dictionary<int, cls_Groupe> c_ListeGroupes;
        private Dictionary<int, cls_Eleve> c_ListeEleves;
        private Dictionary<int, cls_Matiere> c_ListeMatieres;
        private Dictionary<int, cls_Devoir> c_ListeDevoirs;
        private Dictionary<int, cls_Enseignant> c_ListeEnseignants;


        // Un seul semestre en dur
        private cls_Semestre c_Semestre1;

        public cls_Modele()
        {
            c_ListeGroupes  = new Dictionary<int, cls_Groupe>();
            c_ListeEleves   = new Dictionary<int, cls_Eleve>();
            c_ListeMatieres = new Dictionary<int, cls_Matiere>();
            c_ListeDevoirs = new Dictionary<int, cls_Devoir>();
            c_ListeEnseignants = new Dictionary<int, cls_Enseignant>();

            c_Semestre1 = new cls_Semestre(1, new DateTime(2016, 1, 1), new DateTime(2016, 6, 1));
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

        public Dictionary<int, cls_Enseignant> ListeEnseignants
        {
            get { return c_ListeEnseignants; }
            set { c_ListeEnseignants = value; }
        }

        public cls_Semestre Semestre
        {
            get { return c_Semestre1; }
        }

        public cls_Eleve getEleveById(int pIdEleve)
        {
            foreach (cls_Eleve l_Eleve in ListeEleves.Values)
            {
                if (l_Eleve.Id == pIdEleve)
                {
                    return l_Eleve;
                }
            }
            return null;
        }

        public cls_Matiere getMatiereById(int pIdMatiere)
        {
            foreach (cls_Matiere l_Matiere in ListeMatieres.Values)
            {
                if (l_Matiere.Id == pIdMatiere)
                {
                    return l_Matiere;
                }
            }
            return null;
        }

        public cls_Devoir getDevoirById(int pIdDevoir)
        {
            foreach (cls_Devoir l_Devoir in ListeDevoirs.Values)
            {
                if (l_Devoir.Id == pIdDevoir)
                {
                    return l_Devoir;
                }
            }
            return null;
        }

        public void ModifierEleve(cls_Eleve pEleve)
        {
            c_ListeEleves[pEleve.Id] = pEleve;
        }
    }
}
