using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;

namespace Bootcamp20.API.Common.Repository
{
    public interface IItemRepository
    {
        List<Item> Get();
        List<Item> Search(string name);
        ItemParam Get(int? id);
        bool Insert(ItemParam itemparam);
        bool Update(int? id, ItemParam itemparam);
        bool Delete(int? id);
    }
}
