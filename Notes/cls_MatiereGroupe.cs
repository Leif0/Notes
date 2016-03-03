using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class cls_MatiereGroupe:cls_Matiere
    {

        public cls_MatiereGroupe(string pLibelle, cls_Groupe pGroupe, int pCoefficient, string pProfesseur) :
                            base(pLibelle, pGroupe, pCoefficient, pProfesseur)
        {

        }
    }
}
