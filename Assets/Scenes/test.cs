using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject prefab;
    public float moveDuration = 3f;

    public void Start()
    {
        StartCoroutine(GenerateObjectsCoroutine());
    }

    private IEnumerator GenerateObjectsCoroutine()
    {
        for (int i = 0; i < 5; i++)
        {
            // 生成预制体
            GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);

            // 使用 DOTween 的 DOMove 动画移动预制体
            obj.transform.DOMove(new Vector3(2, 0, 0), moveDuration);

            // 等待移动动画完成
            yield return obj.transform.DOMove(new Vector3(2, 0, 0), moveDuration).WaitForCompletion();
        }
    }
}
