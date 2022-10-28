using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    //public LevelController LC;

    public float maxTime = 3f;
    private float timer = 0;
    public GameObject pipe;
    public float height;
    public Move move;
    public int initSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        initSpeed = 50;
        Debug.Log("LC.level: " + LevelController.level);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > maxTime)
        {
            GameObject newpipe = Instantiate(pipe, transform);
            newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newpipe, 9);
            timer = 0;
        }

        //move.speed = initSpeed + 10 * (LevelController.level - 1);
        //Debug.Log("move.speed: " + move.speed);
        
        timer += Time.deltaTime;
    }

    
}
