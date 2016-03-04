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
        private cls_Semestre c_Semestre;

        /// <summary>
        /// Instancie une appreciation pour un élève dans une matière specifique
        /// </summary>
        /// <param name="pTexte">Texte de l'appreciation, donnée par le professeur</param>
        /// <param name="pEleve">Eleve concerné par l'appreciation</param>
        /// <param name="pMatiere">Matière dans laquelle l'appréciation a été donnée</param>
        public cls_Appreciation(string pTexte, cls_Eleve pEleve, cls_Matiere pMatiere, cls_Semestre pSemestre)
        {
            setTexte(pTexte);
            setEleve(pEleve);
            setMatiere(pMatiere);
            pEleve.ajouterAppreciation(this);
            setSemestre(pSemestre);
        }

        /// <summary>
        /// Modifie le texte de l'appréciation
        /// </summary>
        /// <param name="pTexte">Texte de l'appréciation</param>
        public void setTexte(string pTexte)
        {
            c_Texte = pTexte;
        }

        /// <summary>
        /// Retourne le texte de l'appreciation
        /// </summary>
        /// <returns>Texte de l'appréciation</returns>
        public string getTexte()
        {
            return c_Texte;
        }

        /// <summary>
        /// Modifie l'élève concerné par l'appréciation
        /// </summary>
        /// <param name="pEleve">Elève concerné par l'appréciation</param>
        public void setEleve(cls_Eleve pEleve)
        {
            c_Eleve = pEleve;
        }

        /// <summary>
        /// Retourne l'élève concerné par l'appréciation
        /// </summary>
        /// <returns>Eleve concerné par l'appreciation</returns>
        public cls_Eleve getEleve()
        {
            return c_Eleve;
        }

        /// <summary>
        /// Modifie la matière de l'appréciation
        /// </summary>
        /// <param name="pMatiere">Matière de l'appréciation</param>
        public void setMatiere(cls_Matiere pMatiere)
        {
            c_Matiere = pMatiere;
        }

        /// <summary>
        /// Retourne la matière de l'appréciation
        /// </summary>
        /// <returns>Matière de l'appréciation</returns>
        public cls_Matiere getMatiere()
        {
            return c_Matiere;
        }

        public void setSemestre(cls_Semestre pSemestre)
        {
            c_Semestre = pSemestre;
        }

        public cls_Semestre getSemestre()
        {
            return c_Semestre;
        }
    }
}
