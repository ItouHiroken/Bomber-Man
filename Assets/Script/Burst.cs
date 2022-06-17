using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour
{
    private string playername;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playername = collision.gameObject.name;
            if (playername == "Player")
            {
                BurstIncrease();
            }
            if (playername == "Player2")
            {
                BurstIncrease2();
            }
        }
    }
    void BurstIncrease()
    {
        PlayerControll playerscript; //呼ぶスクリプトにあだなつける
        GameObject obj = GameObject.Find("Player"); //Playerっていうオブジェクトを探す
        playerscript = obj.GetComponent<PlayerControll>();　//付いているスクリプトを取得
        playerscript._bombRange += 1;
        Destroy(gameObject);
    }
    void BurstIncrease2()
    {
        Player2Controll playerscript; //呼ぶスクリプトにあだなつける
        GameObject obj = GameObject.Find("Player2"); //Playerっていうオブジェクトを探す
        playerscript = obj.GetComponent<Player2Controll>();　//付いているスクリプトを取得
        playerscript._bombRange += 1;
        Destroy(gameObject);
    }
}
