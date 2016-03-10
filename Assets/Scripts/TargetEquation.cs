using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetEquation : MonoBehaviour {

    [SerializeField]
    private Text text;

    private int cycleCount;
    private readonly int refreshRate = 120;
    private string[] strings;
    private int index;
	// Use this for initialization
	void Start () {
        text.text = " ";
        strings = new string[3];
        strings[0] = "1 + 1 = ?";
        strings[1] = "2 + 2 = ?";
        strings[2] = "3 + 3 = ?";
        cycleCount = 0;
        index = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if (cycleCount >= refreshRate)
        {
            cycleCount = 0;
            text.text = strings[index];
            index++;
            if (index > 2)
            {
                index = 0;
            }
        }
        cycleCount++;
	}
}
