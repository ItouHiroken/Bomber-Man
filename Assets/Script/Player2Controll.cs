using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class Player2Controll : MonoBehaviour
{
    [SerializeField][Tooltip("プレイヤーの体力")] float _playerHp = default;
    [SerializeField][Tooltip("もうひとりの動きonoffするため")] PlayerControll controller1;
    [SerializeField][Tooltip("自分の動きonoffするため")] Player2Controll controller2;

    [Tooltip("ボムの最大数カウント")] public int _countBomb = 1;
    [Tooltip("移動速度")] public float _speed = 10.0f;
    [Tooltip("爆弾の爆発範囲")] public int _bombRange = default;


    public GameObject Result;
    private Animator _anim;
    private Rigidbody2D rb;

    public GameObject BombPrefab;
    
    GameObject[] _points = default;
    GameObject Point;
    private void Start()
    {
        _points = GameObject.FindGameObjectsWithTag("Point");
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Result.SetActive(false);
    }
    void Update()
    {
        float verticalInput = _speed * Input.GetAxisRaw("Player2 Vertical");
        float horizontalInput = _speed * Input.GetAxisRaw("Player2 Horizontal");
        rb.velocity = new Vector2(horizontalInput, verticalInput);
        Vector2 _playerPosition = GameObject.Find("Player2").transform.position;

        float bombx = _playerPosition.x;
        float bomby = _playerPosition.y;
        Mathf.Round(bombx);
        Mathf.Round(bomby);

        if (_countBomb >= 1)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Point = _points.OrderBy(x =>
                Vector2.Distance(gameObject.transform.position, x.transform.position)
                ).FirstOrDefault();
                Point pointscript; //呼ぶスクリプトにあだなつける
                pointscript = Point.GetComponent<Point>();　//付いているスクリプトを取得
                if (pointscript.inBomb == false)
                {
                    Instantiate(BombPrefab, Point.transform.position, Point.transform.rotation);
                    _countBomb -= 1;
                    pointscript.inBomb = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _anim.SetFloat("walkfloat", 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _anim.SetFloat("walkfloat", -1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _anim.SetFloat("horizonfloat", 1);
            this.transform.localScale = new Vector2(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _anim.SetFloat("horizonfloat", -1);
            this.transform.localScale = new Vector2(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            _anim.SetFloat("walkfloat", 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _anim.SetFloat("horizonfloat", 0);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BombBlast bomb))
        {
            _playerHp -= bomb._bombDamage;
            if (_playerHp <= 0 && !controller1.IsDead)
            {
                controller1.IsDead = true;
                _anim.SetBool("alive", false);
                controller1.enabled = false;
                controller2.enabled = false;
                Destroy(gameObject, 1.15f);
                Result.SetActive(true);
            }
        }
    }
}


