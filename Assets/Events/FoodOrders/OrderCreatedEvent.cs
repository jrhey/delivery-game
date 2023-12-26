using UnityEngine;
using UnityEngine.Events;

namespace Events.FoodOrders
{
    [CreateAssetMenu(menuName = "Events/Create Food Order")]
    public class OrderCreatedEvent : ScriptableObject
    {
        public UnityAction<OrderRecord> orderCreated;

        public void RaiseEvent(OrderRecord orderRecord)
        {
            orderCreated.Invoke(orderRecord);
        }
    }
}