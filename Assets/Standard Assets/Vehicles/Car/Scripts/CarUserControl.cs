using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public bool isPlayerOne=true;
        public String horizontal = "Horizontal";
        private String vertical= "Vertical";
        private String jump ="Jump";
        float h = 0;
        float v = 0;
        float velocity;
       

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            if (!isPlayerOne)
            {
                horizontal = "Horizontal_Two";
                vertical= "Vertical_Two";
                jump ="Jump_Two";
            }
            else
            {
                horizontal = "Horizontal";
                vertical= "Vertical";
                jump ="Jump";
            }
        }


        private void FixedUpdate()
        {

            if (isPlayerOne)
            {
                velocity = 1;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    velocity = 5;
                }
                if (Input.GetKey(KeyCode.Space))
                {
                    h = 0;
                    v = 0;
                }
                else
                {
                    Debug.Log("Player 1");
                    h = CrossPlatformInputManager.GetAxis("Horizontal");
                    v = CrossPlatformInputManager.GetAxis("Vertical");
                }
            }
            else if (!isPlayerOne)
            {
                velocity = 1;
                if (Input.GetKey(KeyCode.RightShift))
                {
                    velocity = 5;
                }
                if (!Input.GetKey(KeyCode.B))
                {
                    Debug.Log("Player 2");
                    h = CrossPlatformInputManager.GetAxis("Horizontal_Two");
                    v = CrossPlatformInputManager.GetAxis("Vertical_Two");
                }
                else
                {
                    h = 0;
                    v = 0;
                }
            }
            /*float h = CrossPlatformInputManager.GetAxis(horizontal);
            float v = CrossPlatformInputManager.GetAxis(vertical);*/
#if !MOBILE_INPUT
            float handbrake = Input.GetAxis(jump);
            m_Car.Move(h , v , handbrake, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
