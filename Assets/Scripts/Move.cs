using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Speed: " + speed);
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
