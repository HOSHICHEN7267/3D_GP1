using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float maxTime = 3f;
    private float timer = 0;
    public GameObject pipe;
    public float height;
    public Move move;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        if(Score.score > 10 &&  Score.score <= 20)
        {
            move.speed = 4;
        }
        else if(Score.score > 20 &&  Score.score <= 30)
        {
            move.speed = 5;
        }
        
        timer += Time.deltaTime;
    }

    
}
