using System;
using Drone.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;
using Renderers;
using UnityEngine.Serialization;

using Services.FoodOrders.Publishers;
using Services.FoodOrders.Models;

public partial class DroneFactoryController : MonoBehaviour
{
    [FormerlySerializedAs("orderReadyForCollectionEvent")] public OrderReadyForCollectionPublisher orderReadyForCollectionPublisher;
    public GameObject[] drones;
    private LineToPointRenderer _lineToPointRenderer;

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
        var lineRenderer = gameObject.AddComponent<LineRenderer>();
        _lineToPointRenderer = new LineToPointRenderer(lineRenderer);
    }

    private void DeliveryReadyForDispatch(OrderReceipt orderReceipt)
    {
        var drone = Instantiate(drones[0], transform);
        DispatchDroneToTargets(drone, new[] { orderReceipt.orderItem, orderReceipt.orderRecord.customer });
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