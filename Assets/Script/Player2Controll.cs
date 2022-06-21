using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player2Controll : MonoBehaviour
{
    
    [SerializeField][Tooltip("�{�����s���Ăق����ꏊ�T�[�`�p")] private BombToPoint _bombToPoint;
    [SerializeField][Tooltip("�v���C���[�̗̑�")] float _playerHp = default;
    [SerializeField][Tooltip("�����ЂƂ�̓���onoff���邽��")] PlayerControll controller1;
    [SerializeField][Tooltip("�����̓���onoff���邽��")] Player2Controll controller2;

    [Tooltip("�{���̍ő吔�J�E���g")] public int _countBomb = 1;
    [Tooltip("�ړ����x")] public float _speed = 10.0f;
    [Tooltip("���e�̔����͈�")] public int _bombRange = default;


    public GameObject Result;
    private Animator _anim;
    private Rigidbody2D rb;

    public GameObject BombPrefab;
    private void Start()
    {
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
                GameObject ins = _bombToPoint.SerchTag(this.gameObject, "Point");
                Point pointscript; //�ĂԃX�N���v�g�ɂ����Ȃ���
                pointscript = ins.GetComponent<Point>();�@//�t���Ă���X�N���v�g���擾
                if (pointscript.inBomb == false)
                {
                    Instantiate(BombPrefab, ins.transform.position, ins.transform.rotation);
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


