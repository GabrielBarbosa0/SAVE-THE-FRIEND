using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die_miniclockperseg : MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator anim;

    public float speed;

    public Transform headPoint;

    private bool colliding;

    public LayerMask layer;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;


    public float danoRate;

    private float nextDano = 0F;

    // Start is called before the first frame update
    void Start()
    {
        //vidaBoss = 3;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 18, ForceMode2D.Impulse);
                speed = 0f;
                anim.SetTrigger("die");
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 1f);
            }else
            {
                playerDestryed = true;

                //col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 8, ForceMode2D.Impulse);

                if (Time.time > nextDano)
                {
                nextDano = Time.time + danoRate;
                damagePlayer.instance.vidaPlayer -= 1;
                damagePlayer.instance.danorecebido += 1;
                }
            }


        }
        
    }
}
