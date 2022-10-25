using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public float velocity = 4;
    public float shootSpeed, shootTimer;
    private bool isShooting;
    public Transform shootPos;
    public GameObject bullet;
    private Rigidbody2D rigidbodyBird;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyBird = GetComponent<Rigidbody2D>();
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !isShooting){
            //Jump
            rigidbodyBird.velocity = Vector2.up * velocity;
            //Shoot
            StartCoroutine(Shoot());
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
