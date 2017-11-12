using AutoMapper;
using ContractorCore.DBModels;
using ContractorCore.Services;
using ContractorWeb.Controllers;
using ContractorWeb.Models.Contractors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContractorTest.Controllers
{
    [TestClass]
    public class ContractorControllerTest
    {
        private List<oContractor> contractorList;
        private Mock<IApiContractorConsumer> contractorRepository;


        [TestInitialize]
        public void Initialize()
        {
            contractorList = new List<oContractor>
            {
                new oContractor()
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    CreatedBy =1,
                    NIP = "1111111111",
                    IsNaturalPerson = true,
                    FirstName = "TestName",
                    SecondName = "TestSecondName",
                    NIPEU = "PL1111111111",
                    Address = new oContractorAddress()
                    {
                        Id = 1,
                        City = "Siedlce",
                        ApartamentNumber = "1",
                        HouseNumber = "1",
                        Street = "Testowa",
                        Country = "PL",
                        PostCode = "08-124",
                        PostOffice = "Mokobody"
                    },
                    BankAccount = new oContractorBankAccount()
                    {
                        Id = 1,
                        BankName = "BGZ",
                        BankNumber = "1111111111111111111111111111111111111",
                        BankSwift = "BGZASD"
                    }

                }
            };


            contractorRepository = new Mock<IApiContractorConsumer>();
            contractorRepository.Setup(x => x.CreateContractor(It.IsAny<oContractor>())).Callback((oContractor log) =>
                        contractorList.Add(log));
            contractorRepository.Setup(x => x.DeleteContractor(It.IsAny<oContractor>())).Callback((oContractor log) =>
                        contractorList.Remove(contractorList.FirstOrDefault(_ => _.Id == log.Id)));
            contractorRepository.Setup(x => x.GetContractorList()).Returns(
                        contractorList);
            contractorRepository.Setup(x => x.GetContractor(It.IsAny<int>())).Returns((int log) =>
                        contractorList.FirstOrDefault(_ => _.Id == log));
            contractorRepository.Setup(x => x.UpdateContractor(It.IsAny<oContractor>())).Callback((oContractor log) =>
                        contractorList.Insert(contractorList.FindIndex(_ => _.Id == log.Id), log));
            try
            {
                var mapper = Mapper.Instance;
            }
            catch (Exception)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<oContractor, mContractor>();
                    cfg.CreateMap<oContractorAddress, mContractorAddress>();
                    cfg.CreateMap<oContractorBankAccount, mContractorBankAccount>();
                    cfg.CreateMap<mContractor, oContractor>();
                    cfg.CreateMap<mContractorAddress, oContractorAddress>();
                    cfg.CreateMap<mContractorBankAccount, oContractorBankAccount>();
                });
            }

        }

        [TestMethod]
        public void Contractor_Constructor_Create_Good_Object()
        {
            ContractorController contractorController = new ContractorController(contractorRepository.Object, null);
            Assert.IsNotNull(contractorController);
        }

        [TestMethod]
        public void Contractor_Index_Create_Good_Object()
        {
            //Arrnage
            var expected = contractorList;
            ContractorController contractorController = new ContractorController(contractorRepository.Object, Mapper.Instance);

            //Act
            var result = contractorController.Index();
            var viewResult = result as ViewResult;
            //Assert
            Assert.IsInstanceOfType(viewResult.Model, typeof(List<mContractor>));
        }

        [TestMethod]
        public void Contractor_Create_Create_Good_Object()
        {
            //Arrnage
            ContractorController contractorController = new ContractorController(contractorRepository.Object, Mapper.Instance);

            //Act
            var result = contractorController.Create();
            var viewResult = result as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
            Assert.IsNull(viewResult.Model);
        }

        [TestMethod]
        public void Contractor_Create_Works_Good_Object()
        {
            //Arrnage
            var model = new mContractor
            {
                Pesel = "123123",
                FirstName = "asdasd",

            };
            ContractorController contractorController = new ContractorController(contractorRepository.Object, Mapper.Instance);

            //Act
            var result = contractorController.Create(model);
            //Assert
            Assert.AreEqual(model.Pesel, contractorList.Last().Pesel);
        }

        [TestMethod]
        public void Contractor_Edit_Create_Good_Object()
        {
            //Arrnage
            ContractorController contractorController = new ContractorController(contractorRepository.Object, Mapper.Instance);

            //Act
            var result = contractorController.Edit(contractorList.First().Id);
            var viewResult = result as ViewResult;
            //Assert
            Assert.IsInstanceOfType(viewResult.Model, typeof(mContractor));
            Assert.AreEqual(((mContractor)viewResult.Model).Id, contractorList.First().Id);
        }

        [TestMethod]
        public void Contractor_EditPost_Works_Good_Object()
        {
            //Arrnage
            var model = contractorList.First();
            model.Pesel = "123123";
            ContractorController contractorController = new ContractorController(contractorRepository.Object, Mapper.Instance);

            //Act
            var result = contractorController.Edit(Mapper.Map<mContractor>(model));
            //Assert
            Assert.AreEqual(model.Pesel, contractorList.First().Pesel);
        }

        [TestMethod]
        public void Contractor_Delete_Create_Good_Object()
        {
            //Arrnage
            ContractorController contractorController = new ContractorController(contractorRepository.Object, Mapper.Instance);

            //Act
            var result = contractorController.Delete(contractorList.First().Id);
            var viewResult = result as ViewResult;
            //Assert
            Assert.IsInstanceOfType(viewResult.Model, typeof(mContractor));
            Assert.AreEqual(((mContractor)viewResult.Model).Id, contractorList.First().Id);
        }

        [TestMethod]
        public void Contractor_DeletePost_Works_Good_Object()
        {
            //Arrnage
            var model = contractorList.First();
            ContractorController contractorController = new ContractorController(contractorRepository.Object, Mapper.Instance);

            //Act
            var result = contractorController.Delete(Mapper.Map<mContractor>(model));
            //Assert
            Assert.AreEqual(0, contractorList.Count);
        }
    }
}
