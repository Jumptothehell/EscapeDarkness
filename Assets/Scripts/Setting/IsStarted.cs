using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IsStarted : MonoBehaviour
{
    [SerializeField] GameObject statusPlayer;
    [SerializeField] TMP_Text Quest;
    [SerializeField] GameObject Ads;
    [SerializeField] GameObject Player, Spawn, ButtonMovement;

    private bool isStared;

    private void Start()
    {
        GetComponent<CameraControl>();

        Ads.GetComponent<BannerAdsScript>().enabled = false;
        Spawn.GetComponent<SpawnEnemy>().enabled = false;
        Player.GetComponent<PlayerMoveScripts>().enabled = false;

        ButtonMovement.SetActive(false);
        statusPlayer.SetActive(false);
        Quest.gameObject.SetActive(true);
    }
    private void Update()
    {
        isStared = CameraControl.isGameStarted;

        if (isStared)
        {
            TextDelayOut();
            Player.GetComponent<PlayerMoveScripts>().enabled = true;
            Spawn.GetComponent<SpawnEnemy>().enabled = true;
            Ads.GetComponent<BannerAdsScript>().enabled = true;

            ButtonMovement.SetActive(true);
            statusPlayer.SetActive(true);
            Quest.gameObject.SetActive(false);
        }
    }
    IEnumerator TextDelayOut ()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
