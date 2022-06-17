using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBlast : MonoBehaviour
{
    [Tooltip("爆弾にダメージを付与！")] public int _bombDamage;
    [Tooltip("自分の動きonoffするため")] BombBlast blastCollider ;

    private void Start()
    {
      //blastCollider = gameObject.GetComponent<BoxCollider2D>(); //付いているスクリプトを取得
                                                           // blastCollider
    }
    void Update()
    {
        //blastCollider.enabled = false;
        Destroy(this.gameObject, 0.3f);
    }
}
