using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : ItemBase
{
    public override void Activate1()

    {
        PlayerControll playerscript; //�ĂԃX�N���v�g�ɂ����Ȃ���
        GameObject obj = GameObject.Find("Player"); //Player���Ă����I�u�W�F�N�g��T��
        playerscript = obj.GetComponent<PlayerControll>(); //�t���Ă���X�N���v�g���擾
        playerscript._speed += 1;
        Destroy(gameObject);
    }
    public override void Activate2()

    {
        Player2Controll playerscript; //�ĂԃX�N���v�g�ɂ����Ȃ���
        GameObject obj = GameObject.Find("Player2"); //Player���Ă����I�u�W�F�N�g��T��
        playerscript = obj.GetComponent<Player2Controll>(); //�t���Ă���X�N���v�g���擾
        playerscript._speed += 1;
        Destroy(gameObject);
    }
}

