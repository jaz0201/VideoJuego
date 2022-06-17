using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaObjeto : MonoBehaviour
{
    public bool destruirConCursor;
    public bool destruirAutomatico;
    public PlayerController playerController;

    public int tipo;
    //1 = Crece
    //2 = 
    //3 =
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Efecto()
    {
        switch (tipo)
        {
            case 1:
            playerController.gameObject.transform.localScale = new Vector3(3, 3, 3);
            break;
            case 2:
            playerController.velocidadInicial += 5;
            break;
            case 3:
            playerController.fuerzaDeSalto += 10;
            break;
            case 4:
                playerController.velocidadInicial -= 10;
                break;
                
            
            default:
                Debug.Log("sin efecto");
                break;
        }
    }
}
