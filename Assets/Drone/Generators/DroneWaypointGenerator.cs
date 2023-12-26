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
                var targetPosition = target.position;
                var toAboveTargetDestination = new Vector3(targetPosition.x, CruisingAltitude, targetPosition.z);
                var toTargetPosition = targetPosition;
                var toCruisingAltitude = new Vector3(targetPosition.x, CruisingAltitude, targetPosition.z);
                
                list.Add(toAboveTargetDestination);
                list.Add(toTargetPosition);
                list.Add(toCruisingAltitude);
            }
            var toAboveOrigin = new Vector3(_origin.x, CruisingAltitude, _origin.z);
            
            list.Add(toAboveOrigin);
            list.Add(_origin);

            return list.ToArray();
        }
    }
}