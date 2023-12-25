using UnityEngine;

namespace Drone.Models
{
    public struct Waypoint
    {
        public Vector3 Point;
        public Vector3? Target;

        public Waypoint(Vector3 point, Vector3? target = null)
        {
            Point = point;
            Target = target;
        }
    }
}