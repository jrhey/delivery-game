using System.Linq;
using UnityEngine;
using Trigonometry;
using Renderers;

namespace Actions
{
    public class DroneDispatcher : MonoBehaviour
    {
        public float speed = 2f;
        public Transform package;
        public Transform origin;
        public Transform customer;
        
        public readonly float distanceToTarget;

        private Vector3 _package;
        private Vector3 _origin;
        private Vector3 _customer;
        private Vector3[] _waypoints;
        private int _currentWaypointIndex;
        private LineToPointRenderer _lineToPointRenderer;

        private void Start()
        {
            _package = package.position;
            _origin = origin.position;
            _customer = customer.position;
            _waypoints = new DroneWaypointGenerator(_origin, _package).Generate();
            _waypoints = _waypoints.Concat(new DroneWaypointGenerator(_package, _customer).Generate()).ToArray();
            _waypoints = _waypoints.Concat(new DroneWaypointGenerator(_customer, _origin).Generate()).ToArray();
            _currentWaypointIndex = 0;
            DrawLineToTarget(package);
        }

        private void DrawLineToTarget(Transform target)
        {
            var lineToTarget = new GameObject()
            {
                name = "Line to Destination Renderer"
            };
            
            lineToTarget.transform.SetParent(transform);
            var lineRenderer = lineToTarget.AddComponent<LineRenderer>();
            _lineToPointRenderer = new LineToPointRenderer(lineRenderer);
        }

        private void Update()
        {
            var currentPosition = transform.position;

            // _lineToPointRenderer.Render(currentPosition, _package);

            if (_currentWaypointIndex >= _waypoints.Length)
                return;

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