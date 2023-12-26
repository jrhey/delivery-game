using UnityEngine;
using Renderers;

namespace Logistics.Components
{
    public class LineToTargetUpdater : MonoBehaviour
    {
        public Transform[] targets;

        private int _targetIndex;
        private int _numTargets;
        private Vector3 _target;
        private LineToPointRenderer _lineToPointRenderer;

        private void Start()
        {
            _targetIndex = 0;
            _numTargets = targets.Length;
            if (_numTargets > 0)
            {
                _target = targets[_targetIndex].position;
                CreateLineRenderer();
            }
        }

        private void Update()
        {
            if (_targetIndex == _numTargets)
                return;

            var currentPosition = transform.position;

            _lineToPointRenderer.Render(currentPosition, _target);

            if (Vector3.Distance(currentPosition, targets[_targetIndex].position) > 0.001f)
                return;

            _targetIndex += 1;
            if (_targetIndex == _numTargets)
                return;
            _target = targets[_targetIndex].position;
        }

        private void CreateLineRenderer()
        {
            var lineToTarget = new GameObject()
            {
                name = "Line to Destination Renderer"
            };

            lineToTarget.transform.SetParent(transform);
            var lineRenderer = lineToTarget.AddComponent<LineRenderer>();
            _lineToPointRenderer = new LineToPointRenderer(lineRenderer);
        }
    }
}