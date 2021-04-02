using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // the player
    public float smoothing; // how quickly follows
    public Vector2 maxposition;
    public Vector2 minposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != target.position){
            Vector3 targetPosition = new Vector3(target.position.x,target.position.y,transform.position.z);

            //clamping 
            targetPosition.x = Mathf.Clamp(targetPosition.x,minposition.x,maxposition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,minposition.y,maxposition.y);
            
                transform.position = Vector3.Lerp(transform.position,targetPosition,smoothing);
        }
    }
}
