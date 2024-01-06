using UnityEngine;

namespace Events.Models
{
    [CreateAssetMenu(menuName = "Models/Orders/Receipt")]
    public class OrderReceipt : ScriptableObject
    {
        public Transform customer;
        public Transform restaurant;
        public Transform orderItem;
    }
}