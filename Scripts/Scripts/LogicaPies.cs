using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "piso" || other.tag=="objeto")
        {
            playerController.puedoSaltar = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("sali");
        playerController.puedoSaltar = false;   
    }
    
}

