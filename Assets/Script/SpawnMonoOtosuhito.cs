//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SpawnMonoOtosuhito : MonoBehaviour
//{
//    [SerializeField][Tooltip("0�b�ɖ߂��p�̂��")] private float _targetTime = default;
//    [SerializeField][Tooltip("�������鎞��")] private float _currentTime = default;
//    [Tooltip("�����̃G�t�F�N�g�������Ă����I")] public GameObject explosionPrefab;
//    private void Update()
//    {
//        _currentTime += Time.deltaTime;
//        if (_targetTime < _currentTime)
//        {
//            GameObject newExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

//            _currentTime = 0;
//        }
//    }
//}
