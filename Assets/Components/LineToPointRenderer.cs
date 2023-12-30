using UnityEngine;

namespace Renderers
{
    public class LineToPointRenderer
    {
        private const float LineWidth = 0.03f; 
        private readonly LineRenderer _line;

        public LineToPointRenderer(LineRenderer line)
        {
            _line = line;
            _line.positionCount = 2;
            _line.startWidth = LineWidth;
            _line.endWidth = LineWidth;
            _line.material = new Material(Shader.Find("Sprites/Default"));
            _line.enabled = false;
        }
        
        public void Render(Vector3 from, Vector3 to)
        {
            _line.SetPosition(0, from);
            _line.SetPosition(1, to);
            _line.enabled = true;
        }

        public void Clear()
        {
            _line.enabled = false;
        }
    }
}