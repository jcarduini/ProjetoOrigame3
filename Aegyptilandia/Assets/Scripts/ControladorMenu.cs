using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void comeca()
	{
		PlayerPrefs.SetInt("start", 1);
		SceneManager.LoadScene ("Rua");
		
	}
}
