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
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/CUSTOMERS.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        int customerNumber = Convert.ToInt32(camps[0]);
                        string customerName = camps[1];
                        string contactLastName = camps[2];
                        string contactFirstName = camps[3];
                        string phone = camps[4];
                        string addressLine1 = camps[5];
                        string addressLine2 = camps[6];
                        string city = camps[7];
                        string state = camps[8];
                        string postalCode = camps[9];
                        string country = camps[10];
                        int? salesRepEmployeeNumber = (camps[11]).Equals("NULL") ? null : Convert.ToInt32(camps[11]);
                        double creditLimit = Convert.ToDouble(camps[12]);

                        var newCustomer = new Customers(customerNumber, customerName, contactLastName, contactLastName, phone, addressLine1, addressLine2, 
                                                        city, state, postalCode, country, salesRepEmployeeNumber, creditLimit);

                        dbContext.Customers.Add(newCustomer);
                        dbContext.SaveChanges();
                    }
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar clients: " + ex.Message);
            }
            return done;
        }

        public bool ImportOffices()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/OFFICES.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        string officeCode = camps[0];
                        string city = camps[1];
                        string phone = camps[2];
                        string addressLine1 = camps[3];
                        string addressLine2 = camps[4];
                        string state = camps[5];
                        string country = camps[6];
                        string postalCode = camps[7];
                        string territory = camps[8];

                        var newOffice = new Offices(officeCode, city, phone, addressLine1, addressLine2, 
                                                    state, country, postalCode, territory);

                        dbContext.Offices.Add(newOffice);
                        dbContext.SaveChanges();
                    }
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar oficines: " + ex.Message);
            }
            return done;
        }

        public bool ImportEmployees()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/EMPLOYEES.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        int employeeNumber = Convert.ToInt32(camps[0]);
                        string lastName = camps[1];
                        string firstName = camps[2];
                        string extension = camps[3];
                        string email = camps[4];
                        string officeCode = camps[5];
                        int? reportsTo = (camps[6]).Equals("NULL") ? null : Convert.ToInt32(camps[6]);
                        string jobTitle = camps[7];

                        var newEmployee = new Employees(employeeNumber, lastName, firstName, extension, email, officeCode, reportsTo, jobTitle);

                        dbContext.Employees.Add(newEmployee);
                        dbContext.SaveChanges();
                    }
                    
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar empleats: " + ex.Message);
            }
            return done;
        }

        public bool ImportPayments()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/PAYMENTS.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        int customerNumber = Convert.ToInt32(camps[0]);
                        string checkNumber = camps[1];
                        DateTime paymentDate;
                            DateTime.TryParse(camps[2], out paymentDate);
                        double amount = Convert.ToDouble(camps[3].Replace(".", ","));

                        var newPayment = new Payments (customerNumber, checkNumber, paymentDate, amount);

                        dbContext.Payments.Add(newPayment);
                        dbContext.SaveChanges();
                    }
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar payments: " + ex.Message);
            }
            return done;
        }

        public bool ImportOrders()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/ORDERS.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        int orderNumber = Convert.ToInt32(camps[0]);
                        DateTime orderDate;
                            DateTime.TryParse(camps[1],out orderDate);
                        DateTime requiredDate;
                            DateTime.TryParse(camps[2], out requiredDate);
                        DateTime shippedDate;
                            DateTime.TryParse(camps[3], out shippedDate);                        
                        string status = camps[4];
                        string? comments = ((camps[5]).Equals("NULL") ? null : camps[5]);
                        int? customerNumber = Convert.ToInt32(camps[6]);

                        var newOrder = new Orders(orderNumber, orderDate, requiredDate, shippedDate, status, comments, customerNumber);

                        dbContext.Orders.Add(newOrder);
                        dbContext.SaveChanges();
                    }
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar orders: " + ex.Message);
            }
            return done;
        }

        public bool ImportOrderDetails()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/ORDERDETAILS.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        int orderNumber = Convert.ToInt32(camps[0]);
                        string productCode = camps[1];
                        int quantityOrdered = Convert.ToInt32(camps[2]);
                        double priceEach = Convert.ToDouble(camps[3]);
                        int orderLineNumber = Convert.ToInt32(camps[4]);

                        var newOrderDetails = new OrderDetails(orderNumber, productCode, quantityOrdered, priceEach, orderLineNumber);

                        dbContext.OrderDetails.Add(newOrderDetails);
                        dbContext.SaveChanges();
                    }
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar orderDetails: " + ex.Message);
            }
            return done;
        }

        public bool ImportProductLines()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/PRODUCTLINES.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        string productLineName = camps[0];
                        string textDescription = camps[1];
                        string? htmlDescription = ((camps[2]).Equals("NULL") ? null : camps[2]);
                        byte[]? image = (camps[3]).Equals("NULL") ? null : Convert.FromBase64String(camps[3]);

                        var newProductLine = new ProductLines(productLineName, textDescription, htmlDescription, image);

                        dbContext.ProductLines.Add(newProductLine);
                        dbContext.SaveChanges();
                    }
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar productLines: " + ex.Message);
            }
            return done;
        }

        public bool ImportProducts()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/PRODUCTS.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        string productCode = camps[0];
                        string productName = camps[1];
                        string productLine = camps[2];
                        string productScale = camps[3];
                        string productVendor = camps[4];
                        string productDescription = camps[5];
                        int quantityStock = Convert.ToInt32(camps[6]);
                        double buyPrice = Convert.ToDouble(camps[7]);
                        double MSRP = Convert.ToDouble(camps[8]);

                        var newProduct = new Products(productCode, productName, productLine, productScale, 
                                    productVendor, productDescription, quantityStock, buyPrice,  MSRP);

                        dbContext.Products.Add(newProduct);
                        dbContext.SaveChanges();
                    }
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar products: " + ex.Message);
            }
            return done;
        }
    }
}
