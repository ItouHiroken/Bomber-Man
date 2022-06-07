using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _targetTime = default;
    [SerializeField] private float _currentTime = default;
    [SerializeField] float _bombHp = default;
    [SerializeField] private CircleCollider2D _circleCollider = default;
    [SerializeField] public float _bombRange = default;
    [SerializeField] public Collider2D _collide = default;

    [SerializeField] public GameObject explosionPrefab;
    [SerializeField] public LayerMask levelMask;

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
            Destroy(this.gameObject, 0.3f);
            //���e�̈ʒu�ɔ����G�t�F�N�g���쐬
            GameObject newExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            newExplosion.name = explosionPrefab.name;
            StartCoroutine(CreateExplosions(Vector3.up)); // ��ɍL����
            StartCoroutine(CreateExplosions(Vector3.right)); // �E�ɍL����
            StartCoroutine(CreateExplosions(Vector3.down)); // ���ɍL����
            StartCoroutine(CreateExplosions(Vector3.left)); // ���ɍL����
            //���e���\���ɂ���
            //GetComponent<MeshRenderer>().enabled = false;
            //transform.Find("Collider").gameObject.SetActive(false);
        }
        //GameObject obj = GameObject.Find("bomb_explosion_10");
        // �w�肵���I�u�W�F�N�g���폜
        //Destroy(obj, 0.3f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BombBlast bomb))
        {
            _bombHp -= bomb._bombDamage;
            if (_bombHp <= 0)
            {
                //Destroy(gameObject);
                //GameObject newExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                //newExplosion.name = explosionPrefab.name;
                //StartCoroutine(CreateExplosions(Vector3.up)); // ��ɍL����
                //StartCoroutine(CreateExplosions(Vector3.right)); // �E�ɍL����
                //StartCoroutine(CreateExplosions(Vector3.down)); // ���ɍL����
                //StartCoroutine(CreateExplosions(Vector3.left)); // ���ɍL����
                _currentTime = _targetTime;
            }
        }
    }

    // �������L����
    private IEnumerator CreateExplosions(Vector3 direction)
    {
        // 2 �}�X�����[�v����
        for (int i = 1; i < _bombRange; i++)
        {
            // �u���b�N�Ƃ̓����蔻��̌��ʂ��i�[����ϐ�
           RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0) + direction * (i-1), direction, 1, levelMask);
           Debug.DrawRay(transform.position+new Vector3(0,0.5f,0) + direction * i, direction);

           

            // �������L������ɉ������݂��Ȃ��ꍇ
            if (!hit.collider)
            {
                // �������L���邽�߂ɁA
                // �����G�t�F�N�g�̃I�u�W�F�N�g���쐬
                Instantiate
                (
                    explosionPrefab,
                    transform.position + (i * direction),
                    explosionPrefab.transform.rotation
                );
            }
            // �������L������Ƀu���b�N�����݂���ꍇ
            else
            {
                //���������܂��L�΂��ă_���[�W����̃G�t�F�N�g�ɂ���
                Instantiate
                (
                    explosionPrefab,
                    transform.position + (i * direction),
                    explosionPrefab.transform.rotation
                );
                // �����͂���ȏ�L���Ȃ�
                break;
            }

            // 0.05 �b�҂��Ă���A���̃}�X�ɔ������L����
            yield return new WaitForSeconds(0.05f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _collide.enabled = false;
            _circleCollider.enabled = true;
        }
    }
}
