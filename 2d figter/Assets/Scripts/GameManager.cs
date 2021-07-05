using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;

    public int P1life;
    public int P2life;

    public GameObject GameOver;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (P1life <= 0)
        {
            Player1.SetActive(false);
            GameOver.SetActive (true);

        }
        if (P2life <= 0)
        {
            Player2.SetActive(false);
            GameOver.SetActive (true);

        }
    }
    public void HurtP1()
    {
        P1life -= 1;
    }
    public void HurtP2()
    {
        P2life -= 1;
    }
}
    