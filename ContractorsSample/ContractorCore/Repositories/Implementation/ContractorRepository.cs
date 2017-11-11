using ContractorCore.DBContext;
using ContractorCore.DBModels;
using ContractorCore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorCore.Repositories.Implementation
{
    public class ContractorRepository : IContractorRepository
    {
        private readonly ContractorsContext contractorContext;

        public ContractorRepository(ContractorsContext context)
        {
            contractorContext = context;
        }

        #region Methods
        public bool Create(oContractor entity)
        {
            try
            {
                if (entity == null)
                    return false;
                if (entity.Id > 0)
                {
                    Update(entity);
                }
                else
                {
                    contractorContext.Contractors.Add(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var contractor = contractorContext.Contractors.FirstOrDefault(_ => _.Id == id);
                if (contractor != null)
                {
                    contractorContext.Contractors.Remove(contractor);
                }
                return true;
            }
            catch (Exception ex)
            {
                //logowanie błędów
                return false;
            }
        }

        public ICollection<oContractor> GetAll()
        {
            return contractorContext.Contractors.Include(_ => _.BankAccount).Include(_ => _.Address).ToList();
        }

        public async Task<ICollection<oContractor>> GetAllAsync()
        {
            return await contractorContext.Contractors.Include(_ => _.BankAccount).Include(_ => _.Address).ToListAsync();
        }

        public oContractor GetById(int id)
        {
            return contractorContext.Contractors.Include(_ => _.BankAccount).Include(_ => _.Address).FirstOrDefault(_ => _.Id == id);
        }

        public async Task<oContractor> GetByIdAsync(int id)
        {
            return await contractorContext.Contractors.Include(_ => _.BankAccount).Include(_ => _.Address).FirstOrDefaultAsync(_ => _.Id == id);
        }

        public int Save()
        {
            return contractorContext.SaveChanges();
        }

        public bool Update(oContractor entity)
        {
            try
            {
                contractorContext.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
