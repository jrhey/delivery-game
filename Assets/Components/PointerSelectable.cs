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
        
        public void OnEnable()
        {
            _lineRenderer = gameObject.AddComponent<LineRenderer>();
            var boundsSize = GetComponent<Renderer>().bounds.size;
            var distanceFromCenter = Math.Sqrt(Math.Pow(boundsSize.x, 2) + Math.Pow(boundsSize.z, 2)) / 2;
            var circleRadius = (float) distanceFromCenter + 1;
            var circleResolution = (int) (circleRadius * 7) + 1;
            _circleRenderer = new CircleAtPointRenderer(circleRadius, circleResolution, false, _lineRenderer);
            _lineRenderer.enabled = false;
            _circleRenderer.Render(transform.position);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _lineRenderer.enabled = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _lineRenderer.enabled = false;
        }
        
    }
}