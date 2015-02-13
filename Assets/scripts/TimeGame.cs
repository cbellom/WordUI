using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeGame : MonoBehaviour {
	public float secondsDurationGame;
	public GameObject button;
	public Text textTime;

	// Use this for initialization
	void Start () {
		textTime.text = secondsDurationGame.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (secondsDurationGame > 0) {
			textTime.text =  (Mathf.Round(secondsDurationGame * 100f) / 100f).ToString();
			secondsDurationGame -= Time.deltaTime;

			if (secondsDurationGame <=0) {
				if (button != null){
					textTime.text = "0";
					button.SetActive (true);
				}
			}
		}
	}


}
