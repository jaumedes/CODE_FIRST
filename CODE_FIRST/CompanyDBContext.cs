using CODE_FIRST.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST
{
    public class CompanyDBContext : DbContext
    {
        public CompanyDBContext() { }
        public CompanyDBContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //En cas que el context no estigui configurat, el configurem mitjançant la cadena..
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=COMPANYDB;Uid=root;Pwd=\"\"");
            }
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductLines> ProductLines { get; set; }
        public virtual DbSet<Offices> Offices { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CompositeKey OrderDetails
            modelBuilder.Entity<OrderDetails>()
                .HasKey(od => new { od.orderNumber, od.productCode });

            //CompositeKey Payments
            modelBuilder.Entity<Payments>()
                .HasKey(p => new { p.customerNumber, p.checkNumber });
            
            //ForeignKey Payments
            modelBuilder.Entity<Payments>()
                .HasOne(p => p.Customers)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.customerNumber);

            //ForeignKey OrderDetails
            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Orders)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.orderNumber);



            //    //Relació officeCode Employees
            //    modelBuilder.Entity<Employees>()
            //        .HasOne(e => e.Offices)
            //        .WithMany(o => o.Employees)
            //        .HasForeignKey(e => e.officeCode);

            //    //Taula employees
            //    modelBuilder.Entity<Employees>()
            //        .HasKey(e => e.employeeNumber); // Defineix la clau primària

            //    modelBuilder.Entity<Employees>()
            //        .Property(e => e.employeeNumber)
            //        .HasColumnType("INT(11)"); // Defineix el tipus de dades de la columna employeeNumber

            //    modelBuilder.Entity<Employees>()
            //        .Property(e => e.lastName)
            //        .HasMaxLength(50)
            //        .HasColumnType("varchar(50)"); // Defineix el tipus de dades de la columna lastName i la seva longitud màxima

            //    modelBuilder.Entity<Employees>()
            //        .Property(e => e.firstName)
            //        .HasMaxLength(50)
            //        .HasColumnType("varchar(50)"); // Defineix el tipus de dades de la columna firstName i la seva longitud màxima

            //    modelBuilder.Entity<Employees>()
            //        .Property(e => e.extension)
            //        .HasMaxLength(10)
            //        .HasColumnType("varchar(10)"); // Defineix el tipus de dades de la columna extension i la seva longitud màxima

            //    modelBuilder.Entity<Employees>()
            //        .Property(e => e.email)
            //        .HasMaxLength(100)
            //        .HasColumnType("varchar(100)"); // Defineix el tipus de dades de la columna email i la seva longitud màxima

            //    modelBuilder.Entity<Employees>()
            //        .Property(e => e.jobTitle)
            //        .HasMaxLength(50)
            //        .HasColumnType("varchar(50)");
        }
    }
}
