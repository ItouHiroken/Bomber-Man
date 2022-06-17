using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public bool inBomb=true;
    public bool inGround=false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        inGround = true;
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        inGround=false;
        if (collision.gameObject.CompareTag("Bomb"))
        {
            inBomb=true;
        }
    }
}
