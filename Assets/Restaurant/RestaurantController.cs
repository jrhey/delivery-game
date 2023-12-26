using System.Collections;
using UnityEngine;

public class RestaurantController : MonoBehaviour
{
    public Transform[] foodSpawners;
    public GameObject foodToSpawn;
    
    private bool _ableToSpawnFood = true;
    private int _currentSpawnIndex = 0;
    
    void Start()
    {
        StartCoroutine(SpawnFoodForCollection(3));
    }

    private IEnumerator SpawnFoodForCollection(float waitTimeSeconds)
    {
        while (_ableToSpawnFood)
        {
            var spawnTransform = foodSpawners[_currentSpawnIndex];
            var foodInstance = Instantiate(foodToSpawn, spawnTransform.position, spawnTransform.rotation);
            foodInstance.transform.SetParent(spawnTransform);
            _currentSpawnIndex += 1;
            yield return new WaitForSeconds(waitTimeSeconds);
        }
    }
}
