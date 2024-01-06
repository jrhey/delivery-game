using UnityEngine;
using UnityEngine.EventSystems;
using GameObjects.Drone.Controllers;
using Behaviours;
using Components;
using Events.Models;
using Events.Publishers;

namespace GameObjects.Restaurant.Controllers
{
    public partial class DroneFactoryController : MonoBehaviour
    {
        [SerializeField] private OrderPreparedEvent orderPreparedConsumer;
        
        public GameObject[] drones;
        
        private LineToPointRenderer _lineToPointRenderer;

        private void OnEnable()
        {
            orderPreparedConsumer.Event.AddListener(DeliveryReadyForDispatch);
        }

        private void OnDisable()
        {
            orderPreparedConsumer.Event.RemoveListener(DeliveryReadyForDispatch);
        }

        private void Start()
        {
            var childObject = new GameObject
            {
                transform =
                {
                    parent = transform
                }
            };
            var lineRenderer = childObject.AddComponent<LineRenderer>();
            _lineToPointRenderer = new LineToPointRenderer(lineRenderer);
        }

        private void DeliveryReadyForDispatch(OrderReceipt orderReceipt)
        {
            var drone = Instantiate(drones[0], transform);
            var parcelCarrier = drone.GetComponent<ParcelCarrier>();
            parcelCarrier.orderReceipt = orderReceipt;
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
            var position = transform.position;
            var basePosition = new Vector3(position.x, 0, position.z);
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
}