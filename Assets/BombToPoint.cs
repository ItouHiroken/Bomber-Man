using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombToPoint : MonoBehaviour
{
    private GameObject nearObj;         //�ł��߂��I�u�W�F�N�g
    private float _searchTime = 0;    //�o�ߎ���

    // Use this for initialization
    void Start()
    {
        //�ł��߂������I�u�W�F�N�g���擾
       // nearObj = SerchTag(gameObject, "Point");
    }

    // Update is called once per frame
    void Update()
    {

        //�o�ߎ��Ԃ��擾
        _searchTime += Time.deltaTime;

        if (_searchTime >= 1.0f)
        {
            //�ł��߂������I�u�W�F�N�g���擾
            nearObj = SerchTag(gameObject, "Point");

            //�o�ߎ��Ԃ�������
            _searchTime = 0;
        }
        //�������g�̈ʒu���瑊�ΓI�Ɉړ�����
        transform.Translate(Vector3.forward * 0.01f);
    }

    //�w�肳�ꂽ�^�O�̒��ōł��߂����̂��擾
    public GameObject SerchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //�����p�ꎞ�ϐ�
        float nearDis = 0;          //�ł��߂��I�u�W�F�N�g�̋���
        //string nearObjName = "";    //�I�u�W�F�N�g����
        GameObject targetObj = null; //�I�u�W�F�N�g

        //�^�O�w�肳�ꂽ�I�u�W�F�N�g��z��Ŏ擾����
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //���g�Ǝ擾�����I�u�W�F�N�g�̋������擾
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //�I�u�W�F�N�g�̋������߂����A����0�ł���΃I�u�W�F�N�g�����擾
            //�ꎞ�ϐ��ɋ������i�[
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //�ł��߂������I�u�W�F�N�g��Ԃ�
        //return GameObject.Find(nearObjName);
        return targetObj;
    }
}