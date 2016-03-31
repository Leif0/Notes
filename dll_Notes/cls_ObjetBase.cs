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

        public cls_ObjetBase(int pId)
        {
            c_Id = pId;
        }

        public int getId()
        {
            return c_Id;
        }
    }
}
