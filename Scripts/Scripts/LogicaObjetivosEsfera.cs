using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaObjetivosEsfera : MonoBehaviour
{
    public LogicaNarniano logicaNarniano;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            logicaNarniano.numDeObjetivos--;
            logicaNarniano.textoMision.text = "Obtén las monedas de oro" +
                                              "\n Restantes: " + logicaNarniano.numDeObjetivos;
            if (logicaNarniano.numDeObjetivos <= 0)
            {
                logicaNarniano.textoMision.text = "Completaste la misión";
                logicaNarniano.botonDeMison.SetActive(true);
            }

            transform.parent.gameObject.SetActive(false);
        }
    }
}
