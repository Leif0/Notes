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

        public int Id
        {
            get { return c_Id; }
            //set { c_Id = value; }
        }

        public cls_ObjetBase(int pId)
        {
            c_Id = pId;
        }
    }
}
