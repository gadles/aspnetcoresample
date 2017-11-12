using AutoMapper;
using ContractorCore.DBModels;
using ContractorCore.Services;
using ContractorWeb.Models.Contractors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContractorWeb.Controllers
{
    public class ContractorController : Controller
    {
        private readonly IApiContractorConsumer contractorConsumer;
        private readonly IMapper mapper;

        public ContractorController(IApiContractorConsumer apiContractorConsumer, IMapper map)
        {
            contractorConsumer = apiContractorConsumer;
            mapper = map;
        }

        public IActionResult Index()
        {
            var list = contractorConsumer.GetContractorList();
            var listVM = mapper.Map<IEnumerable<oContractor>, IEnumerable<mContractor>>(list);
            return View(listVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(mContractor contractor)
        {
            if (ModelState.IsValid)
            {
                //Aktualny użytkownik 
                contractor.CreatedBy = 1;
                if (oContractor.SaveContractorFromViewModel<mContractor>(contractorConsumer, mapper, contractor))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(contractor);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id != null && id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(oContractor.GetUserById<mContractor>(contractorConsumer, mapper, id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(mContractor contractor)
        {
            if (ModelState.IsValid)
            {
                //Aktualny użytkownik
                contractor.ModifiedBy = 1;
                if (oContractor.SaveContractorFromViewModel<mContractor>(contractorConsumer, mapper, contractor))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(contractor);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id != null && id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(oContractor.GetUserById<mContractor>(contractorConsumer, mapper, id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(mContractor contractor)
        {
            if (oContractor.DeleteUserFromId(contractorConsumer, contractor.Id))
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}