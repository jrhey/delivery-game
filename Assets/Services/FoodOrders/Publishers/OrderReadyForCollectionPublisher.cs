using UnityEngine;
using UnityEngine.Events;
using Services.FoodOrders.Models;

namespace Services.FoodOrders.Publishers
{
    [CreateAssetMenu(menuName = "Events/Food/Ready For Collection")]

    public class OrderReadyForCollectionPublisher : ScriptableObject
    {
        public UnityEvent<OrderReceipt> Event;

        public void RaiseEvent(OrderReceipt orderReceipt)
        {
            Event.Invoke(orderReceipt);
        }
    }
}