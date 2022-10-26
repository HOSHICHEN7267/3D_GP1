using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour{
    public float speedK = 1f;
    float speed;
    public GameManager GM;

    void Start(){
        speed = GameObject.FindObjectOfType<MonsterController>().mainCameraSize;
        Destroy( this.gameObject, 3f * speed );
    }

    void Update(){
        this.transform.position -= new Vector3( speedK * speed * Time.deltaTime, 0f, 0f );
    }

    // void OnTriggerEnter2D( Collider2D other ){
        
    //     Debug.Log("trigger");

    //     if( other.gameObject.tag == "Bird" ){
    //         Debug.Log("Bird");
    //         GM.GameOver();
    //         //Destroy( this.gameObject );
    //     }
    // }
}
