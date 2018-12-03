using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Param
{
    public class ItemParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int searchBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool? IsDelete { get; set; }
        public string Supplier { get; set; }
        public ItemParam() { }
        public ItemParam(Item item)
        {
            this.Id = item.Id;
            this.Supplier = item.Supplier_Id.ToString();
            this.Name = item.Name;
            this.Price = item.Price;
            this.Stock = item.Stock;
            this.CreateDate = item.CreateDate;
            this.UpdateDate = item.UpdateDate;
            this.DeleteDate = item.DeleteDate;
            this.IsDelete = item.IsDelete;
        }
    }
}
