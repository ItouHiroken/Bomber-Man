using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : MonoBehaviour
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
                MSIncrease();
            }
            if (playername == "Player2")
            {
                MSIncrease2();
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

        void MSIncrease()
        {
            PlayerControll playerscript; //呼ぶスクリプトにあだなつける
            GameObject obj = GameObject.Find("Player"); //Playerっていうオブジェクトを探す
            playerscript = obj.GetComponent<PlayerControll>(); //付いているスクリプトを取得
            playerscript._speed += 1;
            Destroy(gameObject);
        }
        void MSIncrease2()
        {
            Player2Controll playerscript; //呼ぶスクリプトにあだなつける
            GameObject obj = GameObject.Find("Player2"); //Playerっていうオブジェクトを探す
            playerscript = obj.GetComponent<Player2Controll>(); //付いているスクリプトを取得
            playerscript._speed += 1;
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
}
