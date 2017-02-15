using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {

    public GameObject bar;
    public float value;
    private System.Action OnEmpty;

    public void Init(System.Action OnEmpty)
    {
       // this.OnEmpty = OnEmpty;
    }
    public void SetValue(float newValue)
    {
        value = newValue;
        bar.transform.localScale = new Vector3(value, 1, 1);
    }
}
