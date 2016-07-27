using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChecker : SingletonBehaviour< SceneChecker > {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//	scene 名を表示する
		var	name	= SceneManager.GetActiveScene().name ;

		if (Input.GetKeyDown (KeyCode.N)) {
			if ("test_code" == name) {
				SceneManager.LoadScene ("test_scene");
			}
			else {
				SceneManager.LoadScene ("test_code");
			}
		}
	}

	void OnGUI(){
		//	scene 名を表示する
		GUI.Label( new Rect( 20, 40, 80, 20 ), SceneManager.GetActiveScene().name );
	}
}
