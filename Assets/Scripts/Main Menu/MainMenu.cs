using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public Slider volumeSlider;
    [SerializeField] public float volumeValue;
    [SerializeField] public Image imageMute;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volumeAudio", 0.5f);
        AudioListener.volume = volumeSlider.value;
        CheckMute();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    public void ChangeSlider(float value)
    {
        volumeValue = value;
        PlayerPrefs.SetFloat("volumeAudio", volumeValue);
        AudioListener.volume = volumeSlider.value;
        CheckMute();
    }
    public void CheckMute()
    {
        if(volumeValue == 0)
        {
            imageMute.enabled = true;
        }
        else
        {
            imageMute.enabled = false;
        }
    }
    public void QuitGame()
    {
        GameManager.gameManager.Quit();
    }
}
