using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TargetEquation : MonoBehaviour {

    [SerializeField]
    private Text textField;
    /*/
    private int cycleCount;
    private readonly int refreshRate = 120;
    private string[] strings;
    private int index;
    //*/
    private UpdateNumberHandler numHandeler;
    private BarScript bar;
    

	// Use this for initialization
	void Start () {
        GameObject obj = GameObject.Find("/Canvas/Health Bar");
        //numHandeler =  GameObject.Find("/UpdateNumberHandeler").GetComponent<UpdateNumberHandler>();
        bar = obj.GetComponent<BarScript>();
        obj = GameObject.Find("/UpdateNumberHandler");
        numHandeler = obj.GetComponent<UpdateNumberHandler>();
        textField.text = " ";
        /*//
        strings = new string[3];
        strings[0] = "1 + 1 = ?";
        strings[1] = "2 + 2 = ?";
        strings[2] = "3 + 3 = ?";
        cycleCount = 0;
        index = 0;
        //*/
        numHandeler.UpdateNumbers(10);        
	}
	
	// Update is called once per frame
	void Update () {
        if ( !bar.IsGameOver() )
            textField.text = numHandeler.term1 + " + " + numHandeler.term2 + " = ?";
        else
            textField.text = "Game Over";
	    /*//
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
        //*/
	}
}
