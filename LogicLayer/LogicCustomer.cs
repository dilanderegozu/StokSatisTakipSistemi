using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;
namespace LogicLayer
{
    public class LogicCustomer
    {
        DalCustomer dal = new DalCustomer();
        public List<EntityCustomer> GetAll() => dal.GetAll();
        public void Add(EntityCustomer c) => dal.Add(c);
        public void Update(EntityCustomer c) => dal.Update(c);
        public void Delete(int id) => dal.Delete(id);
    }
}
