using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityProduct
    {
        public int Id { get; set; }          
        public string Name { get; set; }       
        public int CategoryId { get; set; }    
        public decimal Price { get; set; }    
        public int StockQuantity { get; set; } 
        public bool IsActive { get; set; }     

        public override string ToString()
        {
            return Name; 
        }

    }
}
