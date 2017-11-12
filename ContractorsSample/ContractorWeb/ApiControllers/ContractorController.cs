using ContractorCore.DBModels;
using ContractorCore.Helpers;
using ContractorCore.Repositories.Interfaces;
using ContractorWeb.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContractorWeb.ApiControllers
{
    [Produces("application/json")]
    [Route("api/Contractor")]
    public class ContractorController : Controller
    {
        private readonly IContractorRepository contractorRepository;

        public ContractorController(IContractorRepository repository)
        {
            contractorRepository = repository;
        }

        #region Methods
        [HttpGet]
        [Validation]
        public IActionResult Get()
        {
            try
            {
                var list = contractorRepository.GetAll();
                return new OkObjectResult(list);
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage(enumLogInfoType.Error, ex);
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("{id}")]
        [Validation]
        public IActionResult Get(int id)
        {
            try
            {
                var contractor = contractorRepository.GetById(id);
                return new OkObjectResult(contractor);
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage(enumLogInfoType.Error, ex);
                return new BadRequestObjectResult(ex);
            }

        }

        [HttpPost]
        [Validation]
        public IActionResult Post([FromBody]oContractor value)
        {
            try
            {
                contractorRepository.Create(value);
                contractorRepository.Save();
                return new OkResult();
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage(enumLogInfoType.Error, ex);
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpDelete("{id}")]
        [Validation]
        public IActionResult Delete(int id)
        {
            try
            {
                contractorRepository.Delete(id);
                contractorRepository.Save();
                return new OkResult();
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage(enumLogInfoType.Error, ex);
                return new BadRequestObjectResult(ex);
            }
        }
        #endregion
    }
}