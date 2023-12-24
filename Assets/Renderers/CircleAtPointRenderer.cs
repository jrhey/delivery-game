using System;
using System.Linq;
using UnityEngine;

namespace Renderers
{
    public class CircleAtPointRenderer
    {
        private readonly float _radius;
        private readonly int _circleSegments;
        private readonly bool _withProximityToGround;
        private readonly LineRenderer _line;

        public CircleAtPointRenderer(float radius, int circleSegments, bool withProximityToGround, LineRenderer line)
        {
            _radius = radius;
            _circleSegments = circleSegments;
            _withProximityToGround = withProximityToGround;
            _line = line;
            _line.positionCount = _circleSegments + 1;
            _line.useWorldSpace = true;
            _line.startWidth = 0.03f;
            _line.endWidth = 0.03f;
            _line.material = new Material(Shader.Find("Sprites/Default"));
        }
        
        public void Render(Vector3 atPosition)
        {
            DrawCircle(atPosition, _radius);
        }

        private void DrawCircle(Vector3 origin, float radius)
        {
            var dynamicRadius = 1f;
            if (_withProximityToGround)
                dynamicRadius = Mathf.Clamp(radius / origin.y, 0.2f, radius);
            
            var deltaTheta = (2f * Mathf.PI) / _circleSegments;
            var theta = 0f;
            var segmentPositions = new Vector3[(_circleSegments + 1)];
            for (var i = 0; i <= _circleSegments; i++)
            {
                var x = dynamicRadius * radius * Mathf.Cos(theta) + origin.x;
                var z = dynamicRadius * radius * Mathf.Sin(theta) + origin.z;
                segmentPositions[i] = new Vector3(x, 0.1f, z);
                theta += deltaTheta;
            }
            _line.SetPositions(segmentPositions);
        }
    }
}