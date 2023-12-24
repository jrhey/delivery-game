using UnityEngine;
using Renderers;

namespace Trigonometry
{
    public class DroneHeightProximityLine : MonoBehaviour
    {
        private CircleAtPointRenderer _circleRenderer;
        private LineToPointRenderer _lineToPointRenderer;

        void Start()
        {
            CreateLineToGround();
            CreateProximityCircle();
        }

        private void CreateLineToGround()
        {
            var lineToGround = new GameObject()
            {
                name = "Line to Ground Renderer"
            };
            lineToGround.transform.SetParent(transform);
            var lineRenderer = lineToGround.AddComponent<LineRenderer>();
            _lineToPointRenderer = new LineToPointRenderer(lineRenderer);
        }

        private void CreateProximityCircle()
        {
            var circleOnGround = new GameObject()
            {
                name = "Circle Renderer"
            };
            circleOnGround.transform.SetParent(transform);
            var lineRenderer = circleOnGround.AddComponent<LineRenderer>();
            _circleRenderer = new CircleAtPointRenderer(1f, 8, true, lineRenderer);
        }

        void Update()
        {
            var dronePosition = transform.position;
            var droneGroundPosition = new Vector3(dronePosition.x, 0f, dronePosition.z);
            
            _lineToPointRenderer.Render(dronePosition, droneGroundPosition);
            _circleRenderer.Render(dronePosition);
        }
    }
}