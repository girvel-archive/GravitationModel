using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.Processors
{
    public class UiManager : BehaviourSingleton<UiManager>
    {
        public Inertion SpeedObject, SpeedObjectParent;



        protected override void Awake()
        {
            base.Awake();

            SpeedObject = GameObject.Find("A").GetComponent<Inertion>();
            SpeedObjectParent = GameObject.Find("Star").GetComponent<Inertion>();
        }

        private void Update()
        {
            PhysicsProcessor.Current.CalculationSpeed =
                (int) (Ui.Current.CalculationSpeedSlider.normalizedValue *
                       PhysicsProcessor.OptimalCalculationSpeed);
        }
    }
}