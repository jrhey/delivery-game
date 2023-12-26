using Drone.Generators;
using Drone.Components;
using UnityEngine;

namespace Drone.Controllers
{
    public class FlightController : MonoBehaviour
    {
        public Transform[] targets;
        public Transform droneFactory;

        private void Start()
        {
            var waypoints = new DroneWaypointGenerator(droneFactory.position, targets).Generate();
            var waypointFollower = gameObject.AddComponent<WaypointFollower>();
            waypointFollower.waypoints = waypoints;

            var lineToTargetUpdater = gameObject.AddComponent<LineToTargetUpdater>();
            lineToTargetUpdater.targets = targets;

            gameObject.AddComponent<HeightProximityLine>();
        }
    }
}