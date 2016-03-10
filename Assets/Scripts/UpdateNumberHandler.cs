using UnityEngine;
using System.Collections;
using SimpleJSON;

public class UpdateNumberHandler : MonoBehaviour {
	public int term1;
	public int term2;
	public int sum;
	public int[] randomNum;

	// Use this for initialization
	void Start () {
		UpdateNumbers (10);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateNumbers(int updateNumber) {
		string url = "http://localhost:8081/updateNumbers/" + updateNumber;
		WWW www = new WWW (url);
		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// always assume no errors
		var data = JSON.Parse (www.text);
		term1 = data ["term1"].AsInt;
		term2 = data ["term2"].AsInt;
		sum = data ["sum"].AsInt;

		int arrCount = data ["randoNums"].AsArray.Count;
		randomNum = new int[arrCount];
		for (int i = 0; i < arrCount; i++) {
			randomNum [i] = data ["randoNums"] [i].AsInt;
		}

		print ();
	}

	void print() {
		Debug.Log ("term1 " + term1);
		Debug.Log ("term2 " + term2);
		Debug.Log ("sum " + sum);

		string arr = "randoNums [ ";

		for (int i = 0; i < randomNum.GetLength(0); i++) {
			arr += randomNum [i] + " ";
		}
		arr += "]";

		Debug.Log (arr);
	}
}
