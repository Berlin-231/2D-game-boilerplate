using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{
    // Start is called before the first frame update
    public float thrust;
    public float knocktime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
            if(other.gameObject.CompareTag("enemy")){

                    Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
                    if(enemy!=null){

                        
                        enemy.GetComponent<Enemy>().currentstate = EnemyState.stagger;
                        Vector2 difference = enemy.transform.position - transform.position;
                        difference= difference.normalized * thrust;
                        enemy.AddForce(difference,ForceMode2D.Impulse);
                        StartCoroutine(KnockCo(enemy));
                    }


            }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy){
        if(enemy!=null){

            yield return new WaitForSeconds(knocktime);
            enemy.velocity=Vector2.zero;
            
                        enemy.GetComponent<Enemy>().currentstate = EnemyState.idle;
        }

    }
}
