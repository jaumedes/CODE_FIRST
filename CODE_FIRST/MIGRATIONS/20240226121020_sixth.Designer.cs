﻿// <auto-generated />
using System;
using CODE_FIRST;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CODE_FIRST.Migrations
{
    [DbContext(typeof(CompanyDBContext))]
    [Migration("20240226121020_sixth")]
    partial class sixth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CODE_FIRST.MODEL.Customers", b =>
                {
                    b.Property<int>("customerNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)");

                    b.Property<string>("ContactFirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("addressLine1")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("addressLine2")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("contactLastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("creditLimit")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("customerName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("postalCode")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(15);

                    b.Property<int>("salesRepEmployeeNumber")
                        .HasColumnType("INT(11)");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("customerNumber");

                    b.HasIndex("salesRepEmployeeNumber");

                    b.ToTable("CUSTOMERS");
                });

            modelBuilder.Entity("CODE_FIRST.MODEL.Employees", b =>
                {
                    b.Property<int>("employeeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)");

                    b.Property<string>("OfficesofficeCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(50);

                    b.Property<string>("extension")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("jobTitle")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("officeCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(50);

                    b.Property<int>("reportsTo")
                        .HasColumnType("INT(11)");

                    b.HasKey("employeeNumber");

                    b.HasIndex("OfficesofficeCode");

                    b.HasIndex("reportsTo");

                    b.ToTable("EMPLOYEES");
                });

            modelBuilder.Entity("CODE_FIRST.MODEL.Offices", b =>
                {
                    b.Property<string>("officeCode")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("addressLine1")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("addressLine2")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("postalCode")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("territory")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("officeCode");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("CODE_FIRST.MODEL.OrderDetails", b =>
                {
                    b.Property<int>("orderNumber")
                        .HasColumnType("INT(11)");

                    b.Property<string>("productCode")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(15);

                    b.Property<short>("orderLineNumber")
                        .HasColumnType("smallint(6)");

                    b.Property<decimal>("priceEach")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("quantityOrdered")
                        .HasColumnType("INT(11)");

                    b.HasKey("orderNumber", "productCode");

                    b.HasIndex("productCode");

                    b.ToTable("ORDERDETAILS");
                });

            modelBuilder.Entity("CODE_FIRST.MODEL.Orders", b =>
                {
                    b.Property<int>("orderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)");

                    b.Property<string>("comments")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("customerNumber")
                        .HasColumnType("INT(11)");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("Date");

                    b.Property<DateTime>("requiredDate")
                        .HasColumnType("Date");

                    b.Property<DateTime>("shippedDate")
                        .HasColumnType("Date");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("orderNumber");

                    b.HasIndex("customerNumber");

                    b.ToTable("ORDERS");
                });

            modelBuilder.Entity("CODE_FIRST.MODEL.Payments", b =>
                {
                    b.Property<int>("customerNumber")
                        .HasColumnType("INT(11)");

                    b.Property<string>("checkNumber")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("paymentDate")
                        .HasColumnType("Date");

                    b.HasKey("customerNumber", "checkNumber");

                    b.ToTable("PAYMENTS");
                });

            modelBuilder.Entity("CODE_FIRST.MODEL.ProductLines", b =>
                {
                    b.Property<string>("productLineName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("htmlDescription")
                        .IsRequired()
                        .HasColumnType("mediumtext");

                    b.Property<byte[]>("image")
                        .IsRequired()
                        .HasColumnType("mediumblob");

                    b.Property<string>("textDescription")
                        .IsRequired()
                        .HasColumnType("varchar(4000)")
                        .HasMaxLength(50);

                    b.HasKey("productLineName");

                    b.ToTable("PRODUCTLINES");
                });

            modelBuilder.Entity("CODE_FIRST.MODEL.Products", b =>
                {
                    b.Property<string>("productCode")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<decimal>("MSRP")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("buyPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("productDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("productLine")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("varchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("productScale")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("productVendor")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<short>("quantityStock")
                        .HasColumnType("smallint(6)");

                    b.HasKey("productCode");

                    b.HasIndex("productLine");

                    b.ToTable("PRODUCTS");
                });

            modelBuilder.Entity("CODE_FIRST.MODEL.Customers", b =>
                {
                    b.HasOne("CODE_FIRST.MODEL.Employees", "Employees")
                        .WithMany("Customers")
                        .HasForeignKey("salesRepEmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CODE_FIRST.MODEL.Employees", b =>
                {
                    b.HasOne("CODE_FIRST.MODEL.Offices", "Offices")
                        .WithMany("Employees")
                        .HasForeignKey("OfficesofficeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CODE_FIRST.MODEL.Employees", "employeesToReport")
                        .WithMany()
                        .HasForeignKey("reportsTo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CODE_FIRST.MODEL.OrderDetails", b =>
                {
                    b.HasOne("CODE_FIRST.MODEL.Orders", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("orderNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CODE_FIRST.MODEL.Products", "Products")
                        .WithMany("OrderDetails")
                        .HasForeignKey("productCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CODE_FIRST.MODEL.Orders", b =>
                {
                    b.HasOne("CODE_FIRST.MODEL.Customers", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("customerNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CODE_FIRST.MODEL.Payments", b =>
                {
                    b.HasOne("CODE_FIRST.MODEL.Customers", "Customers")
                        .WithMany("Payments")
                        .HasForeignKey("customerNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CODE_FIRST.MODEL.Products", b =>
                {
                    b.HasOne("CODE_FIRST.MODEL.ProductLines", "productLines")
                        .WithMany()
                        .HasForeignKey("productLine")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
