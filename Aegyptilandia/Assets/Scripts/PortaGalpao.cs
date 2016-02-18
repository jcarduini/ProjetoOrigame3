using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortaGalpao : MonoBehaviour {

	//public Scene cena;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void interacao()
	{
		FadeControl.fadeOn(1);
		Invoke("carregacena", 1);

		//Application.LoadLevel(cena);
	}
	void carregacena()
	{
		SceneManager.LoadScene("UsinaParte1");
		//Application.LoadLevel(cena);
	}
}
