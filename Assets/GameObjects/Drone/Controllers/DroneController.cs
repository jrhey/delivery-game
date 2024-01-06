using Components;
using Drone.Generators;
using UnityEngine;

namespace GameObjects.Drone.Controllers
{
    public class DroneController : MonoBehaviour
    {
        public Transform origin;
        public Transform[] targets;

        private void Start()
        {
            var waypoints = new DroneWaypointGenerator(origin.position, targets).Generate();
            var waypointFollower = gameObject.AddComponent<WaypointFollower>();
            waypointFollower.waypoints = waypoints;

            var lineToTargetUpdater = gameObject.AddComponent<LineToTargetUpdater>();
            lineToTargetUpdater.targets = targets;

            gameObject.AddComponent<HeightProximityLine>();
        }
    }
}