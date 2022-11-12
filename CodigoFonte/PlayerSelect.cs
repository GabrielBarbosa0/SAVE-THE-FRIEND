using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{

    GameObject player;
    int i;

    public GameObject[] players;
    public Button next, previous, select;


    // Start is called before the first frame update
    void Start()
    {
        i = 0;

        next.onClick = new Button.ButtonClickedEvent ();
        previous.onClick = new Button.ButtonClickedEvent ();
        select.onClick = new Button.ButtonClickedEvent ();
    
        next.onClick.AddListener (() => Next ());
        previous.onClick.AddListener (() => Previous ());
        select.onClick.AddListener (() => Select ());
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) {
            player = GameObject.Find ("player");
            player = Instantiate (players [i], player.transform.position, player.transform.rotation);
        }
    }

    void Next(){
        i++;
        if (i >= players.Length) {
            i = 0;
        }
        Destroy (player);
    }

    void Previous(){
        i--;
        if (i < 0) {
            i = players.Length -1;
        }
        Destroy (player);
    }

    void Select(){

        if (i == 1) {
            SceneManager.LoadScene ("Level_male", LoadSceneMode.Single);
        }else
        {
        SceneManager.LoadScene ("Level_female", LoadSceneMode.Single);
        }
        // DontDestroyOnLoad (player);
        // player.transform.position = new Vector3 (0, 2, 0);
        // player.AddComponent<Rigidbody> ();
        // player.name = "Player";
    }
}
