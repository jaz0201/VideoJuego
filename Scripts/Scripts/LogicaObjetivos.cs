using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Importante
using UnityEngine.UI;
using TMPro;

public class LogicaObjetivos : MonoBehaviour
{
    public int numDeObjetivos;
    public TextMeshProUGUI textoMision;
    public GameObject botonDeMision;
    // Start is called before the first frame update
    void Start()
    {
        numDeObjetivos = GameObject.FindGameObjectsWithTag("objetivo").Length;
          textoMision.text = "Obtén las esferas de oro" +
                                "\n Restantes: " +  numDeObjetivos;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "objetivo")
        {
            Destroy(col.transform.parent.gameObject);
            numDeObjetivos --;
            textoMision.text = "Obtén las esferas de oro" +
                               "\n Restantes: " + numDeObjetivos;
            if (numDeObjetivos <= 0)
            {
                textoMision.text = "Completaste la misión";
                botonDeMision.SetActive(true);
            }
        }
    }
}
