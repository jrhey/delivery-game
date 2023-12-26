using UnityEngine;

namespace Events.FoodOrders
{
    public class OrderReceipt : ScriptableObject
    {
        public OrderRecord orderRecord;
        public Transform orderItem;
    }
}