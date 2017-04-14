using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper.Data
{
    public static class InitDB
    {
        public static void InitiateDB()
        {
            using (var context = new RPGHelperContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
