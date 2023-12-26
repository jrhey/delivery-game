using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Create Food Order")]
public class FoodOrderCreatedEvent : ScriptableObject
{
    public UnityAction<GameObject> orderCreated;

    public void RaiseEvent(GameObject customer)
    {
        orderCreated.Invoke(customer);
    }
}