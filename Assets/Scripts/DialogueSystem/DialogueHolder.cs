﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
   
        private void Awake()
        {
            StartCoroutine(dialogueSequence());
        }

        private IEnumerator dialogueSequence()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
          
           
            }
            gameObject.SetActive(false);

            if(transform.childCount == 8  ){

             
  
                SceneManager.LoadScene("LevelCombat", LoadSceneMode.Single);

            }else if(transform.childCount == 6  ){ 
 SceneManager.LoadScene("dialogueperson", LoadSceneMode.Single);


                }else{ 
                     SceneManager.LoadScene("playerSelect", LoadSceneMode.Single);
                 }
               
                }
                
       


         
    

        private void Deactivate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
   }
}




