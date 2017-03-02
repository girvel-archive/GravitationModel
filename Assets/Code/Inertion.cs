using Assets.Code.Processors;
using UnityEngine;

namespace Assets.Code
{
    public class Inertion : MonoBehaviour
    {
        public double Mass;

        public Vector3 Velocity = Vector3.zero;

        public Vector3 RotationVelocity;

        public bool Gravitation = false;


        private void Start()
        {
            if (Gravitation)
            {
                ActionProcessor.Current.AddActionToQueue(
                    () => PhysicsProcessor.Current.Objects.Add(this));
            }
        }

        private void FixedUpdate()
        {
            Instantiate(Resources.Load("New Prefab"), transform.position, new Quaternion());
        }
        


        public void Step()
        {
            transform.position += Velocity * Time.deltaTime;

            transform.Rotate(RotationVelocity);
        }
        
        public void AddImpulse(Vector3 impulse)
        {
            Velocity += impulse / (float) Mass;
        }
    }
}