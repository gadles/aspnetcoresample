﻿// <auto-generated />
using ContractorCore.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ContractorCore.Migrations
{
    [DbContext(typeof(ContractorsContext))]
    partial class ContractorsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContractorCore.DBModels.oContractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<int?>("BankAccountId");

                    b.Property<string>("CompanyName");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedBy");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsNaturalPerson");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<string>("NIP");

                    b.Property<string>("NIPEU");

                    b.Property<string>("Pesel");

                    b.Property<string>("SecondName");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("BankAccountId");

                    b.ToTable("Contractors");
                });

            modelBuilder.Entity("ContractorCore.DBModels.oContractorAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApartamentNumber");

                    b.Property<string>("City");

                    b.Property<string>("Commune");

                    b.Property<string>("Country");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedBy");

                    b.Property<string>("District");

                    b.Property<string>("Email");

                    b.Property<string>("HouseNumber");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostCode");

                    b.Property<string>("PostOffice");

                    b.Property<string>("Province");

                    b.Property<string>("Street");

                    b.Property<string>("WWW");

                    b.HasKey("Id");

                    b.ToTable("oContractorAddress");
                });

            modelBuilder.Entity("ContractorCore.DBModels.oContractorBankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BankName");

                    b.Property<string>("BankNumber");

                    b.Property<string>("BankSwift");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.HasKey("Id");

                    b.ToTable("oContractorBankAccount");
                });

            modelBuilder.Entity("ContractorCore.DBModels.oContractor", b =>
                {
                    b.HasOne("ContractorCore.DBModels.oContractorAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("ContractorCore.DBModels.oContractorBankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId");
                });
#pragma warning restore 612, 618
        }
    }
}
