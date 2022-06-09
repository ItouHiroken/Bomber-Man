using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField][Tooltip("�ړ����x")] float _speed = 10.0f;
    [SerializeField][Tooltip("�{�����s���Ăق����ꏊ�T�[�`�p")] private BombToPoint _bombToPoint;
    [SerializeField][Tooltip("�v���C���[�̗̑�")] float _playerHp = default;
    private Animator _anim;

    public GameObject BombPrefab;

    private void Start()
    {
        _anim = GetComponent<Animator>();
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

        if (Input.GetKeyDown(KeyCode.LeftShift))//���񂾂Ƃ��󂯂��Ȃ��������I
        {
            GameObject ins = _bombToPoint.SerchTag(this.gameObject, "Point");
            Instantiate(BombPrefab, ins.transform.position, ins.transform.rotation);
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
                        Destroy(gameObject,1.15f);

                    }
                }
            }
}


