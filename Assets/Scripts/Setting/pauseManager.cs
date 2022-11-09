using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class pauseManager : MonoBehaviour
{
    [SerializeField] AudioMixerSnapshot paused;
    [SerializeField] AudioMixerSnapshot Unpaused;
    [SerializeField] Button PlayButton, PauseButton;

    private PlayerControls playerControl;

    private bool GameisPaused;
    //private bool m_Released;
    private void Awake()
    {
        playerControl = new PlayerControls();
    }
    private void OnEnable()
    {
        playerControl.Enable();
    }
    private void OnDisable()
    {
        playerControl.Disable();
    }
    private void Start()
    {
        GameisPaused = false;
        PlayButton = GetComponent<Button>();
        PauseButton = GetComponent<Button>();
    }
    private void Update()
    {
        if (GameisPaused)
        {
            paused.TransitionTo(0.05f);
        }
        else 
        {
            Unpaused.TransitionTo(0.05f);
        }
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    canvas.enabled = !canvas.enabled;
        //    Time.timeScale = Time.timeScale == 0 ? 1 : 0;

        //    if (Time.timeScale == 0)
        //    {
        //        paused.TransitionTo(0.05f);
        //    }
        //    else
        //    {
        //        Unpaused.TransitionTo(0.05f);
        //    }
        //}
    }
    public void PauseGame()
    {
        GameisPaused = true;
        Time.timeScale = 0;
    }
    public void EnterGame()
    {
        GameisPaused = false;
        Time.timeScale = 1;
    }
}
