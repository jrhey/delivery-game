using UnityEngine;
using Events.FoodOrders;

public class RestaurantController : MonoBehaviour
{
    public Transform[] foodSpawners;
    public GameObject foodToSpawn;
    public OrderCreatedEvent orderCreatedEvent;
    public OrderReadyForCollectionEvent orderReadyForCollectionEvent;

    private readonly bool _ableToSpawnFood = true;
    private int _currentSpawnIndex = 0;

    void OnEnable()
    {
        orderCreatedEvent.orderCreated += CreateOrder;
    }

    private void CreateOrder(OrderRecord orderRecord)
    {
        print($"order placed by customer {orderRecord.customer.name}");
        if (_ableToSpawnFood)
        {
            print($"order confirmed by {orderRecord.restaurant.name}");
            var foodObject = SpawnFoodForCollection(foodSpawners[_currentSpawnIndex]);
            
            var orderReceipt = ScriptableObject.CreateInstance<OrderReceipt>();
            orderReceipt.orderRecord = orderRecord;
            orderReceipt.orderItem = foodObject;
            orderReadyForCollectionEvent.RaiseEvent(orderReceipt);
        }
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
        orderCreatedEvent.orderCreated -= CreateOrder;
    }
}