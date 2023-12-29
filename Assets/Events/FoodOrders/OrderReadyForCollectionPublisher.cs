using UnityEngine;
using UnityEngine.Events;

namespace Events.FoodOrders
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