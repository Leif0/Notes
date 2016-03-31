using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class cls_Semestre
    {
        private int c_Numero;
        private DateTime c_Debut;
        private DateTime c_Fin;

        public cls_Semestre(int pNumero, DateTime pDebut, DateTime pFin)
        {
            setNumero(pNumero);
            setDebut(pDebut);
            setFin(pFin);
        }

        public void setFin(DateTime pDateFin)
        {
            c_Fin = pDateFin;
        }

        public DateTime getFin()
        {
            return c_Fin;
        }

        public void setDebut(DateTime pDateDebut)
        {
            c_Debut = pDateDebut;
        }

        public DateTime getDebut()
        {
            return c_Debut;
        }

        public void setNumero(int pNumero)
        {
            if (pNumero == 1 || pNumero == 2)
            {
                c_Numero = pNumero;
            }
            else
            {
                throw new Exception("Le semestre doit être 1 ou 2.");
            }
        }

        public int getNumero()
        {
            return c_Numero;
        }
    }
}
