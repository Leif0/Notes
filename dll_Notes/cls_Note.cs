using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class cls_Note
    {
        private double c_Valeur;
        private cls_Eleve c_Eleve;
        private cls_Devoir c_Devoir;
        private cls_Semestre c_Semestre;

        /// <summary>
        /// Instancie une note, appartenant à un élève et un devoir
        /// </summary>
        /// <param name="pValeur">Valeur de la note</param>
        /// <param name="pEleve">Eleve qui a eu cette note</param>
        /// <param name="pDevoir">Le devoir de la note</param>

        public cls_Note(double pValeur, cls_Eleve pEleve, cls_Devoir pDevoir, cls_Semestre pSemestre)
        {
            setValeur(pValeur);
            setEleve(pEleve);
            setDevoir(pDevoir);
            pEleve.ajouterNote(this);
            setSemestre(pSemestre);
        }
        /// <summary>
        /// Récupère le semestre où cette note a été donnée
        /// </summary>
        /// <returns>Semestre</returns>
        public cls_Semestre getSemestre()
        {
            return c_Semestre;
        }

        /// <summary>
        /// Modifie le semestre où cette note a été donnée
        /// </summary>
        /// <param name="pSemestre">Semestre de la note</param>
        public void setSemestre(cls_Semestre pSemestre)
        {
            c_Semestre = pSemestre;
        }

        /// <summary>
        /// Modifie la valeur de la note en vérifiant qu'elle est bien entre 0 et 20
        /// </summary>
        /// <param name="pValeur">Valeur de la note</param>
        public void setValeur(double pValeur)
        {
            if (pValeur > 20 || pValeur < 0)
            {
                throw new Exception("La note doit être entre 0 et 20");
            }
            else
            {
                c_Valeur = pValeur;
            }
        }

        /// <summary>
        /// Retourne la valeur de la note
        /// </summary>
        /// <returns>Valeur de la note</returns>
        public double getValeur()
        {
            return c_Valeur;
        }

        /// <summary>
        /// Modifie l'élève qui a eu cette note
        /// </summary>
        /// <param name="pEleve">Eleve qui a eu la note</param>
        public void setEleve(cls_Eleve pEleve)
        {
            c_Eleve = pEleve;
        }

        /// <summary>
        /// Retourne l'élève qui a eu cette note
        /// </summary>
        /// <returns>Eleve qui a eu cette note</returns>
        public cls_Eleve getEleve()
        {
            return c_Eleve;
        }

        /// <summary>
        /// Modifie le devoir
        /// </summary>
        /// <param name="pDevoir">Devoir</param>
        public void setDevoir(cls_Devoir pDevoir)
        {
            c_Devoir = pDevoir;
        }

        /// <summary>
        /// Retourne le devoir
        /// </summary>
        /// <returns>Devoir</returns>
        public cls_Devoir getDevoir()
        {
            return c_Devoir;
        }

    }
}
