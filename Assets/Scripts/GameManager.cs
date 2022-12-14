using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelController LC;

    public GameObject gameoverCanvas;

    private int bossScene_timer = 0;
    private bool bossScene_count = false;

    private void Start()
    {
        gameoverCanvas.SetActive(false);  
        Time.timeScale = 1;  
        if( SceneManager.GetActiveScene().buildIndex == 1 ){
            GameObject currBoss = Instantiate(LC.CurrentBoss());
        }
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
        LevelController.level++;
        LC.AddBossListIndex();
        Debug.Log("LC.level: " + LevelController.level);
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
        LevelController.level = 1;
        SceneManager.LoadScene(0);
    }
}
