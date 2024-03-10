using MediatR;
using Order.Domain.Events;
using Order.Domain.SeedWork;

namespace Order.Domain.AggregateModels.OrderModels
{
    public class Order: BaseEntity,IAggregateRoot
    {
        public DateTime OrderDate { get; private set; }
        public string Description { get; private set; }
        public Address Address { get; private set; }
        public string UserName { get; private set; }
        public string OrderStatus { get; private set; }
        public ICollection<OrderItem> OrderItems { get; private set; }

        public Order(DateTime orderDate, string description, Address address, string userName, string orderStatus, ICollection<OrderItem> orderItems)
        {
            if (orderDate < DateTime.Now)
            {
                throw new Exception("Orderdate must be greater than now");
            }

            if (address.City == "")
            {
                throw new Exception("Orderdate cannot be empty");
            }

            OrderDate = orderDate;
            Description = description;
            Address = address;
            UserName = userName;
            OrderStatus = orderStatus;
            OrderItems = orderItems;

            AddDomainEvents(new OrderStartedDomainEvent(userName, this));
        }

        public void AddOrderItem(int quantity, decimal price, int productId)
        {
            OrderItems.Add(new OrderItem(quantity, price, productId));
        }
    }    

}
