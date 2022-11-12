using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossMecanic : MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator anim;

    public float speed;

    public Transform rightCol;
    public Transform leftCol;

    public Transform headPoint;

    private bool colliding;

    public LayerMask layer;

    private int vidaBoss;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    //public CircleCollider2D circleCollider2DdoPlayer;
    //public BoxCollider2D boxCollider2DdoPlayer;

    public float danoRate;

    public GameObject oPlayer;

    private float nextDano = 0F;

    // Start is called before the first frame update
    void Start()
    {
        vidaBoss = 3;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);
    
        if(colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }


        //if (Time.time > nextDano)
        //{
            
            //anim.SetBoll("ClockHead_damage", false);

        //}




    }
    bool playerDestryed;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            float heigth = col.contacts[0].point.y - headPoint.position.y;

            if(heigth > 0 && !playerDestryed)
            {
                //col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5);
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8, ForceMode2D.Impulse);
                vidaBoss -= 1;
                //anim.SetBoll("ClockHead_damage", true);

            }else
            {
                playerDestryed = true;

                //col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 8, ForceMode2D.Impulse);

                if (Time.time > nextDano)
                {
                nextDano = Time.time + danoRate;
                damagePlayer.instance.vidaPlayer -= 1;
                damagePlayer.instance.danorecebido = 1;
                }
            }

            if(vidaBoss <=0)
            {
                speed = 0f;
                anim.SetTrigger("die");
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 1f);
                SceneManager.LoadScene ("creditos" , LoadSceneMode.Single);
            }


        }
    }

}
