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
	private UpdateNumberHandler numHandler;
    private BarScript bar;
    
	// Use this for initialization
	void Start () {
        GameObject obj = GameObject.Find("/CardboardMain/Head/Main Camera/Canvas/Health Bar");
        bar = obj.GetComponent<BarScript>();
        obj = GameObject.Find("/UpdateNumberHandler");
        numHandler = obj.GetComponent<UpdateNumberHandler>();
        textField = GameObject.Find("/CardboardMain/Head/Main Camera/Canvas/Text").GetComponent<Text>();
        textField.text = " ";
        /*//
        strings = new string[3];
        strings[0] = "1 + 1 = ?";
        strings[1] = "2 + 2 = ?";
        strings[2] = "3 + 3 = ?";
        cycleCount = 0;
        index = 0;
        //*/

        // update the number equation
        numHandler.UpdateNumbers(UpdateNumberHandler.NUM_RAND_ZOMBIES);
        Debug.Log("Update Numbers from health!");
    }
	
	// Update is called once per frame
	void Update () {
        if ( !bar.IsGameOver() )
        {
            textField.text = numHandler.term1 + " + " + numHandler.term2 + " = ?";
        }
        else
        {
            textField.text = "Game Over";

            // destroy all zombies
            // remove all zombies
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < zombies.Length; i++)
            {
                Destroy(zombies[i]);
            }
        }
            
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
