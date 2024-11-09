using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Transform targetPosition; // ָ��Ŀ��λ��
    public float rotationAngle = 45f; // ��ת 45 ��
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    public void OnButtonClick()
    {
        StartCoroutine(MoveCameraAndLoadScene());
    }

    IEnumerator MoveCameraAndLoadScene()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = cameraTransform.position;
        Quaternion startRotation = cameraTransform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, rotationAngle);

        while (elapsedTime < 1f) // �ƶ�ʱ��Ϊ1��
        {
            cameraTransform.position = Vector3.Lerp(startPosition, targetPosition.position, elapsedTime / 1f);
            cameraTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ȷ������λ�ú���ת׼ȷ����Ŀ��
        cameraTransform.position = targetPosition.position;
        cameraTransform.rotation = targetRotation;

        // ������һ������
        SceneManager.LoadScene("dating"); 
    }
}