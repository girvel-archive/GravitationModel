using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Common
{
    public class Ui : Singleton<Ui>
    {
        public Slider CalculationSpeedSlider;



        public Ui()
        {
            CalculationSpeedSlider = GameObject.Find("CalculationSpeedSlider").GetComponent<Slider>();
        }
    }
}