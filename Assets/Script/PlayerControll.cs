using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControll : MonoBehaviour
{

    [SerializeField][Tooltip("ボムが行ってほしい場所サーチ用")] private BombToPoint _bombToPoint;
    [SerializeField][Tooltip("プレイヤーの体力")] float _playerHp = default;
    [SerializeField][Tooltip("自分のonoffするため")] PlayerControll controller1;
    [Tooltip("ボムの最大数カウント")] public int _countBomb =1 ; 
    [Tooltip("移動速度")] public float _speed = 10.0f;
    [Tooltip("爆弾の爆発範囲")] public int _bombRange = default;


    public GameObject Result;
    private Animator _anim;

    public GameObject BombPrefab;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        Result.SetActive(false);
    }
    void Update()
    {
        float verticalInput = _speed * Input.GetAxisRaw("Vertical");
        float horizontalInput = _speed * Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalInput, verticalInput);
        Vector2 _playerPosition = GameObject.Find("Player").transform.position;

        float bombx = _playerPosition.x;
        float bomby = _playerPosition.y;
        Mathf.Round(bombx);
        Mathf.Round(bomby);

        if (_countBomb >= 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))//死んだとき受けつけなくしたい！
        {
            GameObject ins = _bombToPoint.SerchTag(this.gameObject, "Point");
            Instantiate(BombPrefab, ins.transform.position, ins.transform.rotation);
            _countBomb -= 1;
        }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _anim.SetFloat("walkfloat", 1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _anim.SetFloat("walkfloat", -1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _anim.SetFloat("horizonfloat", 1);
            this.transform.localScale = new Vector2(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _anim.SetFloat("horizonfloat", -1);
            this.transform.localScale = new Vector2(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            _anim.SetFloat("walkfloat", 0);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _anim.SetFloat("horizonfloat", 0);


            //    //_anim.SetFloat("walkfloat", Input.GetAxisRaw("Vertical"));
            //    //_anim.SetFloat("horizonfloat", Input.GetAxisRaw("Horizontal"));
            //}

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BombBlast bomb))
        {
            _playerHp -= bomb._bombDamage;
            if (_playerHp <= 0)
            {
                _anim.SetBool("alive", false);
                controller1.enabled = false;
                Destroy(gameObject, 1.15f);
                Result.SetActive(true);
            }
        }
    }
}


