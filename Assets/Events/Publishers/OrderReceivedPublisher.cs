using UnityEngine;
using UnityEngine.Events;
using Services.FoodOrders.Models;

namespace Events.Publishers
{
    [CreateAssetMenu(menuName = "Events/Orders/Order Received")]
    public class OrderReceivedPublisher : ScriptableObject
    {
        public UnityEvent<OrderReceipt> Event;

        public void RaiseEvent(OrderReceipt orderReceipt)
        {
            Event.Invoke(orderReceipt);
        }
    }
}