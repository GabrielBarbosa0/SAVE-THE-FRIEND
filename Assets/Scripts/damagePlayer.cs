using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class damagePlayer : MonoBehaviour
{

    public int vidaPlayer;
    public int danorecebido;
    public static damagePlayer instance;

    private Animator anim;

    public GameObject heart3;
    public GameObject heart2;
    //public GameObject heart1;






    public float spawnRate;

    private float nextSpawn = 0F;

    // Start is called before the first frame update
    void Start()
    {
        vidaPlayer = 3;
        instance = this;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        diePlayer();

        if(danorecebido >= 1){
            //anim.SetBool("danorec", true);
            if (Time.time > nextSpawn)
            {

                nextSpawn = Time.time + spawnRate;
                //anim.SetBool("danorec", false);
            }
        }


        if (vidaPlayer == 2) {
            Destroy(heart3, 0.3f);
        }

        if (vidaPlayer == 1) {
            Destroy(heart2, 0.3f);
        }

    }

    void diePlayer()
    {
        if(vidaPlayer <= 0)
        {
            anim.SetTrigger("die");
            Destroy(gameObject, 0.6f);
            SceneManager.LoadScene ("LevelCombat" , LoadSceneMode.Single);
        }
    }

    

}
