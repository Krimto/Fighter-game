using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{   
    
    public KeyCode attack;
    private Animator anim;
    private bool isAttacking;
    private bool isBlocking; 
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPoint;
    public float attackRange = 2f;
    public LayerMask playerMask;
    
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
        if(timeBtwAttack <= 0){
            if(Input.GetKeyDown(attack))
            {
                Attack();
                attackanim();
                timeBtwAttack = startTimeBtwAttack;
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
            if (Player.CompareTag("Player2"))
            {
                if (!isBlocking)
                {
                    Debug.Log("Hit" + Player.name);
                    FindObjectOfType<GameManager>().HurtP2();   
                }
            }
            if (Player.CompareTag("Player1"))
            {
                if (!isBlocking)
                {
                    Debug.Log("Hit" + Player.name);
                    FindObjectOfType<GameManager>().HurtP1();
                }
            }
        }
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



