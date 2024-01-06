using UnityEngine;
using UnityEngine.Events;
using Events.Models;

namespace Events.Publishers
{
    [CreateAssetMenu(menuName = "Events/Orders/Ready For Collection")]

    public class OrderReadyForCollectionPublisher : ScriptableObject
    {
        public UnityEvent<OrderReceipt> Event;

        public void RaiseEvent(OrderReceipt orderReceipt)
        {
            Event.Invoke(orderReceipt);
        }
    }
}