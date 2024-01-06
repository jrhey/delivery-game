using Events.Models;
using UnityEngine;
using UnityEngine.Events;

namespace Events.Publishers
{
    [CreateAssetMenu(menuName = "Events/Orders/Delivered")]
    public class OrderDeliveredEvent : ScriptableObject
    {
        public UnityEvent<OrderReceipt> Event;

        public void RaiseEvent(OrderReceipt orderReceipt)
        {
            Event.Invoke(orderReceipt);
        }
    }
}