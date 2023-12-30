using UnityEngine;
using Events.Publishers;
using Services.FoodOrders.Models;

namespace GameObjects.Restaurant.Controllers
{
    public class RestaurantController : MonoBehaviour
    {
        [SerializeField] private Transform foodSpawnLocation;
        [SerializeField] private GameObject foodToSpawn;
        [SerializeField] private OrderPlacedPublisher orderPlacedPublisher;
        [SerializeField] private OrderReadyForCollectionPublisher orderReadyForCollectionPublisher;

        private readonly bool _ableToSpawnFood = true;

        void OnEnable()
        {
            orderPlacedPublisher.Event.AddListener(PrepareOrderForCollection);
        }

        private void PrepareOrderForCollection(OrderReceipt orderReceipt)
        {
            if (!_ableToSpawnFood) return;
            
            var foodObject = SpawnFoodForCollection(foodSpawnLocation);
            orderReceipt.orderItem = foodObject;
            orderReceipt.restaurant = transform;

            orderReadyForCollectionPublisher.RaiseEvent(orderReceipt);
        }

        private Transform SpawnFoodForCollection(Transform spawnTransform)
        {
            var foodInstance = Instantiate(foodToSpawn, spawnTransform.position, spawnTransform.rotation);
            foodInstance.transform.SetParent(spawnTransform);
            print($"Order ready for collection at {foodInstance.transform.position}");
            return spawnTransform;
        }

        private void OnDisable()
        {
            orderPlacedPublisher.Event.RemoveListener(PrepareOrderForCollection);
        }
    }
}