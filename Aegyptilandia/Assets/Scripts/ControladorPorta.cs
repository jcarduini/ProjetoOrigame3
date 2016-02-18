using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControladorPorta : MonoBehaviour {

    public GameObject Personagem;

    public string cena;

    // Use this for initialization
    void Start () {
        Personagem = GameObject.FindGameObjectWithTag("Personagem");

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void interacao()
    {
        PlayerPrefs.SetInt("Coins",Personagem.GetComponent<ControladorPersonagem>().Coins);
		PlayerPrefs.SetFloat("Vida", Personagem.GetComponent<ControladorPersonagem>().vida);
		PlayerPrefs.SetInt("Veneno", Personagem.GetComponent<ControladorPersonagem>().veneno);
		PlayerPrefs.SetInt("Agua", Personagem.GetComponent<ControladorPersonagem>().aguaSanitaria);

        FadeControl.fadeOn(1);  
        Invoke("carregacena", 1);
    }

    void carregacena()
    {
        SceneManager.LoadScene (cena);
        //Application.LoadLevel(cena);
    }
}
