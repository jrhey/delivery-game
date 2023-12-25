using UnityEngine;

namespace Drone.Components
{
    public class WaypointFollower: MonoBehaviour
    {
        public Vector3[] waypoints;
        public float speed = 10f;
        
        private int _currentWaypointIndex;

        private void Update()
        {
            if (waypoints.Length == 0)
                return;
            
            if (_currentWaypointIndex >= waypoints.Length)
                return;
            
            var currentPosition = transform.position;

            var step = speed * Time.deltaTime;

            if (Vector3.Distance(currentPosition, waypoints[_currentWaypointIndex]) < 0.001f)
            {
                _currentWaypointIndex += 1;
            }

            if (_currentWaypointIndex >= waypoints.Length)
                return;

            transform.position = Vector3.MoveTowards(currentPosition, waypoints[_currentWaypointIndex], step);
        }
    }
}