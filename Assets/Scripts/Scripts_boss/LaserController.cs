using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour{
    public float speedK = 1f;
    float speed;
    public GameManager GM;

    void Start(){
        GM = GameObject.FindObjectOfType<GameManager>();
        speed = GameObject.FindObjectOfType<MonsterController>().mainCameraSize;
        Destroy( this.gameObject, 3f * speed );
    }

    void Update(){
        this.transform.position -= new Vector3( speedK * speed * Time.deltaTime, 0f, 0f );
    }

    void OnTriggerEnter2D( Collider2D other ){

        if( other.gameObject.tag == "Bird" ){
            Debug.Log("<Laser> Collide with bird.");
            GM.GameOver();
            Destroy( this.gameObject );
        }
    }
}
