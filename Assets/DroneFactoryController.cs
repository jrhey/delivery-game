using Drone.Controllers;
using Events.FoodOrders;
using UnityEngine;

public class DroneFactoryController : MonoBehaviour
{
    public OrderReadyForCollectionEvent orderReadyForCollectionEvent;
    public GameObject[] drones;

    private void OnEnable()
    {
        orderReadyForCollectionEvent.orderReadyForCollection += DeliveryReadyForDispatch;
    }

    private void OnDisable()
    {
        orderReadyForCollectionEvent.orderReadyForCollection -= DeliveryReadyForDispatch;
    }

    private void DeliveryReadyForDispatch(OrderReceipt orderReceipt)
    {
        var drone = Instantiate(drones[0], transform);
        var flightController = drone.GetComponent<FlightController>();
        flightController.targets = new[] { orderReceipt.orderRecord.restaurant, orderReceipt.orderRecord.customer };
        flightController.droneFactory = transform;
        print($"Dispatching drone for {orderReceipt.orderRecord.customer.name}");
    }
}
