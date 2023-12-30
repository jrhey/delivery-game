using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Events.Publishers;
using GameObjects.Customer;
using Services.FoodOrders.Models;

namespace Customer.Controllers
{
    public partial class CustomerController : MonoBehaviour
    {
        [SerializeField] private Transform[] restaurants;
        [SerializeField] private OrderPlacedPublisher orderPlacedPublisher;
        [SerializeField] private GameObject cameraView;
        [SerializeField] private GameObject orderPlacedIcon;
        [SerializeField] private bool canGenerateOrders = true;
        [SerializeField] private int minSecondsBeforeNextOrder = 1;
        [SerializeField] private int maxSecondsBeforeNextOrder = 3;

        [SerializeField] private Transform deliveryPoint;
        [SerializeField] public OrderReceipt orderReceipt;

        private float _secondsBeforeNextOrder;
        private bool _orderRoutineEnabled = true;

        private void OnEnable()
        {
            var deliveryPointScript = deliveryPoint.GetComponent<DeliveryPoint>();
            deliveryPointScript.OrderArrived += OnOrderArrival;
            canGenerateOrders = true;
            orderPlacedIcon.SetActive(false);
            orderPlacedIcon.transform.LookAt(cameraView.transform);
        }

        private void Start()
        {
            print(
                $"starting with min seconds: {minSecondsBeforeNextOrder} and max seconds: {maxSecondsBeforeNextOrder}");
            _secondsBeforeNextOrder = GenerateRandomNumber(minSecondsBeforeNextOrder, maxSecondsBeforeNextOrder);
            StartCoroutine(GenerateOrdersRoutine());
        }

        private IEnumerator GenerateOrdersRoutine()
        {
            while (_orderRoutineEnabled)
            {
                yield return new WaitForSeconds(_secondsBeforeNextOrder);
                PlaceOrder(transform, restaurants[0]);
                _secondsBeforeNextOrder = GenerateRandomNumber(minSecondsBeforeNextOrder, maxSecondsBeforeNextOrder);
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void PlaceOrder(Transform customer, Transform restaurant)
        {
            if (!canGenerateOrders) return;
                
            var receipt = ScriptableObject.CreateInstance<OrderReceipt>();
            receipt.customer = deliveryPoint;
            receipt.restaurant = new RectTransform();
            receipt.orderItem = new RectTransform();

            orderPlacedPublisher.RaiseEvent(receipt);
            orderPlacedIcon.SetActive(true);
            canGenerateOrders = false;
        }

        private void OnOrderArrival(OrderReceipt orderReceipt)
        {
            print("Order arrived");
            orderPlacedIcon.SetActive(false);
            canGenerateOrders = true;
        }

        static int GenerateRandomNumber(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("minValue must be less than or equal to maxValue");
            }

            var rng = new System.Random();

            return rng.Next(minValue, maxValue + 1);
        }
    }

    public partial class CustomerController : IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            PlaceOrder(transform, restaurants[0]);
        }
    }
}