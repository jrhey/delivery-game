using UnityEngine;
using UnityEngine.Events;
using Services.FoodOrders.Models;

namespace Events.Publishers
{
    [CreateAssetMenu(menuName = "Events/Orders/Order Placed")]
    public class OrderPlacedPublisher : ScriptableObject
    {
        public UnityEvent<OrderReceipt> Event;

        public void RaiseEvent(OrderReceipt orderReceipt)
        {
            Event.Invoke(orderReceipt);
        }
    }
}