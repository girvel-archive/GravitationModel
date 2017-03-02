using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.Interface
{
    public class PlanetAButton : MonoBehaviour
    {
        public void OnClick()
        {
            Camera.main.transform.SetParent(GameObject.Find("A").transform);
            Camera.main.transform.localPosition = new Vector3(0, 0, -10);
        }
    }
}