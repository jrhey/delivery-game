using System;
using Services.FoodOrders.Models;
using Events.Publishers;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UserInterface
{
    public class UserInterfaceController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ordersOpenedLabel;
        [SerializeField] private OrderPlacedPublisher orderPlacedPublisher;
        private int _ordersCreated = 0; 
        
        [SerializeField] private TextMeshProUGUI ordersReceivedLabel;
        [SerializeField] private OrderReceivedPublisher orderReceivedPublisher;
        private int _ordersReceived = 0; 

        private void OnEnable()
        {
            orderPlacedPublisher.Event.AddListener(UpdateOrdersOpenedLabel);
            orderReceivedPublisher.Event.AddListener(UpdateOrdersReceivedLabel);
        }

        void Start()
        {
            ordersOpenedLabel.text = $"Orders opened: {_ordersCreated.ToString()}";
            ordersReceivedLabel.text =  $"Orders received: {_ordersReceived.ToString()}";
        }

        private void UpdateOrdersOpenedLabel(OrderReceipt _)
        {
            ordersOpenedLabel.text = $"Orders opened: {(_ordersCreated += 1).ToString()}";
        }
        
        private void UpdateOrdersReceivedLabel(OrderReceipt _)
        {
            ordersReceivedLabel.text = $"Orders received: {(_ordersReceived += 1).ToString()}";
        }
    }
}