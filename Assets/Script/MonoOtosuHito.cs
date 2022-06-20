using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoOtosuHito : MonoBehaviour
{
    //[SerializeField] private GameObject[] pointPrefab;
    [SerializeField][Tooltip("召喚間隔")] private float _targetTime = default;
    [SerializeField][Tooltip("召喚間隔数えるマン")] private float _currentTime = default;
    [SerializeField][Tooltip("レイ間隔")] private float _targetTime1 = default;
    [SerializeField][Tooltip("レイ間隔数えるマン")] private float _currentTime1 = default;
    //  [SerializeField][Tooltip("_isAddをいい感じにfalseにするひと")] private float _targetTime2 = default;
    [SerializeField][Tooltip("_isAddをずらす人")] private float _currentTime2 = default;
    [SerializeField][Tooltip("違うレイヤーで当たり判定とるよ！")] private LayerMask levelMask;
    public int _lostItem = 3;

    [SerializeField] List<GameObject> myList;
    [SerializeField] List<GameObject> itemList;
    public List<GameObject> useList = new List<GameObject>();
    private GameObject randomObj;
    private int choiceNum;
    bool _isAdd = false;

    [SerializeField][Tooltip("移動速度")] float _speed = -2.0f;
    //  [Tooltip("空のアニメーターの置き場")] private Animator anim;
    [Tooltip("右の端の場所")] private Transform _Xposition;

    void Start()
    {
        _Xposition = GetComponent<Transform>();
    }
    private void Update()
    {
        _currentTime += Time.deltaTime;
        _currentTime1 += Time.deltaTime;
        _currentTime2 += Time.deltaTime;
        if (_targetTime < _currentTime && _isAdd != true)
        {
            for (int i = 0; i < _lostItem; i++)
            {
                //myListの中からランダムで1つを選ぶ
                randomObj = myList[Random.Range(0, myList.Count)];
                ////選んだオブジェクトをuseListに追加
                //useList.Add(randomObj);
                randomObj.layer = LayerMask.NameToLayer("Mejirushi");
                ////選んだオブジェクトのリスト番号を取得
                //choiceNum = myList.IndexOf(randomObj);
                ////同じリスト番号をmyListから削除
                //myList.RemoveAt(choiceNum);
            }
            _isAdd = true;
            _lostItem = 3;

            ////myListの中からランダムで1つを選ぶ
            //randomObj = useList[Random.Range(0, useList.Count)];
            ////選んだオブジェクトをuseListに追加
            //myList.Add(randomObj);
            ////選んだオブジェクトのリスト番号を取得
            //choiceNum = useList.IndexOf(randomObj);
            ////同じリスト番号をmyListから削除
            //useList.RemoveAt(choiceNum);

            transform.position = new Vector2(21, _Xposition.position.y);
            _currentTime = 0;
        }

        if (_isAdd == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(_speed, 0);
            if (_targetTime1 < _currentTime1)
            {
                StartCoroutine(CreateItem(Vector3.up)); // 右に広げる
                StartCoroutine(CreateItem(Vector3.down)); // 下に広げる
                _currentTime1 = 0;
            }

        }
        if (_targetTime < _currentTime2)
        {
            _isAdd = false;
            _currentTime2 = 0;
        }
        IEnumerator CreateItem(Vector3 direction)
        {
            // 2 マス分ループする
            for (int i = 1; i < 10; i++)
            {
                // ブロックとの当たり判定の結果を格納する変数
                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0) + direction * (i - 1), direction, 1, levelMask);
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0) + direction * i, direction);

                int _random = Random.Range(0, itemList.Count);
                // 爆風を広げた先に何も存在しない場合
                if (!hit.collider)
                {


                }
                // 爆風を広げた先にブロックが存在する場合
                else
                {
                    hit.collider.gameObject.layer = LayerMask.NameToLayer("Mejirushi");    //←←←←←←←←←←当たったポイントのレイヤーかえれない！の聞く
                    Instantiate
                    (
                        itemList[Random.Range(0, _random)],
                        transform.position + (i * direction),
                        itemList[0].transform.rotation
                    );
                }

                // 0.05 秒待ってから、次のマスに爆風を広げる
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
