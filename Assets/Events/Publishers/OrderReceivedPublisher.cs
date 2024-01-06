using Events.Models;
using UnityEngine;
using UnityEngine.Events;

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