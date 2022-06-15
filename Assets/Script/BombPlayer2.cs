using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombPlayer2 : MonoBehaviour
{
    [SerializeField][Tooltip("�������Ԃ�0�b�ɖ߂��p�̂��")] private float _targetTime = default;
    [SerializeField][Tooltip("�������鎞��")] private float _currentTime = default;
    [SerializeField][Tooltip("���e��HP")] int _bombHp = default;
    [SerializeField][Tooltip("isTrigger�̃`�F�b�N�����ĂȂ���[��")] private CircleCollider2D _circleCollider = default;
    [Tooltip("isTrigger�̃`�F�b�N�����Ă��[��")] public Collider2D _collide = default;
    [Tooltip("�����̃G�t�F�N�g�������Ă����I")] public GameObject explosionPrefab;
    [Tooltip("�Ⴄ���C���[�œ����蔻��Ƃ��I")] public LayerMask levelMask;
    [Tooltip("����̓I�[�f�B�I�\�[�X")] private AudioSource booooooo;
    [Tooltip("���e�̃A�j���[�V�����������Ă����I")] public AudioClip audioClip;
    Player2Controll playerscript; //�ĂԃX�N���v�g�ɂ����Ȃ���


    [Tooltip("����̓{������v���C���[�܂Ő���ɓ��������߂ɂ�����")]private bool _bombed;
    public void Start()
    {
        booooooo = gameObject.GetComponent<AudioSource>();

        GameObject obj = GameObject.Find("Player2"); //Player���Ă����I�u�W�F�N�g��T��
        playerscript = obj.GetComponent<Player2Controll>();�@//�t���Ă���X�N���v�g���擾

        _collide = GetComponent<Collider2D>();
        _collide.enabled = true;
    }
    void Update()
    {
        _currentTime += Time.deltaTime;
        if (!_bombed && _targetTime < _currentTime)
        {
            _bombed = true;
            Destroy(this.gameObject, 0.3f);
            //���e�̈ʒu�ɔ����G�t�F�N�g���쐬
            GameObject newExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            newExplosion.name = explosionPrefab.name;
            StartCoroutine(CreateExplosions(Vector3.up)); // ��ɍL����
            StartCoroutine(CreateExplosions(Vector3.right)); // �E�ɍL����
            StartCoroutine(CreateExplosions(Vector3.down)); // ���ɍL����
            StartCoroutine(CreateExplosions(Vector3.left)); // ���ɍL����
            BombCheck();
            booooooo.PlayOneShot(audioClip);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BombBlast bomb))
        {
            _bombHp -= bomb._bombDamage;
            if (_bombHp <= 0)
            {
                _currentTime = _targetTime;
            }
        }
    }
    void BombCheck()
    {
        Player2Controll playerscript; //�ĂԃX�N���v�g�ɂ����Ȃ���
        GameObject obj = GameObject.Find("Player2"); //Player���Ă����I�u�W�F�N�g��T��
        playerscript = obj.GetComponent<Player2Controll>();�@//�t���Ă���X�N���v�g���擾
        playerscript._countBomb += 1;
    }
    private IEnumerator CreateExplosions(Vector3 direction)
    {
       
        // 2 �}�X�����[�v����
        for (int i = 1; i < playerscript._bombRange; i++)
        {
            // �u���b�N�Ƃ̓����蔻��̌��ʂ��i�[����ϐ�
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0) + direction * (i - 1), direction, 1, levelMask);
            Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0) + direction * i, direction);



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