using UnityEngine;
using Renderers;

namespace Drone.Controllers
{
    public class LineToTargetUpdater : MonoBehaviour
    {
        public Vector3[] targets;

        private int _targetIndex;
        private int _numTargets;
        private Vector3 _target;
        private LineToPointRenderer _lineToPointRenderer;

        private void Start()
        {
            _targetIndex = 0;
            _numTargets = targets.Length;
            _target = targets[_targetIndex];
            CreateLineRenderer();
        }

        private void Update()
        {
            var currentPosition = transform.position;

            _lineToPointRenderer.Render(currentPosition, _target);

            if (_targetIndex == _numTargets -1)
                return;

            if (Vector3.Distance(currentPosition, targets[_targetIndex]) < 0.001f)
            {
                _targetIndex += 1;
                _target = targets[_targetIndex];
            }
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