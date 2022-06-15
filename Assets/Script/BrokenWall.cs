using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWall : MonoBehaviour
{
    [SerializeField][Tooltip("�ǂ̗̑́I")] float _wallHp = default;
    [SerializeField] private GameObject[] itemPrefab;
    //float posx = transform.position.x;

    private void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BombBlast bomb))
        {
            _wallHp -= bomb._bombDamage;
            if (_wallHp <= 0)
            { 
                SpawnRandomItem();
                Destroy(gameObject);
                Debug.Log("aa");
            }
        }
    }

    void SpawnRandomItem()
    {
        Vector2 _wallPosition = new Vector2(transform.position.x, transform.position.y);
        int N = Random.Range(0, itemPrefab.Length);
        Instantiate(itemPrefab[N], _wallPosition, itemPrefab[N].transform.rotation) ;
    }
}
