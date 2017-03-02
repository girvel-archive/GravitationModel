using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.Processors
{
    public class PhysicsProcessor : ObjectProcessor<PhysicsProcessor, Inertion>
    {
        public int CalculationSpeed = 1;
        public const int OptimalCalculationSpeed = 20;



        protected virtual void Start()
        {
            var star = GameObject.Find("Star").GetComponent<Inertion>();
            var planetA = GameObject.Find("A").GetComponent<Inertion>();

            var dA = star.transform.position - planetA.transform.position;

            planetA.Velocity +=
                Vector3.Cross(dA, planetA.transform.position - Camera.main.transform.position).normalized *
                1.1f * (float) Gravitation.GetOrbitalSpeed(star.Mass, dA.magnitude);

            var planetB = GameObject.Find("B").GetComponent<Inertion>();

            var dB = star.transform.position - planetB.transform.position;

            planetB.Velocity +=
                Vector3.Cross(dB, Vector3.up).normalized *
                1.2f * (float)Gravitation.GetOrbitalSpeed(star.Mass, dB.magnitude);

        }

        private void Update()
        {
            for (var i = 0; i < CalculationSpeed; i++)
            {
                Step();
            }
        }

        private void Step()
        {
            foreach (var obj in Objects)
            {
                foreach (var obj1 in Objects.Where(o => o != obj))
                {
                    var distance = obj1.transform.position - obj.transform.position;
                    obj.Velocity += (float) (Gravitation.G * obj1.Mass / distance.sqrMagnitude) * distance.normalized * Time.deltaTime;
                }
            }

            foreach (var obj in Objects)
            {
                obj.Step();
            }
        }
    }
}
