using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : ItemBase
{
    public override void Activate1()

    {
        PlayerControll playerscript; //呼ぶスクリプトにあだなつける
        GameObject obj = GameObject.Find("Player"); //Playerっていうオブジェクトを探す
        playerscript = obj.GetComponent<PlayerControll>(); //付いているスクリプトを取得
        playerscript._speed += 1;
        Destroy(gameObject);
    }
    public override void Activate2()

    {
        Player2Controll playerscript; //呼ぶスクリプトにあだなつける
        GameObject obj = GameObject.Find("Player2"); //Playerっていうオブジェクトを探す
        playerscript = obj.GetComponent<Player2Controll>(); //付いているスクリプトを取得
        playerscript._speed += 1;
        Destroy(gameObject);
    }
}

