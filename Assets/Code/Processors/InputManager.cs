using UnityEngine;

namespace Assets.Code.Processors
{
    public class InputManager : MonoBehaviour
    {
        public float 
            CameraRotationFactor = 0.33f,
            CameraKeyboardMovingFactor = 5f,
            CameraMouseMovingFactor = 1f;

        protected Vector3 PreviousMousePosition;



        private void Update()
        {
            RotateCamera();
        }



        private void RotateCamera()
        {
            var path = PreviousMousePosition - Input.mousePosition;

            if (Input.GetMouseButton(1))
            {
                //Camera.main.transform.Rotate(new Vector3(path.y, -path.x) * CameraRotationFactor);
            }

            if (Input.GetMouseButton(2))
            {
                Camera.main.transform.position +=
                    Camera.main.transform.rotation *
                    path *
                    CameraMouseMovingFactor * 
                    Time.deltaTime;
            }

            Camera.main.transform.position +=
                Camera.main.transform.rotation *
                new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) *
                CameraKeyboardMovingFactor * 
                Time.deltaTime;
            
            PreviousMousePosition = Input.mousePosition;

            // TODO const "Horizontal", "V.."
        }

        private void MoveCamera()
        {
        }
    }
}
