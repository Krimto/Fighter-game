using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarManager : MonoBehaviour
{
    public GameManager managerScript;
    

    public void P1Health()
    {
        if (managerScript.P1life == 4)
        {
            Destroy(GameObject.Find("P1-5"));
        }        
        if (managerScript.P1life == 3)
        {
            Destroy(GameObject.Find("P1-4"));
        }        
        if (managerScript.P1life == 2)
        {
            Destroy(GameObject.Find("P1-3"));
        }        
        if (managerScript.P1life == 1)
        {
            Destroy(GameObject.Find("P1-2"));
        }        
        if (managerScript.P1life < 1)
        {
            Destroy(GameObject.Find("P1-1"));
        }
        
    }

    public void P2Health()
    {
        if (managerScript.P2life == 4)
        {
            Destroy(GameObject.Find("P2-1"));
        }        
        if (managerScript.P2life == 3)
        {
            Destroy(GameObject.Find("P2-2"));
        }        
        if (managerScript.P2life == 2)
        {
            Destroy(GameObject.Find("P2-3"));
        }        
        if (managerScript.P2life == 1)
        {
            Destroy(GameObject.Find("P2-4"));
        }
        if (managerScript.P2life < 1)
        {
            Destroy(GameObject.Find("P2-5"));
        }
    }
}
    