using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class cls_ObjetBase
    {
        private int c_Id;
        public static int c_IdMax;

        public cls_ObjetBase(int pId)
        {
            c_Id = pId;
            if (c_Id > c_IdMax)
            {
                c_IdMax = c_Id;
            }
        }

        public int Id
        {
            get { return c_Id; }
        }

        public static int NouvelId()
        {
            return c_IdMax + 1;
        }
    }
}
