using CODE_FIRST.MODEL;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CODE_FIRST.DAO
{
    public class DAOManager : IDAOManager
    {
        private CompanyDBContext dbContext = null;
        public DAOManager(CompanyDBContext context)
        {
            this.dbContext = context;
        }

        public bool ImportCustomers()
        {
            throw new NotImplementedException();
        }

        public bool ImportEmployees()
        {
            throw new NotImplementedException();
        }

        public bool ImportOffices()
        {
            throw new NotImplementedException();
        }

        public bool ImportOrderDetails()
        {
            throw new NotImplementedException();
        }

        public bool ImportOrders()
        {
            throw new NotImplementedException();
        }

        public bool ImportPayments()
        {
            throw new NotImplementedException();
        }

        public bool ImportProductLines()
        {
            throw new NotImplementedException();
        }

        public bool ImportProducts()
        {
            throw new NotImplementedException();
        }
    }
}
