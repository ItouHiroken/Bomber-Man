using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWall : MonoBehaviour
{
    [SerializeField] float _wallHp = default;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BombBlast bomb))
        {
            _wallHp -= bomb._bombDamage;
            if (_wallHp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
