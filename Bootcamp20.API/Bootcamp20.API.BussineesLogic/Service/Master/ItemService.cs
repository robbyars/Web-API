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
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemrepo;
        public ItemService() { }
        public ItemService(IItemRepository itemrepository)
        {
            this._itemrepo = itemrepository;
        }
        public bool Delete(int? id)
        {
            return _itemrepo.Delete(id);
        }

        public List<Item> Get()
        {
            return _itemrepo.Get();
        }

        public ItemParam Get(int? id)
        {
            return _itemrepo.Get(id);
        }

        public bool Insert(ItemParam itemparam)
        {
            return _itemrepo.Insert(itemparam);
        }

        public List<Item> Search(string name)
        {
            return _itemrepo.Search(name);
        }

        public bool Update(int? id, ItemParam itemparam)
        {
            return _itemrepo.Update(id, itemparam);
        }
    }
}
