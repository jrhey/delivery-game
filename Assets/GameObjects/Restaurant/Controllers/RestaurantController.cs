using UnityEngine;
using Events.Publishers;
using Services.FoodOrders.Models;

namespace GameObjects.Restaurant.Controllers
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
            orderPlacedPublisher.Event.AddListener(PrepareOrderForCollection);
        }

        private void PrepareOrderForCollection(OrderReceipt orderReceipt)
        {
            if (!_ableToSpawnFood) return;
            
            var foodObject = SpawnFoodForCollection(foodSpawners[_currentSpawnIndex]);
            orderReceipt.orderItem = foodObject;
            orderReceipt.restaurant = transform;

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
            orderPlacedPublisher.Event.RemoveListener(PrepareOrderForCollection);
        }
    }
}