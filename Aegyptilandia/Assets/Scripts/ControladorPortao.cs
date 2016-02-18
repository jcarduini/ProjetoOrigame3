using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControladorPortao : MonoBehaviour {

    public GameObject Personagem;
    public GameObject PortaoAberto;
    public GameObject PortaoFechado;

    public bool aberto;

    public string cena;

    // Use this for initialization
    void Start () {
        PortaoAberto.SetActive(false);
        PortaoFechado.SetActive(true);
        aberto = false;

        Personagem = GameObject.FindGameObjectWithTag("Personagem");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void interacao()
    {
        if (!aberto)
        {
            PortaoFechado.SetActive(false);
            PortaoAberto.SetActive(true);
            //ControladorSom.playSound(soundFx.FecharLixo);
            aberto = true;

            PlayerPrefs.SetInt("Coins", Personagem.GetComponent<ControladorPersonagem>().Coins);
            PlayerPrefs.SetFloat("Vida", Personagem.GetComponent<ControladorPersonagem>().vida);
            PlayerPrefs.SetInt("Veneno", Personagem.GetComponent<ControladorPersonagem>().veneno);
            PlayerPrefs.SetInt("Agua", Personagem.GetComponent<ControladorPersonagem>().aguaSanitaria);

            FadeControl.fadeOn(1);
            Invoke("carregacena", 1);
        }
    }

    void carregacena()
    {
        SceneManager.LoadScene(cena);
        //Application.LoadLevel(cena);
    }
}
