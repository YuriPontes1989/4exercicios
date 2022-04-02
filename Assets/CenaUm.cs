using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenaUm : MonoBehaviour
{
    // definição das variaveis
    public GameObject Sphere;
    Rigidbody rb;
    public float speed = 5;
    Vector3 direction;

    // indicando os componentes e amarzenando nas variaveis
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Sphere = GameObject.Find("Sphere");
    }

    // defininindo a direção da movimentação  e arredondamento do valor
    private void Update()
    {
        direction = Sphere.transform.position - transform.position;
        direction.Normalize();
    }

    // definindo  a velocidade da movimentação 
    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}
