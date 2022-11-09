using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WannaEscape : MonoBehaviour
{
    [SerializeField] GameObject Player;

    [SerializeField] GameObject Exitway;
    [SerializeField] GameObject ExitWindow;

    [SerializeField] Button InteractionExit;
    [SerializeField] TMP_Text StatusCoin;

    private PlayerControls talk;
    private bool TalktoExit;
    private void Awake()
    {
        talk = new PlayerControls();
    }
    private void OnEnable()
    {
        talk.Enable();
    }
    private void OnDisable()
    {
        talk.Disable();
    }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        InteractionExit.gameObject.SetActive(false); 
        ExitWindow.SetActive(false);

        StatusCoin.enabled = false;
    }

    private void Update()
    {
        float TalkInput = talk.GameMenu.TalkEscape.ReadValue<float>();

        if (Player.transform.position.x >= Exitway.transform.position.x - 0.5 &&
            Player.transform.position.x >= Exitway.transform.position.x + 0.5)
        { InteractionExit.gameObject.SetActive(true); }
        else {
            InteractionExit.gameObject.SetActive(false);
        }
        if (InteractionExit.gameObject.activeInHierarchy)
        {
            if (TalkInput == 1 || TalktoExit)
            {
                ExitWindow.SetActive(true);
            }
        }
        if (ExitWindow.activeInHierarchy == true)
        {
            Time.timeScale = 0;
        }
        if (ExitWindow.activeInHierarchy == false)
        {
            Time.timeScale = 1;
        }
    }
    
    public void YestoEscape()
    {
        ExitWindow.SetActive(false);
        TalktoExit = false;
        if (PickStar.StarCoinCount >= 10)
        {  
            Player.GetComponent<PickStar>().DecreaseStarCoin(10);
            Application.Quit();
        }
        else {
            StatusCoin.enabled = true;
            StatusCoin.SetText("Your stars not enough");

            StartCoroutine(StatusCoinDelayOut());
            ExitWindow.SetActive(false);
        }
    }
    public void Talkative()
    {
        TalktoExit = true;
    }
    IEnumerator StatusCoinDelayOut()
    {
        yield return new WaitForSeconds(2f);
        StatusCoin.enabled = false;
    }
    public void NotoNotEscape()
    {
        TalktoExit = false;
        ExitWindow.SetActive(false);
    }
}
