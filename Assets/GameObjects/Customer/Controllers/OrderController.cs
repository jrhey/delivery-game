using Services.FoodOrders.Models;
using UnityEngine;

namespace GameObjects.Customer.Controllers
{
    public class OrderController : MonoBehaviour
    {
        [SerializeField] public OrderReceipt orderReceipt;
        [SerializeField] private DeliveryPoint _deliveryPoint;

        private void OnEnable()
        {
            _deliveryPoint.OrderArrived += OnOrderArrival;
        }

        private void OnOrderArrival(OrderReceipt orderReceipt)
        {
            print("Order controller made aware that a package was received");
        }
    }
}