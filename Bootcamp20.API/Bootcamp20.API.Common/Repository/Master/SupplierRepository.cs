using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;

namespace Bootcamp20.API.Common.Repository.Master
{
    public class SupplierRepository : ISupplierRepository
    {
        MyContext _context = new MyContext();
        bool status = false;
        public bool Delete(int? id)
        {
            var sup = Get(id);
            sup.IsDelete = true;
            sup.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            _context.Entry(sup).State = EntityState.Modified;
            var result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Supplier> Get()
        {
            return _context.Supplier.Where(x => x.IsDelete == false).ToList();
        }

        public SupplierParam Get(int? id)
        {
            var supparam = _context.Supplier.SingleOrDefault(x => x.Id == id && x.IsDelete == false);
            SupplierParam supnew = new SupplierParam(supparam);
            return supnew;
        }

        public bool Insert(SupplierParam supplierparam)
        {
            Supplier supplier = new Supplier(supplierparam);
            _context.Supplier.Add(supplier);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(SupplierParam supplierparam)
        {
            Supplier sup = _context.Supplier.SingleOrDefault(x => x.Id == supplierparam.Id && x.IsDelete == false); 
            sup.Update(supplierparam);
            _context.Entry(sup).State = EntityState.Modified;
            var result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;

        }

        public List<Supplier> Search(string name)
        {
            return _context.Supplier.Where(x => x.Name.Contains(name) && x.IsDelete==false).ToList();
        }

        public List<Supplier> SearchByDate(string month)
        {
            int months = Convert.ToInt16(month);
            return _context.Supplier.Where(x => x.CreateDate.Value.Month == months && x.IsDelete == false).ToList();
        }
    }
}
