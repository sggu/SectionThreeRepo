using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This script controls how the menu and its buttons behave
/// </summary>
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
        //check to see if volume is already saved
        if (!PlayerPrefs.HasKey("VolumeSlider"))
        { 
            PlayerPrefs.SetFloat("VolumeSlider", 1f); //if it’s not, then save one
        }
        float prefVolume = PlayerPrefs.GetFloat("VolumeSlider"); //save the volume as a reference
        volumeSlider.value = prefVolume;
        //check to see if sfx is already saved
        if (!PlayerPrefs.HasKey("sfxSlider"))
        { 
            PlayerPrefs.SetFloat("sfxSlider", 1f); //if it’s not, then save one
        }
        float prefSFX = PlayerPrefs.GetFloat("sfxSlider"); //save the sfx as a reference
        sfxSlider.value = prefSFX;

        //set the highscore as 0 at the beginning
        for (int i = 0; i < 10; i++)
        {
            if (!PlayerPrefs.HasKey("Highscore" + i))
            {
                PlayerPrefs.SetInt("Highscore" + i, 0);
            }
        }
        for (int i = 0; i < 10; i++)
        {
            highscoreList[i].text = "" + PlayerPrefs.GetInt("Highscore" + i);
        }
    }

    //control button functions
    public void playGame()
    {
        //any changes to the sound will be saved
        PlayerPrefs.SetFloat("VolumeSlider", volumeSlider.value);
        PlayerPrefs.SetFloat("sfxSlider", sfxSlider.value);
        SceneManager.LoadScene("Game");
    }
    public void quitGame()
    {
        //any changes to the sound will be saved
        PlayerPrefs.SetFloat("VolumeSlider", volumeSlider.value);
        PlayerPrefs.SetFloat("sfxSlider", sfxSlider.value);
        Application.Quit();
    }
    //this function brings up and closes the sound setting
    public void openSettings()
    {
        if (setting == 0)
        {
            foreach (GameObject setting in settings)
            {
                Vector3 pos = setting.transform.position;
                float bound = pos.x - 1245;
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
            //any changes to the sound will be saved
            PlayerPrefs.SetFloat("VolumeSlider", volumeSlider.value);
            PlayerPrefs.SetFloat("sfxSlider", sfxSlider.value);
            foreach (GameObject setting in settings)
            {                
                Vector3 pos = setting.transform.position;
                float bound = pos.x + 1245;
                while (pos.x < bound)
                {
                    pos.x += 1 * Time.deltaTime;
                    setting.transform.position = pos;
                }
            }
            setting = 0;
        }
    }
    //opens and closes highscore list
    public void openHighScore()
    {
        if (hscore == 0)
        {
            foreach (Text highscore in highscoreList)
            {
                Vector3 pos = highscore.transform.position;
                float bound = pos.x + 1220;
                while (pos.x < bound)
                {
                    pos.x += 1 * Time.deltaTime;
                    highscore.transform.position = pos;
                }
            }
            Vector3 pos2 = blackBG.transform.position;
            float bound2 = pos2.x + 1220;
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
                float bound = pos.x - 1220;
                while (pos.x > bound)
                {
                    pos.x -= 1 * Time.deltaTime;
                    highscore.transform.position = pos;
                }
            }
            Vector3 pos2 = blackBG.transform.position;
            float bound2 = pos2.x - 1220;
            while (pos2.x > bound2)
            {
                pos2.x -= 1 * Time.deltaTime;
                blackBG.transform.position = pos2;
            }
            hscore = 0;
        }
    }
    //buttons that mute volume and sfx
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