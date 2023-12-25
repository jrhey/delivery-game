using UnityEngine;

namespace Drone.Controllers
{
    public class DroneAnimationController : MonoBehaviour
    {
        private Animator _animator;
        private readonly float _cruisingAltitude = 15f;

        void Start()
        {
            _animator = gameObject.GetComponent<Animator>();
        }

        void Update()
        {
            _animator.SetBool("CruisingAltitude", transform.parent.transform.position.y >= _cruisingAltitude);
        }
    }
}