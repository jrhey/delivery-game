using Drone.Models;
using UnityEngine;
using Renderers;
using UnityEngine.Serialization;

namespace Drone.Controllers
{
    public class LineToTargetUpdater : MonoBehaviour
    {
        public TargetList targetList;

        private int _targetIndex;
        private int _numTargets;
        private Vector3 _target;
        private LineToPointRenderer _lineToPointRenderer;

        private void Start()
        {
            _targetIndex = 0;
            _numTargets = targetList.targets.Length;
            _target = targetList.targets[_targetIndex].position;
            CreateLineRenderer();
        }

        private void Update()
        {
            if (_targetIndex == _numTargets - 1)
                return;
            
            var currentPosition = transform.position;

            _lineToPointRenderer.Render(currentPosition, _target);

            if (Vector3.Distance(currentPosition, targetList.targets[_targetIndex].position) > 0.001f)
                return;

            _targetIndex += 1;
            _target = targetList.targets[_targetIndex].position;
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