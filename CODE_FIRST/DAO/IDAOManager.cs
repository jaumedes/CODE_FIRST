using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST.DAO
{
    public interface IDAOManager
    {
        public bool ImportCustomers();
        public bool ImportOffices();
        public bool ImportEmployees();
        public bool ImportPayments();
        public bool ImportProductLines();
        public bool ImportProducts();
        public bool ImportOrders();
        public bool ImportOrderDetails();



    }
}
