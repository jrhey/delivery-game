using UnityEngine;

using Services.FoodOrders.Publishers;
using Services.FoodOrders.Models;

namespace Restaurant
{
    public class RestaurantController : MonoBehaviour
    {
        public Transform[] foodSpawners;
        public GameObject foodToSpawn;
        public OrderPlacedPublisher orderPlacedPublisher;
        public OrderReadyForCollectionPublisher orderReadyForCollectionPublisher;

        private readonly bool _ableToSpawnFood = true;
        private int _currentSpawnIndex = 0;

        void OnEnable()
        {
            orderPlacedPublisher.Event.AddListener(CreateOrder);
        }

        private void CreateOrder(OrderRecord orderRecord)
        {
            print($"order placed by customer {orderRecord.customer.name}");
            if (!_ableToSpawnFood) return;
            
            print($"order confirmed by {orderRecord.restaurant.name}");
            var foodObject = SpawnFoodForCollection(foodSpawners[_currentSpawnIndex]);

            var orderReceipt = ScriptableObject.CreateInstance<OrderReceipt>();
            orderReceipt.orderRecord = orderRecord;
            orderReceipt.orderItem = foodObject;
            orderReadyForCollectionPublisher.RaiseEvent(orderReceipt);
        }

        private Transform SpawnFoodForCollection(Transform spawnTransform)
        {
            var foodInstance = Instantiate(foodToSpawn, spawnTransform.position, spawnTransform.rotation);
            foodInstance.transform.SetParent(spawnTransform);
            _currentSpawnIndex += 1;
            print($"Order ready for collection at {foodInstance.transform.position}");
            return spawnTransform;
        }

        private void OnDisable()
        {
            orderPlacedPublisher.Event.RemoveListener(CreateOrder);
        }
    }
}