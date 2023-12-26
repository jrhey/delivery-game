using UnityEngine;
using UnityEngine.Events;

namespace Events.FoodOrders
{
    [CreateAssetMenu(menuName = "Events/Order Ready For Collection")]

    public class OrderReadyForCollectionEvent : ScriptableObject
    {
        public UnityAction<OrderReceipt> orderReadyForCollection;

        public void RaiseEvent(OrderReceipt orderReceipt)
        {
            orderReadyForCollection.Invoke(orderReceipt);
        }
    }
}