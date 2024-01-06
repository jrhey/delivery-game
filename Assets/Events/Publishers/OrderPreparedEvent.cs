using UnityEngine;
using UnityEngine.Events;
using Events.Models;

namespace Events.Publishers
{
    [CreateAssetMenu(menuName = "Events/Orders/Prepared")]

    public class OrderPreparedEvent : ScriptableObject
    {
        public UnityEvent<OrderReceipt> Event;

        public void RaiseEvent(OrderReceipt orderReceipt)
        {
            Event.Invoke(orderReceipt);
        }
    }
}