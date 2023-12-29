using UnityEngine;

namespace Services.FoodOrders.Models
{
    public class OrderRecord : ScriptableObject
    {
        public Transform customer;
        public Transform restaurant;
    }
}