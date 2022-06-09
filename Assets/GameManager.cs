using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public GameObject point;//置いたpoint
    //private GameObject[,] newObj = new GameObject[squareY, squareX];//置いたpointの座標
    [SerializeField] [Tooltip("")]GameObject runningObj = GameObject.Find("runningman");
   // [SerializeField] GameObject runningObj2 = GameObject.Find("runningman2");
    [SerializeField] GameObject player1Obj = GameObject.Find("Player");
    [SerializeField] GameObject player2Obj = GameObject.Find("Player2");

    [SerializeField] GameObject runningmanPrefab;

    [SerializeField] int _squareX = 19;//盤上のx(横)座標
    [SerializeField] int _squareY = 9;//盤上のz(縦)座標
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

    public void Update()
    {
        if (runningObj == null)
        {
            GameObject newRunningMan = Instantiate(runningmanPrefab);
            newRunningMan.name = runningmanPrefab.name;
        }
        if(player1Obj==null || player2Obj==null)
        {
            Debug.Log("kirikae");
            SceneManager.LoadScene("GameStart");
        }
    }
}
