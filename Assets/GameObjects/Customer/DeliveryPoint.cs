using Behaviours;
using Events.Models;
using Events.Publishers;
using UnityEngine;
using UnityEngine.Events;

namespace GameObjects.Customer
{
    // Emits an `OrderReceivedEvent`
    // Can notify other classes directly via `OrderArrived` delegate
    public class DeliveryPoint : MonoBehaviour
    {
        [SerializeField] private OrderDeliveredEvent orderDeliveredProducer;
        public UnityAction<OrderReceipt> OrderArrived;

        private void OnTriggerEnter(Collider other)
        {
            var parcelCarrier = other.gameObject.GetComponent<ParcelCarrier>();
            if (parcelCarrier is null)
                return;
            
            var orderReceipt = parcelCarrier.orderReceipt;
            OrderArrived.Invoke(orderReceipt);
            orderDeliveredProducer.RaiseEvent(orderReceipt);
        }
    }
}