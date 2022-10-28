using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameManager GM;

    public static int score = 0;
    public static int targetScore = 5;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        targetScore = 5 * LevelController.level;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = score.ToString();

        if(score >= targetScore){
            GM.BossScene();
        }
    }
}
