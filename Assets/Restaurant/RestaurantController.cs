using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class RestaurantController : MonoBehaviour
{
    public Transform[] foodSpawners;
    public GameObject foodToSpawn;
    public FoodOrderCreatedEvent foodOrderCreatedEvent;
    
    private readonly bool _ableToSpawnFood = true;
    private int _currentSpawnIndex = 0;
    
    void Start()
    {
        foodOrderCreatedEvent.orderCreated += CreateOrder;
    }
    private void CreateOrder(GameObject customer)
    {
        print($"order received by customer {customer.name}");
        if (_ableToSpawnFood)
        {
            SpawnFoodForCollection(foodSpawners[_currentSpawnIndex]);
        }
    }

    private void SpawnFoodForCollection(Transform spawnTransform)
    {
        var foodInstance = Instantiate(foodToSpawn, spawnTransform.position, spawnTransform.rotation);
        foodInstance.transform.SetParent(spawnTransform);
        _currentSpawnIndex += 1;
    }
    
    private void OnDestroy()
    {
        foodOrderCreatedEvent.orderCreated -= CreateOrder;
    }
}
