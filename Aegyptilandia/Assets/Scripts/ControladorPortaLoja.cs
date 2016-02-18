using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControladorPortaLoja : MonoBehaviour {

	public GameObject Personagem;
	private bool estaNaPorta;
	// Use this for initialization
	void Start () {
		estaNaPorta = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (estaNaPorta && Input.GetKey (KeyCode.F)) {
			PlayerPrefs.SetInt("Coins", Personagem.GetComponent<ControladorPersonagem>().Coins);
			PlayerPrefs.SetFloat("Vida", Personagem.GetComponent<ControladorPersonagem>().vida);
			PlayerPrefs.SetInt("Veneno", Personagem.GetComponent<ControladorPersonagem>().veneno);
			PlayerPrefs.SetInt("Agua", Personagem.GetComponent<ControladorPersonagem>().aguaSanitaria);
			PlayerPrefs.SetFloat("X", Personagem.transform.position.x);
			PlayerPrefs.SetFloat("Y", Personagem.transform.position.y);
			PlayerPrefs.SetFloat("Z", Personagem.transform.position.z);
			SceneManager.LoadScene ("Loja");
		}
	
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Personagem") {
			estaNaPorta = true;
		}
	}
	public void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Personagem") {
			estaNaPorta = false;
		}
	}
}
