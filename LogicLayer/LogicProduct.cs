using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace LogicLayer
{
    public class LogicProduct
    {
        DalProduct dal = new DalProduct();
        public List<EntityProduct> GetAll() => dal.GetAll();
        public void Add(EntityProduct p) => dal.Add(p);
        public void Update(EntityProduct p) => dal.Update(p);
        public void Delete(int id) => dal.Delete(id);
        public void StokDus(int id, int miktar) => dal.StokDus(id, miktar);
        public EntityProduct GetById(int id) => dal.GetById(id);
    }
}
