using Events.Models;
using UnityEngine;
using Events.Publishers;

namespace GameObjects.Restaurant.Controllers
{
    public class RestaurantController : MonoBehaviour
    {
        [SerializeField] private Transform foodSpawnLocation;
        [SerializeField] private GameObject foodToSpawn;
        [SerializeField] private OrderCreatedEvent orderCreatedConsumer;
        [SerializeField] private OrderPreparedEvent orderPreparedProducer;

        private readonly bool _ableToSpawnFood = true;

        void OnEnable()
        {
            orderCreatedConsumer.Event.AddListener(PrepareOrderForCollection);
        }

        private void PrepareOrderForCollection(OrderReceipt orderReceipt)
        {
            if (!_ableToSpawnFood) return;
            
            var foodObject = SpawnFoodForCollection(foodSpawnLocation);
            orderReceipt.orderItem = foodObject;
            orderReceipt.restaurant = transform;

            orderPreparedProducer.RaiseEvent(orderReceipt);
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
            orderCreatedConsumer.Event.RemoveListener(PrepareOrderForCollection);
        }
    }
}