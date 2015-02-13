using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {	

	public void changeToScene(string sceneToChangeTo) {
		Application.LoadLevel(sceneToChangeTo);
	}

}