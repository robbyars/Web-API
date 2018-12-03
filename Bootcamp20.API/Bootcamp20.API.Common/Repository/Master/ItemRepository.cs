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
    public class ItemRepository : IItemRepository
    {
        MyContext _context = new MyContext();
        bool status = false;
        public bool Delete(int? id)
        {
            var item = _context.Item.Find(id);
            item.IsDelete = true;
            item.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            _context.Entry(item).State = EntityState.Modified;
            var result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Item> Get()
        {
            return _context.Item.Where(x => x.IsDelete == false).ToList();
        }

        public ItemParam Get(int? id)
        {
            var itparam = _context.Item.SingleOrDefault(x => x.Id == id && x.IsDelete == false);
            ItemParam itnew = new ItemParam(itparam);
            return itnew;
        }

        public bool Insert(ItemParam itemparam)
        {
            Item item = new Item(itemparam);
            item.Supplier = _context.Supplier.Find(Convert.ToInt16(itemparam.Supplier));
            //item.Supplier = _context.Supplier.SingleOrDefault(x => x.Id == itemparam.Supplier);
            _context.Item.Add(item);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Item> Search(ItemParam itemparam)
        {
            if(itemparam.searchBy == 1)
            {
                return _context.Item.Include("Supplier").Where(x => x.Name.Contains(itemparam.Name) && x.IsDelete == false).ToList();
            } else if (itemparam.searchBy == 2)
            {
                return _context.Item.Include("Supplier").Where(x => x.Supplier.Name.Contains(itemparam.Name) && x.IsDelete == false).ToList();
            } else if (itemparam.searchBy == 3)
            {
                int bln = Convert.ToInt16(itemparam.Name);
                return _context.Item.Include("Supplier").Where(x => x.CreateDate.Value.Month == bln && x.IsDelete == false).ToList();
            }
            else
            {
                return _context.Item.Include("Supplier").Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, ItemParam itemparam)
        {
            Item item = _context.Item.SingleOrDefault(x => x.Id == id && x.IsDelete == false);
            item.Supplier = _context.Supplier.Find(Convert.ToInt16(itemparam.Supplier));
            item.Update(itemparam);
            _context.Entry(item).State = EntityState.Modified;
            var result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
