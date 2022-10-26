using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverCanvas;

    public int level = 1;

    private int bossScene_timer = 0;
    private bool bossScene_count = false;

    private void Start()
    {
        level = 1;
        gameoverCanvas.SetActive(false);  
        Time.timeScale = 1;  
    }

    private void Update()
    {
        if(bossScene_count){
            bossScene_timer++;
        }

        if(bossScene_timer > 300){
            bossScene_count = false;
            bossScene_timer = 0;
            SceneManager.LoadScene(1);
        }
    }

    public void BossScene(){
        bossScene_count = true;
    }

    public void NormalScene(){
        level++;
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        if(!bossScene_count){
            gameoverCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
