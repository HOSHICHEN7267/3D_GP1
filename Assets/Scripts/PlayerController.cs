using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager GM;

    public float velocity = 1;
    private Rigidbody2D rigidbodyBird;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyBird = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            rigidbodyBird.velocity = Vector2.up * velocity;
        }   
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //Debug.Log("End");
        if(other.gameObject.tag == "Pipe" || other.gameObject.tag == "Background"){
            GM.GameOver();
        }  
    }
}
