using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject point;//�u����point
    //private GameObject[,] newObj = new GameObject[squareY, squareX];//�u����point�̍��W
    [SerializeField] int _squareX = 19;//�Տ��x(��)���W
    [SerializeField] int _squareY = 9;//�Տ��z(�c)���W
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] float _pointX;
    [SerializeField] float _pointY;
    void Start()
    {
        for (int i = 1; i < _squareY; i++)
        {
            for (int j = 1; j < _squareX; j++)
            {
                //GameObject obj = GameObject.Find("Point");
                //GameObject newObj = Instantiate(Point);
                Instantiate(pointPrefab);
                pointPrefab.transform.position = new Vector2(j + _pointX, i + _pointY);
                

            }
        }
    }
}
