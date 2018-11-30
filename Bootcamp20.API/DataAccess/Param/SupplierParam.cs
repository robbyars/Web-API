using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Param
{
    public class SupplierParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool? IsDelete { get; set; }
        
        public SupplierParam() { }
        public SupplierParam(Supplier supplier)
        {
            this.Id = supplier.Id;
            this.Name = supplier.Name;
            this.CreateDate = supplier.CreateDate;
            this.UpdateDate = supplier.UpdateDate;
            this.DeleteDate = supplier.DeleteDate;
            this.IsDelete = supplier.IsDelete;
        }
    }
}
