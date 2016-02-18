using UnityEngine;
using System.Collections;

public class ControladorSpawn : MonoBehaviour
{

    public GameObject prefabMosquito;


    public int secChange;
    private float timechange;
	public int limite;
	private int qtd;
    // Use this for initialization
    void Start()
    {
		qtd = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //Instancia Prefab do Mosquito entre timechange segundos
        timechange += Time.deltaTime;
        if (timechange >= secChange)
        {
			if(limite == 0) Instantiate(prefabMosquito);
			if(limite > 0  && qtd < limite) Instantiate(prefabMosquito);
            timechange = 0;
			qtd++;
        }
    }
}
