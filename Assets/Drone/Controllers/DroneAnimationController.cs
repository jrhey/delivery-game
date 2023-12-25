using UnityEngine;

namespace Drone.Controllers
{
    public class DroneAnimationController : MonoBehaviour
    {
        private Animation _animation;
        private readonly float _cruisingAltitude = 15f;

        void Start()
        {
            _animation = gameObject.GetComponent<Animation>();
        }

        void Update()
        {
            if (transform.position.y >= _cruisingAltitude)
            {
                if (!_animation.isPlaying)
                    _animation.Play();
            }
            else
            {
                if (_animation.isPlaying)
                    _animation.Stop();
            }
        }
    }
}