using Events.FoodOrders;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Customer.Controllers
{
    public partial class CustomerController : MonoBehaviour
    {
        public Transform[] restaurants;
        public OrderPlacedPublisher orderPlacedPublisher;

        private void Start()
        {
            // StartCoroutine(GenerateOrder(3));
        }

        // private IEnumerator GenerateOrder(float waitTimeSeconds)
        // {
        //     yield return new WaitForSeconds(waitTimeSeconds);
        //     // FoodOrderService.PlaceOrder(transform, restaurants[0]);
        // }
        private void PlaceOrder(Transform customer, Transform restaurant)
        {
            Debug.Log("Generating order");
            var orderRecord = ScriptableObject.CreateInstance<OrderRecord>();
            orderRecord.customer = customer;
            orderRecord.restaurant = restaurant;
                
            Debug.Log("Placing order");
            orderPlacedPublisher.RaiseEvent(orderRecord);
            Debug.Log("Order placed");
        }
    }

    public partial class CustomerController : IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            print("clicked");
            PlaceOrder(transform, restaurants[0]);
        }
    }
    
}