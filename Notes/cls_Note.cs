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

        public cls_Note(double pValeur, cls_Eleve pEleve, cls_Devoir pDevoir)
        {
            setValeur(pValeur);
            setEleve(pEleve);
            setDevoir(pDevoir);
            pEleve.ajouterNote(this);
        }

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

        public double getValeur()
        {
            return c_Valeur;
        }

        public void setEleve(cls_Eleve pEleve)
        {
            c_Eleve = pEleve;
        }

        public cls_Eleve getEleve()
        {
            return c_Eleve;
        }

        public void setDevoir(cls_Devoir pDevoir)
        {
            c_Devoir = pDevoir;
        }

        public cls_Devoir getDevoir()
        {
            return c_Devoir;
        }

    }
}
