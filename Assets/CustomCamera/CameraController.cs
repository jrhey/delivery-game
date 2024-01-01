using UnityEngine;

namespace CustomCamera
{
    public class CameraController : MonoBehaviour
    {
        public Camera mainCamera;

        public float normalSpeed;
        public float fastSpeed;
        public float movementSpeed;
        public float movementTime;
        public float rotationAmount;
        public Vector3 zoomAmount;

        private Vector3 _newPosition;
        private Quaternion _newRotation;
        private Vector3 _newZoom;
        private Vector3 _dragStartPosition;
        private Vector3 _dragCurrentPosition;

        // Start is called before the first frame update
        void Start()
        {
            _newPosition = transform.position;
            _newRotation = transform.rotation;
            _newZoom = mainCamera.transform.localPosition;
        }

        void Update()
        {
            HandleMouseInput();
            HandleMovementInput();
        }

        void HandleMouseInput()
        {
            if (Input.mouseScrollDelta.y != 0)
            {
                _newZoom += Input.mouseScrollDelta.y * zoomAmount;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                Plane plane = new Plane(Vector3.up, Vector3.zero);
                print(mainCamera.transform);
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                float entry;

                if (plane.Raycast(ray, out entry))
                {
                    _dragStartPosition = ray.GetPoint(entry);
                }
            }

            if (Input.GetMouseButton(0))
            {
                Plane plane = new Plane(Vector3.up, Vector3.zero);
                print(mainCamera.transform);
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                float entry;

                if (plane.Raycast(ray, out entry))
                {
                    _dragCurrentPosition = ray.GetPoint(entry);

                    _newPosition = transform.position + _dragStartPosition - _dragCurrentPosition;
                } 
            }
        }

        void HandleMovementInput()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementSpeed = fastSpeed;
            }
            else
            {
                movementSpeed = normalSpeed;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                _newPosition += (transform.forward * movementSpeed);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                _newPosition += (transform.forward * -movementSpeed);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                _newPosition += (transform.right * movementSpeed);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                _newPosition += (transform.right * -movementSpeed);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                _newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
            }

            if (Input.GetKey(KeyCode.E))
            {
                _newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
            }

            if (Input.GetKey(KeyCode.R))
            {
                _newZoom += zoomAmount;
            }

            if (Input.GetKey(KeyCode.F))
            {
                _newZoom -= zoomAmount;
            }

            transform.position = Vector3.Lerp(transform.position, _newPosition, Time.deltaTime * movementTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, Time.deltaTime * movementTime);
            mainCamera.transform.localPosition =
                Vector3.Lerp(mainCamera.transform.localPosition, _newZoom, Time.deltaTime * movementTime);
        }
    }
}