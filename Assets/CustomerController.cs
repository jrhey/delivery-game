using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class CustomerController : MonoBehaviour, IPointerClickHandler
{
    public Transform[] restaurants;
    public FoodOrderCreatedEvent foodOrderCreatedEvent;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        print("Order created");
        foodOrderCreatedEvent.RaiseEvent(gameObject);
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
