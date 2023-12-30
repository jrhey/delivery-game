using UnityEngine;

namespace Services.FoodOrders.Models
{
    [CreateAssetMenu(menuName = "Models/Orders/Record")]
    public class OrderRecord : ScriptableObject
    {
        public Transform customer;
        public Transform restaurant;
    }
}