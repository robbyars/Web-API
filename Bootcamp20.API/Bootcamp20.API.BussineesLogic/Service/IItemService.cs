using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;

namespace Bootcamp20.API.BussineesLogic.Service
{
    public interface IItemService
    {
        List<Item> Get();
        List<Item> Search(string name);
        ItemParam Get(int? id);
        bool Insert(ItemParam itemparam);
        bool Update(ItemParam itemparam);
        bool Delete(int? id);
    }
}
