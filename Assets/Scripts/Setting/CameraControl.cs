using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public GameObject playerVcam, finishVcam;
    public GameObject MainCamera;
    public static bool isGameStarted;

    private void Start()
    {
        isGameStarted = false;

        MainCamera.GetComponent<CinemachineBrain>();

        playerVcam.SetActive(true);
        finishVcam.SetActive(false);

        StartCoroutine(PlayertoFinishCam());
    }
    IEnumerator PlayertoFinishCam()
    {
        yield return new WaitForSeconds(3.0f);
        playerVcam.SetActive(false);
        finishVcam.SetActive(true);

        StartCoroutine(FinishCamtoPlayer());
    }

    IEnumerator FinishCamtoPlayer()
    {
        yield return new WaitForSeconds(3.0f);
        finishVcam.SetActive(false);
        playerVcam.SetActive(true);

        isGameStarted = true;
    }
}
