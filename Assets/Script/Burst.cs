using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour
{
    private string playername;
    [SerializeField] int _Hp = 1;

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
        if (collision.gameObject.TryGetComponent(out BombBlast bomb))
        {
            _Hp -= bomb._bombDamage;
            if (_Hp <= 0)
            {
                LostItemIncrease();
                Destroy(gameObject);
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
    void LostItemIncrease()
    {
        MonoOtosuHito script; //呼ぶスクリプトにあだなつける
        GameObject obj = GameObject.Find("Sorakarabusshi"); //Playerっていうオブジェクトを探す
        script = obj.GetComponent<MonoOtosuHito>(); //付いているスクリプトを取得
        script._lostItem += 1;
        Destroy(gameObject);
    }
}
