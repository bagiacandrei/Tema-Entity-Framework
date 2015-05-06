using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Personal.WebApi
{
    class BadRequest : Exception
    {
        private string p;

        public BadRequest(string p)
        {
            
            this.p = p;
        }
    }
}
