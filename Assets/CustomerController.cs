using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Events.FoodOrders;

public class CustomerController : MonoBehaviour, IPointerClickHandler
{
    public Transform[] restaurants;
    public OrderCreatedEvent orderCreatedEvent;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        var orderRecord = ScriptableObject.CreateInstance<OrderRecord>();
        orderRecord.customer = transform;
        orderRecord.restaurant = restaurants.First();
        orderCreatedEvent.RaiseEvent(orderRecord);
    }
    
    // StartCoroutine(SpawnFoodForCollection(3));
    
    // private IEnumerator SpawnFoodForCollection(float waitTimeSeconds)
    // {
    //     while (_ableToSpawnFood)
    //     {
    //         var spawnTransform = foodSpawners[_currentSpawnIndex];
    //         SpawnFood(spawnTransform);
    //         _currentSpawnIndex += 1;
    //         yield return new WaitForSeconds(waitTimeSeconds);
    //     }
    // }
}
