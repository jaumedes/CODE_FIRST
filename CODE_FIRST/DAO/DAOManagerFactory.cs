using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST.DAO
{
    public class DAOManagerFactory
    {
        public static IDAOManager CreateDaoManager(CompanyDBContext context)
        {
            return new DAOManager(context);
        }
    }
}
