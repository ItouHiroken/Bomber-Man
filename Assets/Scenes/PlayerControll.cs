using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] private BombToPoint _bombToPoint;

    public GameObject BombPrefab;
    void Update()
    {
        float verticalInput = speed * Input.GetAxis("Vertical");
        float horizontalInput = speed * Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalInput, verticalInput);
        Vector2 wawa = GameObject.Find("Player").transform.position;
        
        float bombx = wawa.x;
        float bomby = wawa.y;
        Mathf.Round(bombx);
        Mathf.Round(bomby);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ins = _bombToPoint.SerchTag(this.gameObject, "Point");
            Instantiate(BombPrefab, ins.transform.position, ins.transform.rotation);
        }
        
    }
}

