using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    private Transform posicaoDoJogador;

    public float velocidadeDoInimigo;


    // Start is called before the first frame update
    void Start()
    {
        
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        SeguirJogador();
    }

    private void SeguirJogador()
    {
        if(posicaoDoJogador.gameObject != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoJogador.position, velocidadeDoInimigo * Time.deltaTime);
        };
    }

}
