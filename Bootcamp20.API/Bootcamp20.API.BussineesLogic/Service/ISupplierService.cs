using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;

namespace Bootcamp20.API.BussineesLogic.Service
{
    public interface ISupplierService 
    {
        List<Supplier> Get();
        List<Supplier> Search(string name);
        SupplierParam Get(int? id);
        bool Insert(SupplierParam supplierparam);
        bool Update(SupplierParam supplierparam);
        bool Delete(int? id);
    }
}
