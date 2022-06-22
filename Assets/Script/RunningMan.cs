using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningMan : MonoBehaviour
{
    [SerializeField][Tooltip("移動速度")] float _speed = -2.0f;
    [Tooltip("空のアニメーターの置き場")] private Animator anim;
    [Tooltip("右の端の場所")] private Transform _Xposition;
    [SerializeField][Tooltip("召喚間隔")] private float _targetTime = default;
    [SerializeField][Tooltip("召喚間隔数えるマン")] private float _currentTime = default;
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
