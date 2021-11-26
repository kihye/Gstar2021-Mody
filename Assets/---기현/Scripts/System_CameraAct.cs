using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_CameraAct : MonoBehaviour
{
    public static System_CameraAct instance;

    private float camShakeTime;
    private float camShakeIntensity;
    private Vector3 startPos;

    void Awake()
    {
        CamPosSet();
    }
    public System_CameraAct()
    {
        instance = this;
    }
    private void CamPosSet()
    {
        startPos = transform.position;
    }
    public void ShakeCam(bool isPlayerAttack, float shakeTime = 0.01f, float shakeIntencity = 0.08f)
    {
        camShakeTime = shakeTime;
        camShakeIntensity = shakeIntencity;

        if(isPlayerAttack)
        {
            StopCoroutine("ShakeByPosAttack");
            StartCoroutine("ShakeByPosAttack");
        }
        else
        {
            StopCoroutine("ShakeByPos");
            StartCoroutine("ShakeByPos");
        }
    }
    private IEnumerator ShakeByPos()
    {
        while (camShakeTime > 0.0f)
        {
            transform.position = startPos + Random.insideUnitSphere * camShakeIntensity;

            camShakeTime -= Time.deltaTime;

            yield return null;
        }
        transform.position = startPos;
    }
    private IEnumerator ShakeByPosAttack()
    {
        Vector3 pos = transform.position;
        while (camShakeTime > 0.0f)
        {
            transform.position = pos + Random.insideUnitSphere * camShakeIntensity;

            camShakeTime -= Time.deltaTime;

            yield return null;
        }
        transform.position = pos;
    }
}
