using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{

    public Vector2 camerachange;
    public Vector3 playerchange;
    private CameraMovement cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
                cam.minposition+=camerachange;
                cam.maxposition+=camerachange;
                other.transform.position += playerchange;
                Debug.Log(camerachange);
        }
    }
}
