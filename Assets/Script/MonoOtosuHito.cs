using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoOtosuHito : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPrefab; 
    [SerializeField] private GameObject[] pointPrefab;

    private void Start()
    {
        
    }
    private IEnumerator CreateExplosions(Vector3 direction)
    {
        // 2 �}�X�����[�v����
        for (int i = 1; i < 6; i++)
        {
            // �u���b�N�Ƃ̓����蔻��̌��ʂ��i�[����ϐ�
          //  RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0) + direction * (i - 1), direction, 1, levelMask);
            Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0) + direction * i, direction);



            // �������L������ɉ������݂��Ȃ��ꍇ
          //  if (!hit.collider)
            {
                // �������L���邽�߂ɁA
                // �����G�t�F�N�g�̃I�u�W�F�N�g���쐬
          //      Instantiate
          //      (
             //       explosionPrefab,
              //      transform.position + (i * direction),
             //       explosionPrefab.transform.rotation
          //      );
            }
            // 0.05 �b�҂��Ă���A���̃}�X�ɔ������L����
            yield return new WaitForSeconds(0.05f);
        }
    }
}
