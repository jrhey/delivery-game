using UnityEngine;

namespace Services.FoodOrders.Models
{
    public class OrderReceipt : ScriptableObject
    {
        public OrderRecord orderRecord;
        public Transform orderItem;
    }
}