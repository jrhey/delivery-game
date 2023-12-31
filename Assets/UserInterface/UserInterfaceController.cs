using Events.Models;
using Events.Publishers;
using TMPro;
using UnityEngine;

namespace UserInterface
{
    public class UserInterfaceController : MonoBehaviour
    {
        [SerializeField] private OrderCreatedEvent orderCreatedConsumer;
        [SerializeField] private OrderDeliveredEvent orderDeliveredConsumer;
        
        [SerializeField] private TextMeshProUGUI ordersOpenedLabel;
        private int _ordersCreated = 0; 
        
        [SerializeField] private TextMeshProUGUI ordersReceivedLabel;
        private int _ordersReceived = 0; 

        private void OnEnable()
        {
            orderCreatedConsumer.Event.AddListener(UpdateOrdersOpenedLabel);
            orderDeliveredConsumer.Event.AddListener(UpdateOrdersReceivedLabel);
        }

        void Start()
        {
            ordersOpenedLabel.text = $"Orders created: {_ordersCreated.ToString()}";
            ordersReceivedLabel.text =  $"Orders received: {_ordersReceived.ToString()}";
        }

        private void UpdateOrdersOpenedLabel(OrderReceipt _)
        {
            ordersOpenedLabel.text = $"Orders created: {(_ordersCreated += 1).ToString()}";
        }
        
        private void UpdateOrdersReceivedLabel(OrderReceipt _)
        {
            ordersReceivedLabel.text = $"Orders received: {(_ordersReceived += 1).ToString()}";
        }
    }
}