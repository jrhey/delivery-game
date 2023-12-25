using System.Linq;
using UnityEngine;
using Drone.Services;
using Renderers;

namespace Drone.Services
{
    public class DroneDispatcher : MonoBehaviour
    {
        public float speed = 2f;
        public Transform package;
        public Transform origin;
        public Transform customer;

        private Vector3 _package;
        private Vector3 _origin;
        private Vector3 _customer;
        private Vector3[] _waypoints;
        private int _currentWaypointIndex;

        private void Start()
        {
            _package = package.position;
            _origin = origin.position;
            _customer = customer.position;
            _waypoints = new DroneWaypointGenerator(transform.position, _package).Generate();
            _waypoints = _waypoints.Concat(new DroneWaypointGenerator(_package, _customer).Generate()).ToArray();
            _waypoints = _waypoints.Concat(new DroneWaypointGenerator(_customer, _origin).Generate()).ToArray();
            _currentWaypointIndex = 0;
        }

        private void Update()
        {
            if (_currentWaypointIndex >= _waypoints.Length)
                return;
            
            var currentPosition = transform.position;

            var step = speed * Time.deltaTime;

            if (Vector3.Distance(currentPosition, _waypoints[_currentWaypointIndex]) < 0.001f)
            {
                _currentWaypointIndex += 1;
            }

            if (_currentWaypointIndex >= _waypoints.Length)
                return;

            transform.position = Vector3.MoveTowards(currentPosition, _waypoints[_currentWaypointIndex], step);
        }
    }
}