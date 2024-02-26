using CODE_FIRST.DAO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CODE_FIRST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CompanyDBContext companydbc = new CompanyDBContext();
        private IDAOManager manager = null;


        public MainWindow()
        {
            InitializeComponent();
            manager = DAOManagerFactory.CreateDaoManager(companydbc);

            //OK
            //manager.ImportOffices();
            //OK
            //manager.ImportEmployees();
            //OK
            //manager.ImportCustomers();            
            //OK
            //manager.ImportPayments();
            //OK
            //manager.ImportOrders();
            //OK
            //manager.ImportProductLines();
            //OK
            //manager.ImportProducts();
            manager.ImportOrderDetails();
        }

    }
}