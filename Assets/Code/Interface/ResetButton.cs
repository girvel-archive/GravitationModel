using UnityEngine;

namespace Assets.Code.Interface
{
    public class ResetButton : MonoBehaviour
    {
        public void OnClick()
        {
            Camera.main.transform.SetParent(null);
            Camera.main.transform.position = new Vector3(0, 0, -10);
        }
    }
}