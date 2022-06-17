using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//IMPORTANTE:
using UnityEngine.UI;

public class LogicaBarraDeVida : MonoBehaviour
{
    public int vidaMax;
    public float vidaActual;
    public Image imagenBarraVida;
    
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
        
        if (vidaActual <= 0)
        {
            
        gameObject.SetActive(false);
        //Función que necesites
        
    }
}

public void RevisarVida()
{
    imagenBarraVida.fillAmount = vidaActual / vidaMax;
}
}
