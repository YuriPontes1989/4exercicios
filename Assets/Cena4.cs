using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cena4 : MonoBehaviour
{
    // declarando as variaveis 
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;
    public GameObject g4;
    public GameObject g5;
    public string actGoal;
    public Material check;
    public int lap;

    Rigidbody rb;

    public float speed = 5;
    Vector3 direction;

    private void Start()
    {
        //Iniciando as variáveis
        check = Resources.Load("check",typeof(Material)) as Material;
        rb = GetComponent<Rigidbody>();
        g1 = GameObject.Find("g1");
        g2 = GameObject.Find("g2");
        g3 = GameObject.Find("g3");
        g4 = GameObject.Find("g4");
        g5 = GameObject.Find("g5");
        actGoal = "g1";
        lap = 1;
    }

    private void Update()
    {
        //Mudando a direção baseado no objetivo atual
        switch(actGoal) {
            case "g1":
                direction = g1.transform.position - transform.position;
                direction.Normalize();
            break;
            case "g2":
                direction = g2.transform.position - transform.position;
                direction.Normalize();
            break;
            case "g3":
                direction = g3.transform.position - transform.position;
                direction.Normalize();
            break;
            case "g4":
                direction = g4.transform.position - transform.position;
                direction.Normalize();
            break;
            case "g5":
                direction = g5.transform.position - transform.position;
                direction.Normalize();
            break;
        }
        
    }

    //Lógica da colisão, quando colidimos com um objeto, seu material muda pra indicar a colisão e o objetivo atual é atualizado para o próximo
    void OnCollisionEnter(Collision collision) {
        string name = collision.gameObject.name;
        switch(name) {
            case "g1":
                g1.GetComponent<Renderer>().material = check;
                actGoal = "g2";
            break;
            case "g2":
                g2.GetComponent<Renderer>().material = check;
                actGoal = "g3";
            break;
            case "g3":
                g3.GetComponent<Renderer>().material = check;
                actGoal = "g4";
            break;
            case "g4":
               if(lap == 1) {
                g4.GetComponent<Renderer>().material = check;
                actGoal = "g5";
               } else if(lap == 2) {
                   speed = 0;
               }
            break;
            case "g5":
                g5.GetComponent<Renderer>().material = check;
                actGoal = "g4";
                lap = 2;
                
                
            break;
        }
    }

    
    private void FixedUpdate()
    {
        //Definição da velocidade do objeto, baseado na sua direção
        rb.velocity = direction * speed;
    }
}
