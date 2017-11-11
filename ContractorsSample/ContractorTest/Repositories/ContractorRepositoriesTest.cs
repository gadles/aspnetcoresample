using ContractorCore.DBModels;
using ContractorCore.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorTest.Repositories
{
    [TestClass]
    public class ContractorRepositoriesTest
    {

        private List<oContractor> contractorList;
        private Mock<IContractorRepository> contractorRepository;

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


            contractorRepository = new Mock<IContractorRepository>();
            contractorRepository.Setup(x => x.Create(It.IsAny<oContractor>())).Callback((oContractor log) =>
                        contractorList.Add(log));
            contractorRepository.Setup(x => x.Delete(It.IsAny<int>())).Callback((int log) =>
                        contractorList.Remove(contractorList.FirstOrDefault(_ => _.Id == log)));
            contractorRepository.Setup(x => x.GetAll()).Returns(
                        contractorList);
            contractorRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(
                        contractorList);
            contractorRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns((int log) =>
                        contractorList.FirstOrDefault(_ => _.Id == log));
            contractorRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int log) =>
                        contractorList.FirstOrDefault(_ => _.Id == log));
            contractorRepository.Setup(x => x.Update(It.IsAny<oContractor>())).Callback((oContractor log) =>
                        contractorList.Insert(contractorList.FindIndex(_ => _.Id == log.Id), log));
        }

        [TestMethod]
        public void GetById_Retrun_Good_Object()
        {
            var expected = contractorList.FirstOrDefault(m => m.Id == 1);
            var result = contractorRepository.Object.GetById(1);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public async Task GetByIdAsync_Retrun_Good_ObjectAsync()
        {
            var expected = contractorList.FirstOrDefault(m => m.Id == 1);
            var result = await contractorRepository.Object.GetByIdAsync(1);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetAll_Retrun_Good_Object()
        {
            var expected = contractorList;
            var result = contractorRepository.Object.GetAll();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public async Task GetAllAsync_Retrun_Good_Object()
        {
            var expected = contractorList;
            var result = await contractorRepository.Object.GetAllAsync();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Create_Working_Good()
        {
            var cont = new oContractor()
            {
                NIP = "1231231233"
            };
            contractorRepository.Object.Create(cont);
            Assert.AreSame(cont.NIP, contractorList.Last().NIP);
        }

        [TestMethod]
        public void Update_Working_Good()
        {
            var cont = contractorList.First();
            cont.NIP = "3332221113";
            contractorRepository.Object.Update(cont);
            Assert.AreSame(cont.NIP, contractorList.Last().NIP);
        }

        [TestMethod]
        public void Delete_Working_Good()
        {
            var cont = contractorList.First();
            contractorRepository.Object.Delete(cont.Id);
            Assert.AreEqual(0, contractorList.Count);
        }
    }
}
