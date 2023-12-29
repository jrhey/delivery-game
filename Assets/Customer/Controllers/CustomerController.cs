using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

using Services.FoodOrders.Publishers;
using Services.FoodOrders.Models;

namespace Customer.Controllers
{
    public partial class CustomerController : MonoBehaviour
    {
        public Transform[] restaurants;
        public OrderPlacedPublisher orderPlacedPublisher;
        public bool canGenerateOrders = false;
        public int minSecondsBeforeNextOrder = 3;
        public int maxSecondsBeforeNextOrder = 10;

        private float _secondsBeforeNextOrder;

        private void Start()
        {
            _secondsBeforeNextOrder = GenerateRandomNumber(minSecondsBeforeNextOrder, maxSecondsBeforeNextOrder);
            StartCoroutine(GenerateOrdersRoutine());
        }

        private IEnumerator GenerateOrdersRoutine()
        {
            while (canGenerateOrders)
            {
                yield return new WaitForSeconds(_secondsBeforeNextOrder);
                PlaceOrder(transform, restaurants[0]);
                _secondsBeforeNextOrder = GenerateRandomNumber(minSecondsBeforeNextOrder, maxSecondsBeforeNextOrder);
            }
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        private void PlaceOrder(Transform customer, Transform restaurant)
        {
            var orderRecord = ScriptableObject.CreateInstance<OrderRecord>();
            orderRecord.customer = customer;
            orderRecord.restaurant = restaurant;
                
            orderPlacedPublisher.RaiseEvent(orderRecord);
        }
        
        static int GenerateRandomNumber(int minValue, int maxValue)
        {
            // Ensure that minValue is less than maxValue
            if (minValue > maxValue)
            {
                throw new ArgumentException("minValue must be less than or equal to maxValue");
            }

            // Create a Random object
            var rng = new System.Random();
            
            // Generate a random number within the specified range
            return rng.Next(minValue, maxValue + 1);
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