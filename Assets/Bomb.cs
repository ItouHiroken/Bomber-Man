using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _targetTime = default;
    [SerializeField] private float _currentTime = default;
    [SerializeField] float _bombHp = default;
    [SerializeField] private CircleCollider2D _circleCollider = default;
    [SerializeField] public float _bombRange = default;
    [SerializeField] public Collider2D _collide = default;

    [SerializeField] public GameObject explosionPrefab;
    [SerializeField] public LayerMask levelMask;

    public void Start()
    {
        _collide = GetComponent<Collider2D>();
        _collide.enabled = true;
    }
    void Update()
    {
        _currentTime += Time.deltaTime;
        if (_targetTime < _currentTime)
        {
            Destroy(this.gameObject, 0.3f);
            //爆弾の位置に爆発エフェクトを作成
            GameObject newExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            newExplosion.name = explosionPrefab.name;
            StartCoroutine(CreateExplosions(Vector3.up)); // 上に広げる
            StartCoroutine(CreateExplosions(Vector3.right)); // 右に広げる
            StartCoroutine(CreateExplosions(Vector3.down)); // 下に広げる
            StartCoroutine(CreateExplosions(Vector3.left)); // 左に広げる
            //爆弾を非表示にする
            //GetComponent<MeshRenderer>().enabled = false;
            //transform.Find("Collider").gameObject.SetActive(false);
        }
        //GameObject obj = GameObject.Find("bomb_explosion_10");
        // 指定したオブジェクトを削除
        //Destroy(obj, 0.3f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BombBlast bomb))
        {
            _bombHp -= bomb._bombDamage;
            if (_bombHp <= 0)
            {
                //Destroy(gameObject);
                //GameObject newExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                //newExplosion.name = explosionPrefab.name;
                //StartCoroutine(CreateExplosions(Vector3.up)); // 上に広げる
                //StartCoroutine(CreateExplosions(Vector3.right)); // 右に広げる
                //StartCoroutine(CreateExplosions(Vector3.down)); // 下に広げる
                //StartCoroutine(CreateExplosions(Vector3.left)); // 左に広げる
                _currentTime = _targetTime;
            }
        }
    }

    // 爆風を広げる
    private IEnumerator CreateExplosions(Vector3 direction)
    {
        // 2 マス分ループする
        for (int i = 1; i < _bombRange; i++)
        {
            // ブロックとの当たり判定の結果を格納する変数
           RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0) + direction * (i-1), direction, 1, levelMask);
           Debug.DrawRay(transform.position+new Vector3(0,0.5f,0) + direction * i, direction);

           

            // 爆風を広げた先に何も存在しない場合
            if (!hit.collider)
            {
                // 爆風を広げるために、
                // 爆発エフェクトのオブジェクトを作成
                Instantiate
                (
                    explosionPrefab,
                    transform.position + (i * direction),
                    explosionPrefab.transform.rotation
                );
            }
            // 爆風を広げた先にブロックが存在する場合
            else
            {
                //もういちます伸ばしてダメージ判定のエフェクトにする
                Instantiate
                (
                    explosionPrefab,
                    transform.position + (i * direction),
                    explosionPrefab.transform.rotation
                );
                // 爆風はこれ以上広げない
                break;
            }

            // 0.05 秒待ってから、次のマスに爆風を広げる
            yield return new WaitForSeconds(0.05f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _collide.enabled = false;
            _circleCollider.enabled = true;
        }
    }
}
