using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Necesario:
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
//correr
public int velCorrer;
//vida

//

//Caer más rapido
public int fuerzaExtra = 0;

//

    public float velMovimiento = 5.0f;
    public float velRotacion = 200.0f;
    
    //Cambio de collider
    public CapsuleCollider colParado;
    public CapsuleCollider colAgachado;
    public GameObject cabeza;
    public LogicaCabeza logicaCabeza;
    public bool estoyAgachado;
    
    //cambio de private a public
    
    // private Animator anim
    
    public Animator animator;
    public float x;
    public float y;

    public Rigidbody rb;
    public float fuerzaDeSalto = 8f;
    public bool puedoSaltar;

    public float velocidadInicial;
    public float velocidadAgachado;

    public bool estoyAtacando;
    public bool avanzoSolo;
    public float fuerzaDeDeGolpe = 4f;

    public int nivelPersonaje;

    public bool quieto;

    public bool algoEncima;
// Start is called before the first frame update
    void Start()
    {
        estoyAtacando = false;
        
        puedoSaltar = false;
        animator = GetComponent<Animator>();
        
        velocidadInicial = velMovimiento;
        velocidadAgachado = velMovimiento * 0.5f;

    }
    
    void FixedUpdate()
    {
        if (!estoyAtacando)
        {
            transform.Rotate(0, x * Time.deltaTime * velRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velMovimiento);
        }
        
        if (avanzoSolo)
        {
            rb.velocity = transform.forward * fuerzaDeDeGolpe;
        }
    }// Update is called once per frame
    void Update()
    {
        ////////////////
        
        if (Input.GetKey(KeyCode.LeftShift)&& !estoyAgachado && puedoSaltar &&!estoyAtacando)
        {
            velMovimiento = velCorrer;
            if (y > 0)
            {
                animator.SetBool("correr", true);
            }
            else
            {
                animator.SetBool("correr", false);
            }
        }
        else
        {
            animator.SetBool("correr", false);

            if (estoyAgachado)
            {
                //Mover:
                velMovimiento = velocidadAgachado;
            }
            else if (puedoSaltar)
            {
                //Mover:
                velMovimiento = velocidadInicial;
            }
        }
        /////////////////////////////////////////////

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Return) && puedoSaltar && estoyAtacando)
        {
            animator.SetTrigger("golpeo");
            estoyAtacando = true;
            
        }

        if (estoyAtacando)
        {
            animator.SetFloat("VelX", x);
            animator.SetFloat("VelY", y);
        }

        if (puedoSaltar)
        {
            if (!estoyAtacando)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetBool("salte", true);
                    rb.AddForce(new  Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
                }
            
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    animator.SetBool("agachado", true);
                   // velMovimiento = velocidadAgachado;
                    
                    //Cambio de Collider
                    colAgachado.enabled = true;
                    colParado.enabled = false;
                    
                    cabeza.SetActive(true);
                    estoyAgachado = true;
                    
                    //
                }
                else
                {
                    //
                    if (logicaCabeza.contadorDeCollision <= 0)
                    {
                        animator.SetBool("agachado", false);
                        //velMovimiento = velocidadInicial;
                        
                        //Cambio de collider
                        cabeza.SetActive(false);
                        colAgachado.enabled = false;
                        colParado.enabled = true;
                        estoyAgachado = false;
                        //
                    }
                    //
                        
                } 
            }
            
            animator.SetBool("tocoSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }
    }
    public void EstoyCayendo()
    {
    //crear rapido
    rb.AddForce(fuerzaExtra * Physics.gravity);
    //
        animator.SetBool("tocoSuelo", false); 
        animator.SetBool("salte", false);
    }

    public void DejoDeGolpear()
    {
        estoyAtacando = false;
        avanzoSolo = false;
    }

    public void AvanzoSolo()
    {
        avanzoSolo = true;
    }

    public void DejoDeAvanzar()
    {
        avanzoSolo = false;
    }
}
