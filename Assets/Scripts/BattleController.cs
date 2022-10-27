using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{

    public GameManager GM;

    public float velocity = 4;
    public float shootSpeed, shootTimer;
    private bool isShooting;
    public Transform shootPos;
    public GameObject bullet;
    private Rigidbody2D rigidbodyBird;

    void Start()
    {
        rigidbodyBird = GetComponent<Rigidbody2D>();
        isShooting = false;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !isShooting){
            //Jump
            rigidbodyBird.velocity = Vector2.up * velocity;
            //Shoot
            StartCoroutine(Shoot());
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //Debug.Log("Laser");
        if(other.gameObject.tag == "Laser"){
            //Debug.Log("Laser");
            GM.GameOver();
        }
        else if(other.gameObject.tag == "Background"){
            GM.GameOver();
        }
        else if(other.gameObject.tag == "Bullet"){
            //Debug.Log("Bullet");
        }
    }

    IEnumerator Shoot(){
        isShooting = true;
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Time.fixedDeltaTime, 0f);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
    
}
