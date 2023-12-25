using System.Collections.Generic;
using UnityEngine;

namespace Drone.Generators
{
    public class DroneWaypointGenerator
    {
        private const float CruisingAltitude = 15f;
        private readonly Vector3 _origin;
        private Transform[] _targets;

        public DroneWaypointGenerator(Vector3 origin, Transform[] targets)
        {
            _origin = origin;
            _targets = targets;
        }
        
        public Vector3[] Generate()
        {
            var list = new List<Vector3>();
            
            var initialCruisingAltitude = new Vector3(_origin.x, CruisingAltitude, _origin.z);
            list.Add(initialCruisingAltitude);
            
            foreach(var target in _targets)
            {
                var toAboveTargetDestination = new Vector3(target.position.x, CruisingAltitude, target.position.z);
                var toTargetPosition = target.position;
                var toCruisingAltitude = new Vector3(target.position.x, CruisingAltitude, target.position.z);
                
                list.Add(toAboveTargetDestination);
                list.Add(toTargetPosition);
                list.Add(toCruisingAltitude);
            }

            return list.ToArray();
        }
    }
}