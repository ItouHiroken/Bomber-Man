using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBlast : MonoBehaviour
{
    [Tooltip("���e�Ƀ_���[�W��t�^�I")] public int _bombDamage;
    [Tooltip("�����̓���onoff���邽��")] BombBlast blastCollider ;

    private void Start()
    {
      //blastCollider = gameObject.GetComponent<BoxCollider2D>(); //�t���Ă���X�N���v�g���擾
                                                           // blastCollider
    }
    void Update()
    {
        //blastCollider.enabled = false;
        Destroy(this.gameObject, 0.3f);
    }
}
