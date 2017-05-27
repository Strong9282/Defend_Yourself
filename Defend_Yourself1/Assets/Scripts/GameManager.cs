using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject settingsMenuCanvas;
    public Slider[] volumeSliders;
    

	// Use this for initialization
	void Start ()
    {
        settingsMenuCanvas.SetActive(false);
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SettingsMenu()
    {
        settingsMenuCanvas.SetActive(true);
    }

    public void SettingsMenuAccept()
    {
        settingsMenuCanvas.SetActive(false);
    }

    public void SettingsMenuCancel()
    {
        settingsMenuCanvas.SetActive(false);
    }

    public void SetMasterVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }

    public void SetMusicVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }

    public void SetSFXVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.SFX);
    }


}
