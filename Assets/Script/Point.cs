using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public bool inBomb = false;
    public bool inGround = false;
    [SerializeField][Tooltip("自分の事ポイントレイヤーにする間隔")] private float _targetTime = default;
    [SerializeField][Tooltip("時間調整マン")] private float _currentTime = default;
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_targetTime < _currentTime)
        {
            this.gameObject.layer = LayerMask.NameToLayer("Point");
            _currentTime = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        inGround = true;
        //if (collision.tag != "Player")
        //{
        //    gameObject.tag = "Aitenaiyo";
        //}
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        inGround = false;
        if (collision.gameObject.CompareTag("Bomb"))
        {
            inBomb = false;
        }
        //gameObject.tag = "Point";
    }
}
