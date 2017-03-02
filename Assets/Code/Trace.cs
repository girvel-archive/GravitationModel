using UnityEngine;

namespace Assets.Code
{
    public class Trace : MonoBehaviour
    {
        private const float TimeBeforeDeathSecondsMax = 30;
        private float _timeBeforeDeathSeconds = TimeBeforeDeathSecondsMax;



        private void Update()
        {
            _timeBeforeDeathSeconds -= Time.deltaTime;

            if (_timeBeforeDeathSeconds <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}