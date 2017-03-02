using System;
using Assets.Code.Processors;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Interface
{
    public class VelocitySlider : MonoBehaviour
    {
        private Slider _thisSlider;

        private void Start()
        {
            _thisSlider = GetComponent<Slider>();
        }

        private void Update()
        {
            var speedObject = UiManager.Current.SpeedObject;
            var speedObjectParent = UiManager.Current.SpeedObjectParent;
            var orbitalSpeed = (float) Gravitation.GetOrbitalSpeed(
                speedObjectParent.Mass,
                (speedObject.transform.position - speedObjectParent.transform.position).magnitude);

            _thisSlider.normalizedValue =
                Math.Max(
                    Math.Min(
                        1,
                        (speedObject.Velocity.magnitude / orbitalSpeed - 1) / (Mathf.Sqrt(2) - 1)),
                    0);
        }

        public void OnValueChanged()
        {
            var speedObject = UiManager.Current.SpeedObject;
            var speedObjectParent = UiManager.Current.SpeedObjectParent;

            speedObject.Velocity =
                (1 + _thisSlider.normalizedValue * (Mathf.Sqrt(2) - 1)) *
                speedObject.Velocity.normalized *
                (float)
                    Gravitation.GetOrbitalSpeed(
                        speedObjectParent.Mass,
                        (speedObject.transform.position - speedObjectParent.transform.position).magnitude);
        }
    }
}