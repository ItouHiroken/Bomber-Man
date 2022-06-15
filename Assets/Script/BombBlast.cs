using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBlast : MonoBehaviour
{
    [Tooltip("爆弾にダメージを付与！")] public int _bombDamage;
    void Update()
    {
        Destroy(this.gameObject, 0.1f);
    }
}
