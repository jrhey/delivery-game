using Behaviours;
using UnityEngine;
using UnityEngine.EventSystems;
using Renderers;

using Events.Publishers;
using GameObjects.Drone.Controllers;
using Services.FoodOrders.Models;

public partial class DroneFactoryController : MonoBehaviour
{
    public GameObject[] drones;
    private LineToPointRenderer _lineToPointRenderer;
    [SerializeField] private OrderReadyForCollectionPublisher orderReadyForCollectionPublisher;

    private void OnEnable()
    {
        orderReadyForCollectionPublisher.Event.AddListener(DeliveryReadyForDispatch);
    }

    private void OnDisable()
    {
        orderReadyForCollectionPublisher.Event.RemoveListener(DeliveryReadyForDispatch);
    }

    private void Start()
    {
        var childObject = new GameObject();
        childObject.transform.parent = transform;
        var lineRenderer = childObject.AddComponent<LineRenderer>();
        _lineToPointRenderer = new LineToPointRenderer(lineRenderer);
    }

    private void DeliveryReadyForDispatch(OrderReceipt orderReceipt)
    {
        var drone = Instantiate(drones[0], transform);
        var parcelCarrier = drone.GetComponent<ParcelCarrier>();
        parcelCarrier.OrderReceipt = orderReceipt;
        DispatchDroneToTargets(drone, new[] {  orderReceipt.orderItem, orderReceipt.customer });
    }

    private void DispatchDroneToTargets(GameObject drone, Transform[] targets)
    {
        var flightController = drone.GetComponent<FlightController>();
        flightController.targets = targets;
        flightController.droneFactory = transform;
    }
}
public partial class DroneFactoryController : IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        var basePosition = new Vector3(transform.position.x, 0, transform.position.z);
        _lineToPointRenderer.Render(basePosition, eventData.pointerCurrentRaycast.worldPosition);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("begin drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _lineToPointRenderer.Clear();
        var drone = Instantiate(drones[0], transform);
        DispatchDroneToTargets(drone, new[] { eventData.pointerCurrentRaycast.gameObject.transform });
    }
}