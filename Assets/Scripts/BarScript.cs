using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
    private float fillAmount;

    [SerializeField]
    private Image content;
	// Use this for initialization
	void Start () {
        fillAmount = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (fillAmount > 0)
        fillAmount = fillAmount - 0.001f;
        HandleBar();
	}

    void HandleBar()
    {
        content.fillAmount = fillAmount;
    }
}
