using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScriptBackup : MonoBehaviour
{   
    
    public KeyCode attack;
    private Animator anim;
    public Transform AttackPoint;
    public float AttackRange =0.5f;
    private bool isAttacking;
    private bool isBlocking; 
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    
    void attackanim()
        {
            //play attack animation
            anim.SetTrigger("Attack");
        }
    void OnTrigger2D(Collider2D other)
    {    
        if(isAttacking)
        {
            if(!isBlocking)
            {
                if(other.tag == "Player1")
                {
                    FindObjectOfType<GameManager>().HurtP1();
                 }
                 if(other.tag == "Player2")
             {
                FindObjectOfType<GameManager>().HurtP2();
             }


            }
        }

            

        
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0){
                if(Input.GetKeyDown(attack)){
                    isAttacking = true;
                     attackanim();
                     timeBtwAttack = startTimeBtwAttack;
                 }
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
        
        if(Input.GetKeyUp(attack)){
            isAttacking = false;
        }
        
       
    }
}

