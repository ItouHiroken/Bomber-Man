using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombToPoint : MonoBehaviour
{
    private GameObject nearObj;         //最も近いオブジェクト
    private float _searchTime = 0;    //経過時間

    // Use this for initialization
    void Start()
    {
        //最も近かったオブジェクトを取得
       // nearObj = SerchTag(gameObject, "Point");
    }

    // Update is called once per frame
    void Update()
    {

        //経過時間を取得
        _searchTime += Time.deltaTime;

        if (_searchTime >= 1.0f)
        {
            //最も近かったオブジェクトを取得
            nearObj = SerchTag(gameObject, "Point");

            //経過時間を初期化
            _searchTime = 0;
        }
        //自分自身の位置から相対的に移動する
        transform.Translate(Vector3.forward * 0.01f);
    }

    //指定されたタグの中で最も近いものを取得
    public GameObject SerchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }
}