using Core.Entities.OrderAggregate;
using Core.Specifications;

namespace Core.Interfaces
{
    public class OrderByPaymentIntentIdWithItemSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIntentIdWithItemSpecification(string paymentIntentId) 
            : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}