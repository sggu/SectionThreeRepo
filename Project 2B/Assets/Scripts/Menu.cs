using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    [Header("Settings")]
    public Slider volumeSlider;
    public Slider sfxSlider;

    public List<GameObject> settings;
    private int setting = 0;
    public List<Text> highscoreList;
    private int hscore = 0;
    public GameObject blackBG;

    public void Start()
    {
        if (!PlayerPrefs.HasKey("VolumeSlider"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("VolumeSlider", 1f); // If it’s not, then save one
        }
        float prefVolume = PlayerPrefs.GetFloat("VolumeSlider"); // Save the high score as a reference
        volumeSlider.value = prefVolume;

        if (!PlayerPrefs.HasKey("sfxSlider"))
        { // Check to see if a high score is already saved
            PlayerPrefs.SetFloat("sfxSlider", 1f); // If it’s not, then save one
        }
        float prefSFX = PlayerPrefs.GetFloat("sfxSlider"); // Save the high score as a reference
        sfxSlider.value = prefSFX;

        for (int i = 0; i < 10; i++)
        {
            if (!PlayerPrefs.HasKey("Highscore" + i))
            {
                PlayerPrefs.SetInt("Highscore" + i, 0);
                //Debug.Log("Highscore" + i);
            }
        }
        for (int i = 0; i < 10; i++)
        {
            highscoreList[i].text = "" + PlayerPrefs.GetInt("Highscore" + i);
        }
    }

    public void playGame()
    {
        PlayerPrefs.SetFloat("VolumeSlider", volumeSlider.value);
        PlayerPrefs.SetFloat("sfxSlider", sfxSlider.value);
        SceneManager.LoadScene("Game");
    }
    public void quitGame()
    {
        PlayerPrefs.SetFloat("VolumeSlider", volumeSlider.value);
        PlayerPrefs.SetFloat("sfxSlider", sfxSlider.value);
        Application.Quit();
        //Debug.Log("exiting game");
    }
    public void openSettings()
    {
        if (setting == 0)
        {
            foreach (GameObject setting in settings)
            {
                Vector3 pos = setting.transform.position;
                float bound = pos.x - 245;
                while (pos.x > bound)
                {
                    pos.x -= 1 * Time.deltaTime;
                    setting.transform.position = pos;
                }
            }
            setting = 1;
        }
        else if (setting == 1)
        {
            PlayerPrefs.SetFloat("VolumeSlider", volumeSlider.value);
            PlayerPrefs.SetFloat("sfxSlider", sfxSlider.value);
            foreach (GameObject setting in settings)
            {                
                Vector3 pos = setting.transform.position;
                float bound = pos.x + 245;
                while (pos.x < bound)
                {
                    pos.x += 1 * Time.deltaTime;
                    setting.transform.position = pos;
                }
            }
            setting = 0;
        }
    }
    public void openHighScore()
    {
        if (hscore == 0)
        {
            foreach (Text highscore in highscoreList)
            {
                Vector3 pos = highscore.transform.position;
                float bound = pos.x + 220;
                while (pos.x < bound)
                {
                    pos.x += 1 * Time.deltaTime;
                    highscore.transform.position = pos;
                }
            }
            Vector3 pos2 = blackBG.transform.position;
            float bound2 = pos2.x + 220;
            while (pos2.x < bound2)
            {
                pos2.x += 1 * Time.deltaTime;
                blackBG.transform.position = pos2;
            }
            hscore = 1;
        }
        else if (hscore == 1)
        {
            foreach (Text highscore in highscoreList)
            {
                Vector3 pos = highscore.transform.position;
                float bound = pos.x - 220;
                while (pos.x > bound)
                {
                    pos.x -= 1 * Time.deltaTime;
                    highscore.transform.position = pos;
                }
            }
            Vector3 pos2 = blackBG.transform.position;
            float bound2 = pos2.x - 220;
            while (pos2.x > bound2)
            {
                pos2.x -= 1 * Time.deltaTime;
                blackBG.transform.position = pos2;
            }
            hscore = 0;
        }
    }
    public void volumeMute()
    {
        if (volumeSlider.value != 0f)
        {
            PlayerPrefs.SetFloat("VolumeSlider", volumeSlider.value);
            volumeSlider.value = 0f;
        }
        else volumeSlider.value = PlayerPrefs.GetFloat("VolumeSlider");
    }
    public void sfxMute()
    {
        if (sfxSlider.value != 0f)
        {
            PlayerPrefs.SetFloat("sfxSlider", sfxSlider.value);
            sfxSlider.value = 0f;
        }
        else sfxSlider.value = PlayerPrefs.GetFloat("sfxSlider");
    }
}