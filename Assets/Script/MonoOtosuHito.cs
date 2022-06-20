using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoOtosuHito : MonoBehaviour
{
    //[SerializeField] private GameObject[] pointPrefab;
    [SerializeField][Tooltip("�����Ԋu")] private float _targetTime = default;
    [SerializeField][Tooltip("�����Ԋu������}��")] private float _currentTime = default;
    [SerializeField][Tooltip("���C�Ԋu")] private float _targetTime1 = default;
    [SerializeField][Tooltip("���C�Ԋu������}��")] private float _currentTime1 = default;
    //  [SerializeField][Tooltip("_isAdd������������false�ɂ���Ђ�")] private float _targetTime2 = default;
    [SerializeField][Tooltip("_isAdd�����炷�l")] private float _currentTime2 = default;
    [SerializeField][Tooltip("�Ⴄ���C���[�œ����蔻��Ƃ��I")] private LayerMask levelMask;
    public int _lostItem = 3;

    [SerializeField] List<GameObject> myList;
    [SerializeField] List<GameObject> itemList;
    public List<GameObject> useList = new List<GameObject>();
    private GameObject randomObj;
    private int choiceNum;
    bool _isAdd = false;

    [SerializeField][Tooltip("�ړ����x")] float _speed = -2.0f;
    //  [Tooltip("��̃A�j���[�^�[�̒u����")] private Animator anim;
    [Tooltip("�E�̒[�̏ꏊ")] private Transform _Xposition;

    void Start()
    {
        _Xposition = GetComponent<Transform>();
    }
    private void Update()
    {
        _currentTime += Time.deltaTime;
        _currentTime1 += Time.deltaTime;
        _currentTime2 += Time.deltaTime;
        if (_targetTime < _currentTime && _isAdd != true)
        {
            for (int i = 0; i < _lostItem; i++)
            {
                //myList�̒����烉���_����1��I��
                randomObj = myList[Random.Range(0, myList.Count)];
                ////�I�񂾃I�u�W�F�N�g��useList�ɒǉ�
                //useList.Add(randomObj);
                randomObj.layer = LayerMask.NameToLayer("Mejirushi");
                ////�I�񂾃I�u�W�F�N�g�̃��X�g�ԍ����擾
                //choiceNum = myList.IndexOf(randomObj);
                ////�������X�g�ԍ���myList����폜
                //myList.RemoveAt(choiceNum);
            }
            _isAdd = true;
            _lostItem = 3;

            ////myList�̒����烉���_����1��I��
            //randomObj = useList[Random.Range(0, useList.Count)];
            ////�I�񂾃I�u�W�F�N�g��useList�ɒǉ�
            //myList.Add(randomObj);
            ////�I�񂾃I�u�W�F�N�g�̃��X�g�ԍ����擾
            //choiceNum = useList.IndexOf(randomObj);
            ////�������X�g�ԍ���myList����폜
            //useList.RemoveAt(choiceNum);

            transform.position = new Vector2(21, _Xposition.position.y);
            _currentTime = 0;
        }

        if (_isAdd == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(_speed, 0);
            if (_targetTime1 < _currentTime1)
            {
                StartCoroutine(CreateItem(Vector3.up)); // �E�ɍL����
                StartCoroutine(CreateItem(Vector3.down)); // ���ɍL����
                _currentTime1 = 0;
            }

        }
        if (_targetTime < _currentTime2)
        {
            _isAdd = false;
            _currentTime2 = 0;
        }
        IEnumerator CreateItem(Vector3 direction)
        {
            // 2 �}�X�����[�v����
            for (int i = 1; i < 10; i++)
            {
                // �u���b�N�Ƃ̓����蔻��̌��ʂ��i�[����ϐ�
                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0) + direction * (i - 1), direction, 1, levelMask);
                Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0) + direction * i, direction);

                int _random = Random.Range(0, itemList.Count);
                // �������L������ɉ������݂��Ȃ��ꍇ
                if (!hit.collider)
                {


                }
                // �������L������Ƀu���b�N�����݂���ꍇ
                else
                {
                    hit.collider.gameObject.layer = LayerMask.NameToLayer("Mejirushi");    //�����������������������������|�C���g�̃��C���[������Ȃ��I�̕���
                    Instantiate
                    (
                        itemList[Random.Range(0, _random)],
                        transform.position + (i * direction),
                        itemList[0].transform.rotation
                    );
                }

                // 0.05 �b�҂��Ă���A���̃}�X�ɔ������L����
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
