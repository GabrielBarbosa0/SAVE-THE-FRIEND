using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;


    private Rigidbody2D rig;
    private Animator anim;







    private int auxDirecao;
    private int auxPulo;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        MoveMob();

    }


    void MoveMob()
    {
        Vector3 movement = new Vector3(auxDirecao, 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        
        if(auxDirecao > 0f){

            //anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        if(auxDirecao < 0f){

            //anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        
        if(auxDirecao == 0f){
            //anim.SetBool("walk", false);
        }

    }



    public void TochHorizontal(int direcao)
    {
        auxDirecao = direcao;
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal" ) , 0f , 0f);
        transform.position += movement * Time.deltaTime * Speed;
     
        if(Input.GetAxis("Horizontal" ) > 0f){

            transform.eulerAngles = new Vector3(0f,0f,0f);
            anim.SetBool("walk", true);
        }

        if(Input.GetAxis("Horizontal" ) < 0f){

            transform.eulerAngles = new Vector3(0f,180f,0f);
            anim.SetBool("walk", true);
        }
     
        if(Input.GetAxis("Horizontal" ) == 0f){
            anim.SetBool("walk", false);
        }

    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rig.AddForce (new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }

    }

    public void JumpMobile() {
        if (!isJumping)
        {
            rig.AddForce (new Vector2(0f, 11), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            anim.SetBool("jump", false);
            isJumping = false;

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;

        }
    }
}
