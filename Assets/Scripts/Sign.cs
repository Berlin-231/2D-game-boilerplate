using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange){
            Debug.Log("Space");
                if(dialogBox.activeInHierarchy){
                    dialogBox.SetActive(false);
                    
                    Debug.Log("trying to deact");
                }else{
                    Debug.Log("trying to active");
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                }
        }
    }


    void OnTriggerEnter2D(Collider2D other){

            if(other.CompareTag("Player")){
                playerInRange = true;
                Debug.Log("Player in Range");
            }
    }

void OnTriggerExit2D(Collider2D other){

            if(other.CompareTag("Player")){
                playerInRange=false;
                
                    dialogBox.SetActive(false);
                Debug.Log("Player out of Range");
            }
    }



}
