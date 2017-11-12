using ContractorCore.DBContext;
using ContractorCore.DBModels;
using ContractorCore.Helpers;
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
                    if (entity.Address != null)
                    {
                        entity.Address.CreatedAt = entity.CreatedAt;
                        entity.Address.CreatedBy = entity.CreatedBy;
                    }
                    if (entity.BankAccount != null)
                    {
                        entity.BankAccount.CreatedAt = entity.CreatedAt;
                        entity.BankAccount.CreatedBy = entity.CreatedBy;
                    }
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
                LogInfo.LogMessage(enumLogInfoType.Error, ex);
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
                if (entity.Address != null)
                {
                    entity.Address.ModifiedAt = entity.ModifiedAt;
                    entity.Address.ModifiedBy = entity.ModifiedBy;
                    contractorContext.Entry(entity.Address).State = EntityState.Modified;
                }
                if (entity.BankAccount != null)
                {
                    entity.BankAccount.ModifiedAt = entity.ModifiedAt;
                    entity.BankAccount.ModifiedBy = entity.ModifiedBy;
                    contractorContext.Entry(entity.BankAccount).State = EntityState.Modified;
                }
                contractorContext.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage(enumLogInfoType.Error, ex);
                return false;
            }
        }
        #endregion
    }
}
