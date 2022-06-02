using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _targetTime = default;
    [SerializeField] private float _currentTime = default;
    public float _bombLange = default;
    public Collider2D _collide = default;
    [SerializeField] private CircleCollider2D _circleCollider = default;


    public void Start()
    {
        _collide = GetComponent<Collider2D>();
        _collide.enabled = true;
    }
    void Update()
    {
        _currentTime += Time.deltaTime;
        if (_targetTime < _currentTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _collide.enabled = false ;
            _circleCollider.enabled = true;
        }
    }
}
