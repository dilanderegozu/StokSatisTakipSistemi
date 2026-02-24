using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace LogicLayer
{
    public class LogicOrder
    {
        DalOrder dalOrder = new DalOrder();
        DalOrderDetail dalDetail = new DalOrderDetail();
        DalProduct dalProduct = new DalProduct();

        public void SatisiTamamla(EntityOrder order,List <EntityOrderDetail> detaylar)
        {
            int orderId = dalOrder.Add(order);
            foreach (var detay in detaylar)
            {
                detay.OrderId = orderId;
                dalDetail.Add(detay);
                dalProduct.StokDus(detay.ProductId, detay.Quantity);
            }
        }

        public List<EntityOrder> GetAll() => dalOrder.GetAll();
        public decimal GetToplamCiro() => dalOrder.GetToplamCiro();
        public decimal GetGunlukCiro() => dalOrder.GetGunlukCiro();
        public string GetEnCokSatilanUrun() => dalOrder.GetEnCokSatilanUrun();
    }
}
