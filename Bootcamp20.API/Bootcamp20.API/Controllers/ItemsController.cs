using System;
using System.Collections.Generic;
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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemsController : ApiController
    {
        private readonly IItemService _itemService;
        public ItemsController() { }
        public ItemsController(IItemService itemservice)
        {
            this._itemService = itemservice;
        }

        // GET: api/Items
        public System.Web.Http.Results.JsonResult<IEnumerable<ItemParam>> Get()
        {
            IEnumerable<ItemParam> list_item = _itemService.Get().Select(x => new ItemParam
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Supplier = x.Supplier.Name, 
                IsDelete = x.IsDelete,
                CreateDate = Convert.ToDateTime(x.CreateDate),
                UpdateDate = Convert.ToDateTime(x.UpdateDate),
                DeleteDate = Convert.ToDateTime(x.DeleteDate)
            });
            return Json(list_item);
        }

        // GET: api/Items/5
        [HttpGet]
        public ItemParam Get(int id)
        {
            return _itemService.Get(id);
        }

        [HttpGet]
        public System.Web.Http.Results.JsonResult<IEnumerable<ItemParam>> Search(string name)
        {
            IEnumerable<ItemParam> list_item = _itemService.Search(name).Select(x => new ItemParam
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                IsDelete = x.IsDelete,
                CreateDate = Convert.ToDateTime(x.CreateDate),
                UpdateDate = Convert.ToDateTime(x.UpdateDate),
                DeleteDate = Convert.ToDateTime(x.DeleteDate)
            });
            return Json(list_item);
        }

        // POST: api/Items
        [HttpPost]
        public void Post(ItemParam itemparam)
        {
            _itemService.Insert(itemparam);
        }

        // PUT: api/Items/5
        [HttpPut]
        public void Put(ItemParam itemparam)
        {
            _itemService.Update(itemparam);

        }

        // DELETE: api/Items/5
        [HttpDelete]
        public void Delete(int id)
        {
            _itemService.Delete(id);
        }

    }
}
