using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    static LevelController instance;
    static public int level = 1;

    void Awake () {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            level = 1;
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }
    }     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
