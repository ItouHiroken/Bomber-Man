using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : MonoBehaviour
{
    private string playername;
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
    }
    void MSIncrease()
    {
        PlayerControll playerscript; //�ĂԃX�N���v�g�ɂ����Ȃ���
        GameObject obj = GameObject.Find("Player"); //Player���Ă����I�u�W�F�N�g��T��
        playerscript = obj.GetComponent<PlayerControll>();�@//�t���Ă���X�N���v�g���擾
        playerscript._speed += 1;
        Destroy(gameObject);
    }
    void MSIncrease2()
    {
        Player2Controll playerscript; //�ĂԃX�N���v�g�ɂ����Ȃ���
        GameObject obj = GameObject.Find("Player2"); //Player���Ă����I�u�W�F�N�g��T��
        playerscript = obj.GetComponent<Player2Controll>();�@//�t���Ă���X�N���v�g���擾
        playerscript._speed += 1;
        Destroy(gameObject);
    }
}
