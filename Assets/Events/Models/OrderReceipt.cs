using UnityEngine;

namespace Services.FoodOrders.Models
{
    [CreateAssetMenu(menuName = "Models/Orders/Receipt")]
    public class OrderReceipt : ScriptableObject
    {
        public Transform customer;
        public Transform restaurant;
        public Transform orderItem;
    }
}