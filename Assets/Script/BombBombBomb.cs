using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBombBomb : MonoBehaviour
{
    private string playername;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playername = collision.gameObject.name;
            if (playername =="Player" ) 
            {
                BombIncrease();
            }
            if (playername == "Player2") 
            {
                BombIncrease2();

            }

        }
    }
    void BombIncrease()
    {
        PlayerControll playerscript; //呼ぶスクリプトにあだなつける
        GameObject obj = GameObject.Find("Player"); //Playerっていうオブジェクトを探す
        playerscript = obj.GetComponent<PlayerControll>();　//付いているスクリプトを取得
        playerscript._countBomb += 1;
        Destroy(gameObject);
    }
    void BombIncrease2()
    {
        Player2Controll playerscript; //呼ぶスクリプトにあだなつける
        GameObject obj = GameObject.Find("Player2"); //Playerっていうオブジェクトを探す
        playerscript = obj.GetComponent<Player2Controll>();　//付いているスクリプトを取得
        playerscript._countBomb += 1;
        Destroy(gameObject);
    }
}
