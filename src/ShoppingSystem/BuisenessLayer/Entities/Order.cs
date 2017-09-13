using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ShoppingSystem.Entities
{
    public class Order:ISerializable
    {
        public Order(Guid shopperId,int itemCount,decimal chargebleAmount)
        {
            ShopperId=shopperId;
            OrderNo = Guid.NewGuid();
            OrderDate = DateTime.Now;
            ItemCount = itemCount;
            ChargebleAmount = chargebleAmount;
        }        

        public Guid ShopperId { get; }
        public Guid OrderNo { get;}
        public int ItemCount { get; }
        public DateTime OrderDate { get; }
        public decimal ChargebleAmount { get; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}