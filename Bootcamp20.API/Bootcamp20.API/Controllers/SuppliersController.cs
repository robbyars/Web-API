using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Bootcamp20.API.BussineesLogic.Service;
using DataAccess.Model;
using DataAccess.Param;

namespace Bootcamp20.API.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class SuppliersController : ApiController
    {
        private readonly ISupplierService _supplierService;
        public SuppliersController() { }
        public SuppliersController(ISupplierService supplierservice)
        {
            this._supplierService = supplierservice;
        }

        
        // GET: api/Suppliers
        public System.Web.Http.Results.JsonResult<IEnumerable<SupplierParam>> Get()
        {
            IEnumerable<SupplierParam> list_supplier = _supplierService.Get().Select(x => new SupplierParam
            {
                Id = x.Id,
                Name = x.Name,
                IsDelete = x.IsDelete,
                CreateDate = Convert.ToDateTime(x.CreateDate),
                UpdateDate = Convert.ToDateTime(x.UpdateDate),
                DeleteDate = Convert.ToDateTime(x.DeleteDate)
            });
            return Json(list_supplier);
        }

        // GET: api/Suppliers/5
        [HttpGet]
        public SupplierParam Get(int id)
        {
            return _supplierService.Get(id);
        }

        [HttpGet]
        public System.Web.Http.Results.JsonResult<IEnumerable<SupplierParam>> Search(string name)
        {
            IEnumerable<SupplierParam> list_supplier = _supplierService.Search(name).Select(x => new SupplierParam
            {
                Id = x.Id,
                Name = x.Name,
                IsDelete = x.IsDelete,
                CreateDate = Convert.ToDateTime(x.CreateDate),
                UpdateDate = Convert.ToDateTime(x.UpdateDate),
                DeleteDate = Convert.ToDateTime(x.DeleteDate)
            });
            return Json(list_supplier);
        }

        [HttpGet]
        public System.Web.Http.Results.JsonResult<IEnumerable<SupplierParam>> SearchByDate(string month)
        {
            IEnumerable<SupplierParam> list_supplier = _supplierService.SearchByDate(month).Select(x => new SupplierParam
            {
                Id = x.Id,
                Name = x.Name,
                IsDelete = x.IsDelete,
                CreateDate = Convert.ToDateTime(x.CreateDate),
                UpdateDate = Convert.ToDateTime(x.UpdateDate),
                DeleteDate = Convert.ToDateTime(x.DeleteDate)
            });
            return Json(list_supplier);
        }

        // POST: api/Suppliers
        [HttpPost]
        public void Post(SupplierParam supplierparam)
        {
            _supplierService.Insert(supplierparam);
        }

        //PUT: api/Suppliers/5
        [HttpPut]
        public void Put(SupplierParam supplierparam)
        {
            _supplierService.Update(supplierparam);

        }

        // DELETE: api/Suppliers/5
        [HttpDelete]
        public void Delete(int id)
        {
            _supplierService.Delete(id);
        }
    }
}
