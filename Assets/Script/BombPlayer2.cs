using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombPlayer2 : MonoBehaviour
{
    [SerializeField][Tooltip("爆発時間を0秒に戻す用のやつ")] private float _targetTime = default;
    [SerializeField][Tooltip("爆発する時間")] private float _currentTime = default;
    [SerializeField][Tooltip("爆弾のHP")] int _bombHp = default;
    [SerializeField][Tooltip("isTriggerのチェックがついてないやーつ")] private CircleCollider2D _circleCollider = default;
    [Tooltip("isTriggerのチェックがついてるやーつ")] public Collider2D _collide = default;
    [Tooltip("爆発のエフェクトを持ってくるよ！")] public GameObject explosionPrefab;
    [Tooltip("違うレイヤーで当たり判定とるよ！")] public LayerMask levelMask;
    [Tooltip("これはオーディオソース")] private AudioSource booooooo;
    [Tooltip("爆弾のアニメーションを持ってくるよ！")] public AudioClip audioClip;
    Player2Controll playerscript; //呼ぶスクリプトにあだなつける


    [Tooltip("これはボムからプレイヤーまで正常に動かすためにいるやつ")]private bool _bombed;
    public void Start()
    {
        booooooo = gameObject.GetComponent<AudioSource>();

        GameObject obj = GameObject.Find("Player2"); //Playerっていうオブジェクトを探す
        playerscript = obj.GetComponent<Player2Controll>();　//付いているスクリプトを取得

        _collide = GetComponent<Collider2D>();
        _collide.enabled = true;
    }
    void Update()
    {
        _currentTime += Time.deltaTime;
        if (!_bombed && _targetTime < _currentTime)
        {
            _bombed = true;
            Destroy(this.gameObject, 0.3f);
            //爆弾の位置に爆発エフェクトを作成
            GameObject newExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            newExplosion.name = explosionPrefab.name;
            StartCoroutine(CreateExplosions(Vector3.up)); // 上に広げる
            StartCoroutine(CreateExplosions(Vector3.right)); // 右に広げる
            StartCoroutine(CreateExplosions(Vector3.down)); // 下に広げる
            StartCoroutine(CreateExplosions(Vector3.left)); // 左に広げる
            BombCheck();
            booooooo.PlayOneShot(audioClip);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BombBlast bomb))
        {
            _bombHp -= bomb._bombDamage;
            if (_bombHp <= 0)
            {
                _currentTime = _targetTime;
            }
        }
    }
    void BombCheck()
    {
        Player2Controll playerscript; //呼ぶスクリプトにあだなつける
        GameObject obj = GameObject.Find("Player2"); //Playerっていうオブジェクトを探す
        playerscript = obj.GetComponent<Player2Controll>();　//付いているスクリプトを取得
        playerscript._countBomb += 1;
    }
    private IEnumerator CreateExplosions(Vector3 direction)
    {
       
        // 2 マス分ループする
        for (int i = 1; i < playerscript._bombRange; i++)
        {
            // ブロックとの当たり判定の結果を格納する変数
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0) + direction * (i - 1), direction, 1, levelMask);
            Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0) + direction * i, direction);



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