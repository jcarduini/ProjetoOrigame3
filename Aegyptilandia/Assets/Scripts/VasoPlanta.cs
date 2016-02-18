using UnityEngine;
using System.Collections;

public class VasoPlanta : MonoBehaviour {

    public GameObject vazoCheio;
    public GameObject vazoVazio;

    private GameObject Personagem;
    public GameObject Coins;
    public bool aberto;

    // Use this for initialization
    void Start () {

        vazoCheio.SetActive(true);
        vazoVazio.SetActive(false);
        aberto = true;

        Personagem = GameObject.FindGameObjectWithTag("Personagem");

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void interacao()
    {

        if (aberto && Personagem.GetComponent<ControladorPersonagem>().areia)
        {
            vazoCheio.SetActive(false);
            vazoVazio.SetActive(true);
            ControladorSom.playSound(soundFx.FecharLixo);
            aberto = false;
            Instantiate(Coins);
            Personagem.GetComponent<ControladorPersonagem>().Coins += 2;
        }
    }
}
