using UnityEngine;
using System.Collections;

public class LataLixo : MonoBehaviour {

    public GameObject lataAberta;
    public GameObject lataFechada;

    public GameObject Personagem;
    public GameObject Coins;
    public bool aberto;

    // Use this for initialization
    void Start () {

        lataAberta.SetActive(true);
        lataFechada.SetActive(false);
        aberto = true;
	
        Personagem = GameObject.FindGameObjectWithTag("Personagem");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void interacao()
    {
        if (aberto)
        {
            lataAberta.SetActive(false);
            lataFechada.SetActive(true);
            ControladorSom.playSound(soundFx.FecharLixo);
            aberto = false;
            Instantiate(Coins);
            Personagem.GetComponent<ControladorPersonagem>().Coins += 2;
        }
    }
}
