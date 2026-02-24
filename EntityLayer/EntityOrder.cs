using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }   
        public DateTime OrderDate { get; set; }  
        public decimal TotalPrice { get; set; } 
    }
}
