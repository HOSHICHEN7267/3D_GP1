using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour{

    public GameManager GM;

    // HP
    bool isDead = false;
    public int monsterHP = 10000;
    public MonsterHPController monsterHPController;

    // Position
    public float mainCameraSize = 3.6f;
    public float monsterX;
    float monsterY;

    // Attack
    bool isReady = false;
    bool isAttacked = false;
    public float firePeriodK = 5;
    float firePeriod;
    float fireCD;
    public int damageUnit = 1000;    // When the monster was hurt, 
                                        // its HP will decrease by this value.
    public LaserController laser;

    // Appear
    float isJumping = 1f;   // 1:   is jumping
                            // -1:  is falling
    float stayGroundPeriod = 0.1f;
    float stayGroundCD;

    // Animation
    float monsterFloat = -0.1f;    // +:   up
                                    // -:  down
    float monsterShake = 0.5f;

    void Start(){
        GM = GameObject.FindObjectOfType<GameManager>();
        monsterY = -0.1f * mainCameraSize;
        this.transform.position = new Vector3( mainCameraSize + monsterX * 1.9f, monsterY, 0f );
        firePeriod = mainCameraSize * firePeriodK;
        fireCD = firePeriod;
        stayGroundCD = stayGroundPeriod;
        resetMonsterShake();
        Debug.Log( "The monster is summoned." );
    }

    void Update(){
        if( isDead ){
            ShakingAnimation();
            resetMonsterShake();
            DefeatAnimation( Time.deltaTime );
        }
        else if( isReady ){
            // Floating animation
            FloatingAnimation( Time.deltaTime );
            // If the monster is attacked
            if( isAttacked ){
                if( monsterShake > 0.05 ){
                    ShakingAnimation();
                }
                else{
                    resetMonsterShake();
                    isAttacked = false;
                }
            }
            // Countdown for firing
            else{
                fireCD -= Time.deltaTime;
                if( fireCD <= 0 ){
                    Fire();
                    fireCD = firePeriod;
                }
            }
        }
        else{
            Appear();
            // When the monster arrive at the specified position
            if( this.transform.position.x <= monsterX ){
                isReady = true;
                monsterHPController.HPDisplay( monsterHP );
                Debug.Log( "The monster is ready to fight!" );
            }   
        }
    }

    void Appear(){
        // Reach the ground and stay
        if( this.transform.position.y <= monsterY && stayGroundCD > 0 ){
            stayGroundCD -= Time.deltaTime;
        }

        // Moving
        else{
            this.transform.position += new Vector3( -0.8f * mainCameraSize * Time.deltaTime, isJumping * 0.5f * mainCameraSize * Time.deltaTime, 0f );
            // Change the direction the monster moves
            if( ( this.transform.position.y < monsterY && isJumping == -1f ) || ( this.transform.position.y > -1f * monsterY && isJumping == 1f ) ){
                isJumping *= -1f;
                if( this.transform.position.y <= monsterY ){
                    stayGroundCD = stayGroundPeriod;
                }
            }
        }
    }

    void Fire(){
        Instantiate( laser, this.transform.position + new Vector3( 2 * monsterX, Random.Range( -0.8f * mainCameraSize, 0.8f * mainCameraSize ), 0f ), Quaternion.identity );
    }

    void OnTriggerEnter2D( Collider2D other ){
        if( other.tag == "Bullet" && isReady ){
            isAttacked = true;
            monsterHP -= damageUnit;
            if( monsterHP <= 0 ){
                monsterHP = 0;
                isDead = true;
                Debug.Log( "The monster has been defeated.");
            }
            monsterHPController.HPDisplay( monsterHP );
        }
    }

    void FloatingAnimation( float dTime ){
        this.transform.position += new Vector3( 0f, monsterFloat * mainCameraSize * dTime, 0f );
        if( ( this.transform.position.y < monsterY - 0.2f && monsterFloat < 0 ) || ( monsterY + 0.2f < this.transform.position.y && monsterFloat > 0 ) ){
            //Debug.Log($"monsterY - 0.2 = {monsterY - 0.2f}");
            monsterFloat *= -1f;
        }
    }

    void ShakingAnimation(){
        this.transform.position = new Vector3( monsterX + Random.Range( 0f, monsterShake ), this.transform.position.y, 0f );
        monsterShake *= 0.95f;
    }

    void DefeatAnimation( float dTime ){
        this.transform.position += new Vector3( 0f, -0.5f * mainCameraSize * dTime, 0f );
        if( this.transform.position.y < -2f * mainCameraSize ){
            Destroy( this.transform.parent.gameObject );
            GM.NormalScene();
        }
    }

    void resetMonsterShake(){
        monsterShake = 0.5f;
    }
}
