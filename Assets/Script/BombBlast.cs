using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBlast : MonoBehaviour
{
    [Tooltip("���e�Ƀ_���[�W��t�^�I")] public int _bombDamage;
    void Update()
    {
        Destroy(this.gameObject, 0.1f);
    }
}
