using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningMan : MonoBehaviour
{
    [SerializeField][Tooltip("�ړ����x")] float _speed = -2.0f;
    [Tooltip("��̃A�j���[�^�[�̒u����")] private Animator anim;
    [Tooltip("�E�̒[�̏ꏊ")] private Transform _Xposition;
    [SerializeField][Tooltip("�����Ԋu")] private float _targetTime = default;
    [SerializeField][Tooltip("�����Ԋu������}��")] private float _currentTime = default;
    private void Start()
    {
        anim = GetComponent<Animator>();
        _Xposition = GetComponent<Transform>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(_speed, 0);
    }

    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_targetTime < _currentTime)
        {
            transform.position = new Vector2(21, _Xposition.position.y);
            _currentTime = 0;
        }
    }
}
