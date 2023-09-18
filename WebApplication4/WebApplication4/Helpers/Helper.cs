using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Helpers
{
    public class Helper : IHelper
    {
        public string Upper(string text)
        {

            return text.ToUpper();

        }
    }
}
