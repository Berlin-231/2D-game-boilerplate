using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{

    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        Application.targetFrameRate = 60;
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX",0);
        animator.SetFloat("moveY",-1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(speed);
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack){
                StartCoroutine(AttackCo());
        }
       else if(currentState == PlayerState.walk){
       updateAnimationAndMove();
        }
    } 

    private IEnumerator AttackCo(){
            animator.SetBool("attacking",true);
            currentState= PlayerState.attack;
            yield return null;
            animator.SetBool("attacking",false);
            yield return new WaitForSeconds(.3f);
            
            currentState= PlayerState.walk;
    }


    void updateAnimationAndMove(){
        if(change != Vector3.zero ){
                        MoveCharacter();
                        animator.SetFloat("moveX",change.x);
                        animator.SetFloat("moveY",change.y);
                        animator.SetBool("moving",true);
        
                }else{
                    
                        animator.SetBool("moving",false);
                }
    }


    void MoveCharacter(){

        myRigidBody.MovePosition(
            transform.position + change.normalized * speed * Time.deltaTime
        );



    }
}
