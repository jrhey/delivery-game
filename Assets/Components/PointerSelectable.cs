using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Renderers;

namespace Components
{
    public class PointerSelectable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private LineRenderer _lineRenderer;
        private CircleAtPointRenderer _circleRenderer;
        
        public void Start()
        {
            var childObject = new GameObject("Hover Circle Highlight")
            {
                transform =
                {
                    parent = transform
                }
            };
            _lineRenderer = childObject.AddComponent<LineRenderer>();
            var boundsSize = GetComponent<BoxCollider>().bounds.size;
            var distanceFromCenter = Math.Sqrt(Math.Pow(boundsSize.x, 2) + Math.Pow(boundsSize.z, 2)) / 2;
            var circleRadius = (float) distanceFromCenter + 1;
            var circleResolution = (int) (circleRadius * 7) + 1;
            _circleRenderer = new CircleAtPointRenderer(circleRadius, circleResolution, false, _lineRenderer);
            _lineRenderer.enabled = false;
            _circleRenderer.Render(transform.position);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            print("Hovered");
            _lineRenderer.enabled = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            print("Left");
            _lineRenderer.enabled = false;
        }
    }
}