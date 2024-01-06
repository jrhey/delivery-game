using UnityEngine;

namespace Components {
    public class CircleRendererPrefab : MonoBehaviour
    {
        public float range;
        private CircleAtPointRenderer _circleRenderer;

        void Start()
        {
            var circleOnGround = new GameObject()
            {
                name = "Circle Renderer"
            };
            circleOnGround.transform.SetParent(transform);

            var lineRenderer = circleOnGround.AddComponent<LineRenderer>();
            _circleRenderer = new CircleAtPointRenderer(range, 64, false, lineRenderer);
            _circleRenderer.Render(transform.position);
        }
    }
}