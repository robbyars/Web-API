using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.API.Common.Repository;
using DataAccess.Model;
using DataAccess.Param;

namespace Bootcamp20.API.BussineesLogic.Service.Master
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepo;
        public SupplierService() { }
        public SupplierService(ISupplierRepository supplierRepository)
        {
            this._supplierRepo = supplierRepository;
        }

        public bool Delete(int? id)
        {
            return _supplierRepo.Delete(id);
        }

        public List<Supplier> Get()
        {
            return _supplierRepo.Get();
        }

        public SupplierParam Get(int? id)
        {
            return _supplierRepo.Get(id);
        }

        public bool Insert(SupplierParam supplierparam)
        {
            return _supplierRepo.Insert(supplierparam);
        }

        public List<Supplier> Search(string name)
        {
            return _supplierRepo.Search(name);
        }

        public List<Supplier> SearchByDate(string month)
        {
            return _supplierRepo.SearchByDate(month);
        }

        public bool Update(SupplierParam supplierparam)
        {
            return _supplierRepo.Update(supplierparam);
        }
    }
}
