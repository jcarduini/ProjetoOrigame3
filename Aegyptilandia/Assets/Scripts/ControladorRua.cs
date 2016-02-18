using UnityEngine;
using System.Collections;

public class ControladorRua : MonoBehaviour {

    private GameObject Personagem;

    // Use this for initialization
    void Start () {
        Personagem = GameObject.FindGameObjectWithTag("Personagem");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void interacao()
    {
        Personagem.GetComponent<ControladorPersonagem>().areia = true;
    }
}
