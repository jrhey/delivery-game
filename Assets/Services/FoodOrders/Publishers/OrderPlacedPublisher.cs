using UnityEngine;
using UnityEngine.Events;

using Services.FoodOrders.Models;

namespace Services.FoodOrders.Publishers
{
    [CreateAssetMenu(menuName = "Events/Food/Order Placed")]
    public class OrderPlacedPublisher : ScriptableObject
    {
        public UnityEvent<OrderRecord> Event;

        public void RaiseEvent(OrderRecord orderRecord)
        {
            Debug.Log($"Invoking order creation {Event}");
            Event.Invoke(orderRecord);
        }
    }
}