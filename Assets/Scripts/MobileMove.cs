using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMove : MonoBehaviour
{

    private int auxDirecao;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(auxDirecao != 0)
        {
            transform.Translate(speed * Time.deltaTime * auxDirecao, 0, 0);
        }

        if(auxDirecao < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if(auxDirecao > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

    }

    public void TochHorizontal(int direcao)
    {
        auxDirecao = direcao;
    }
}
