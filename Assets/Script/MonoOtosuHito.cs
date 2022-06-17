using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoOtosuHito : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPrefab; 
    [SerializeField] private GameObject[] pointPrefab;

    private void Start()
    {
        
    }
    private IEnumerator CreateExplosions(Vector3 direction)
    {
        // 2 マス分ループする
        for (int i = 1; i < 6; i++)
        {
            // ブロックとの当たり判定の結果を格納する変数
          //  RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0) + direction * (i - 1), direction, 1, levelMask);
            Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0) + direction * i, direction);



            // 爆風を広げた先に何も存在しない場合
          //  if (!hit.collider)
            {
                // 爆風を広げるために、
                // 爆発エフェクトのオブジェクトを作成
          //      Instantiate
          //      (
             //       explosionPrefab,
              //      transform.position + (i * direction),
             //       explosionPrefab.transform.rotation
          //      );
            }
            // 0.05 秒待ってから、次のマスに爆風を広げる
            yield return new WaitForSeconds(0.05f);
        }
    }
}
