using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{   
    
    public KeyCode attack;
    public KeyCode block;
    private Animator anim;
    private bool isAttacking;
    public bool isBlocking; 
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPoint;
    public float attackRange = 2f;
    public LayerMask playerMask;

    public AudioSource hurtsound;
    public AudioSource blocksound;
    public AudioSource swingSound;

    public HealthbarManager healthBar;
    void attackanim()
        {
            //play attack animation
            anim.SetTrigger("Attack");
        }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attackPoint = this.gameObject.transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(block))
        {
            blocking();
        }

        if (Input.GetKeyUp(block))
        {
            isBlocking = false;
            anim.SetBool("Block", false);
        }
        if(timeBtwAttack <= 0){
            if(Input.GetKeyDown(attack))
            {
                if (!isBlocking)
                {
                    swingSound.Play();
                    Attack();
                    attackanim();
                    timeBtwAttack = startTimeBtwAttack;
                }
            }
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    void Attack()
    {
        //checkt de colliders van geraakte enemies. en slaat ze op in een array.
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerMask);

        foreach (Collider2D Player in hitEnemies)
        {
            if (Player.CompareTag("Player1"))
            {
                if (!Player.GetComponent<AttackScript>().isBlocking)
                {
                    FindObjectOfType<GameManager>().HurtP1();
                    healthBar.P1Health();
                    hurtsound.Play();
                }
                if (Player.GetComponent<AttackScript>().isBlocking)
                {
                    blocksound.Play();
                }
            }
            if (Player.CompareTag("Player2"))
            {
                if (!Player.GetComponent<AttackScript>().isBlocking)
                {
                    FindObjectOfType<GameManager>().HurtP2();
                    healthBar.P2Health();
                    hurtsound.Play();
                }
                if (Player.GetComponent<AttackScript>().isBlocking)
                {
                    blocksound.Play();
                }
            }
            
        }
    }
    void blocking()
    {
        isBlocking = true;
        anim.SetBool("Block", true);
    }
    //deze functie is alleen om de range te zien van bijv de attackpoint range. deze kan dus weg als dit niet meer nodig is.
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}



