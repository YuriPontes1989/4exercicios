using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    // definição das variaveis
    public GameObject Capsule;
    Rigidbody rb;
    public float speed = 5;
    Vector3 direction;

    private void Start()
    {
        // indicando os componentes e amarzenando nas variaveis
        rb = GetComponent<Rigidbody>();
        Capsule = GameObject.Find("Capsule");
    }

    private void Update()
    {
        // defininindo a direção da movimentação  e arredondamento do valor
        direction = Capsule.transform.position - transform.position;
        direction.Normalize();
    }

    private void FixedUpdate()
    {
        // definindo  a velocidade da movimentação
        rb.velocity = direction * speed;
    }
}

