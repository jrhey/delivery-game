using UnityEngine;
using Renderers;

namespace Renderers
{
    public class CircleRendererPrefab : MonoBehaviour
    {
        public float Range;
        private CircleAtPointRenderer _circleRenderer;

        void Start()
        {
            var circleOnGround = new GameObject()
            {
                name = "Circle Renderer"
            };
            circleOnGround.transform.SetParent(transform);

            var lineRenderer = circleOnGround.AddComponent<LineRenderer>();
            _circleRenderer = new CircleAtPointRenderer(Range, 64, false, lineRenderer);
            _circleRenderer.Render(transform.position);
        }
    }
}