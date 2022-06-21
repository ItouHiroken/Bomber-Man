using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningMan : MonoBehaviour
{
    [SerializeField][Tooltip("�ړ����x")] float _speed = -2.0f;
    [Tooltip("��̃A�j���[�^�[�̒u����")] private Animator anim;
    [Tooltip("�E�̒[�̏ꏊ")] private Transform _Xposition;
    private void Start()
    {
        anim = GetComponent<Animator>();
        _Xposition = GetComponent<Transform>();
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(_speed, 0);
        if (transform.position.x < -1)
        {
            Destroy(gameObject);
            //transform.position = new Vector2(21, _Xposition.position.y);
        }
    }
}
