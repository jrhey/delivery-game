using UnityEngine;

namespace Drone.Trigonometry
{
    public class DroneWaypointGenerator
    {
        private readonly Vector3 _origin;
        private readonly Vector3 _destination;

        private const float CruisingAltitude = 15f;

        public DroneWaypointGenerator(Vector3 origin, Vector3 destination)
        {
            _origin = origin;
            _destination = destination;
        }
        
        public Vector3[] Generate()
        {
            var path = new Vector3[3];

            path[0] += new Vector3(_origin.x, CruisingAltitude, _origin.z);
            path[1] += new Vector3(_destination.x, CruisingAltitude, _destination.z);
            path[2] += new Vector3(_destination.x, _destination.y, _destination.z);
            
            return path;
        }
    }
}