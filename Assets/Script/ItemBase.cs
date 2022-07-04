using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    private string playername;
    [SerializeField] int _Hp = 1;
    public abstract void Activate1();
    public abstract void Activate2();
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playername = collision.gameObject.name;
            if (playername == "Player")
            {
                Activate1();
            }
            if (playername == "Player2")
            {
                Activate2();
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
    public void LostItemIncrease()
        {
            MonoOtosuHito script; //呼ぶスクリプトにあだなつける
            GameObject obj = GameObject.Find("Sorakarabusshi"); //Playerっていうオブジェクトを探す
            script = obj.GetComponent<MonoOtosuHito>(); //付いているスクリプトを取得
            script._lostItem += 1;
            Destroy(gameObject);
        }
}
