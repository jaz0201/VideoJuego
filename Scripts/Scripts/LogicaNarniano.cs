using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class LogicaNarniano : MonoBehaviour
{
    public GameObject simboloMision;
    public PlayerController jugador;
    public GameObject panelNARNIANO;
    public GameObject panelNARNIANO2;
    public GameObject panelNARNIANOMision;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject[] objetivos;
    public int numDeObjetivos;
    public GameObject botonDeMison;

    // Start is called before the first frame update
    void Start()
    {
        numDeObjetivos = objetivos.Length;
        textoMision.text = "Obtén las monedas de oro" +
                           "\n Restantes: " + numDeObjetivos;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        simboloMision.SetActive(true);
        panelNARNIANO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && aceptarMision == false && jugador.puedoSaltar == true)
        {
            Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y,
                transform.position.x);
            jugador.gameObject.transform.LookAt(posicionJugador);

            //..........................

            //cambio de private a public:

            // private animator anim;

            jugador.animator.SetFloat("Velx", 0);
            jugador.animator.SetFloat("Vely", 0);
            jugador.enabled = false;
            panelNARNIANO.SetActive(false);
            panelNARNIANO2.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = true;
            if (aceptarMision == false)
            {
                panelNARNIANO.SetActive(true);
            }

        }
    }

//---------------------------------

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = false;
            panelNARNIANO.SetActive(false);
            panelNARNIANO2.SetActive(false);
        }
    }

    public void No()
    {
        jugador.enabled = true;

        panelNARNIANO2.SetActive(false);

        panelNARNIANO.SetActive(true);
    }

    public void Si()
    {
        jugador.enabled = true;
        aceptarMision = true;
        for (int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].SetActive(true);
        }

        jugadorCerca = false;
        simboloMision.SetActive(false);
        panelNARNIANO.SetActive(false);
        panelNARNIANO2.SetActive(false);
        panelNARNIANOMision.SetActive(true);
    }

}