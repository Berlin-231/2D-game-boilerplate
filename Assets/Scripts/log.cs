using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : Enemy
{
    // Start is called before the first frame update

    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    private Rigidbody2D myrigidbody;
    public Transform homePosition;
    void Start()
    {
        currentstate = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance(){
        if(Vector3.Distance(target.position,transform.position)<=chaseRadius && 
        Vector3.Distance(target.position,transform.position)>attackRadius)
        {
            if(currentstate== EnemyState.idle || currentstate== EnemyState.walk){
            Vector3 temp = Vector3.MoveTowards(transform.position,target.position,moveSpeed * Time.deltaTime);
            myrigidbody.MovePosition(temp);
            changestate(EnemyState.walk);}
        }
    }

    private void changestate(EnemyState newstate){
        if(currentstate!=newstate){
            currentstate=newstate;
        }
    }
}
