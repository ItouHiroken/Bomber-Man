using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningMan : MonoBehaviour
{
    [SerializeField][Tooltip("移動速度")] float _speed = -2.0f;
    [Tooltip("空のアニメーターの置き場")] private Animator anim;
    [Tooltip("右の端の場所")] private Transform _Xposition;
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
