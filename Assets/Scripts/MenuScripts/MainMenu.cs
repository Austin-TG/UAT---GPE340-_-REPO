using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    // Toggle Main Menu Button Variable(s)
    [SerializeField] private GameObject _mainmenuOptions;
    [SerializeField] private GameObject _mainmenu;

    // Lose/Win screen Vars
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;

    // Volume Vars
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;

    // Display Vars
    [SerializeField] private Toggle _isFullscreen;
    [SerializeField] private Dropdown _resolution;

    private void Awake()
    {
        BuildResolutionList();
    }
    private void Start()
    {
        SettingsLoad();
    }
    public void onGameStart()
    {
        BuildResolutionList();
        SettingsLoad();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SettingsLoad();
        if(GameManager.isPaused == true)
        {
            GameManager.isPaused = false;
        }
    }
    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
    public void MainMenuBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);

        GameManager.preventRentry = false;
        GameManager.isDead = false;
        GameManager.isPaused = false;
        GameManager.loseGame = false;
        GameManager.winGame = false;
        _loseScreen.SetActive(false);
        _winScreen.SetActive(false);
    }
    public void InGameOptionsEnable()
    {
        _mainmenuOptions.SetActive(true);
        _mainmenu.SetActive(false);
    }
    public void InGameOptionsDisable()
    {
        _mainmenuOptions.SetActive(false);
        _mainmenu.SetActive(true);
    }
    public void MainMenuOptionsEnable()
    {
        _mainmenu.SetActive(false);
        _mainmenuOptions.SetActive(true);
    }
    public void MainMenuOptionsDisable()
    {
        _mainmenu.SetActive(true);
        _mainmenuOptions.SetActive(false);
    }
    // SAVE SETTINGS/OPTIONS (VOLUME, FULLSCREEN)
    public void SettingsSave()
    {
        // VOLUME SAVE
        PlayerPrefs.SetFloat("Master Volume", _masterSlider.value);
        PlayerPrefs.SetFloat("Sound Volume", _soundSlider.value);
        PlayerPrefs.SetFloat("Music Volume", _musicSlider.value);

        // FULLSCREEN SAVE
        if (_isFullscreen.isOn == true)
        {
            PlayerPrefs.SetInt("Fullscreen Toggle", 1);
            Screen.fullScreen = true;
        }
        else
        {
            PlayerPrefs.SetInt("Fullscreen Toggle", 0);
            Screen.fullScreen = false;
        }

        // RESOLUTION SAVE
        PlayerPrefs.SetInt("Resolution", _resolution.value);


    }
    public void SettingsLoad()
    {
        // VOLUME LOAD
        _masterSlider.value =  PlayerPrefs.GetFloat("Master Volume");
        _soundSlider.value = PlayerPrefs.GetFloat("Sound Volume");
        _musicSlider.value = PlayerPrefs.GetFloat("Music Volume");

        // FULLSCREEN LOAD
        if (PlayerPrefs.GetInt("Fullscreen Toggle") == 1)
        {
            _isFullscreen.isOn = true;
            Screen.fullScreen = true;
        }
        else
        {
            _isFullscreen.isOn = false; 
            Screen.fullScreen = false;
        }

        // RESOLUTION LOAD
        _resolution.value = PlayerPrefs.GetInt("Resolution");
    }
    // RESOLUTIONS/QUALITY SETTINGS
    private void BuildResolutionList()
    {
        _resolution.ClearOptions();
        List<string> newResolutions = new List<string>();
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            newResolutions.Add(string.Format ("{0} X {1}", Screen.resolutions[i].width, Screen.resolutions[i].height));
        }

        _resolution.AddOptions(newResolutions);
    }
    public void SetResolution()
    {
        if(_resolution.options[_resolution.value].text == "1920 X 1080")
        {
            Screen.SetResolution(1920, 1080, _isFullscreen);
        }
        if (_resolution.options[_resolution.value].text == "1680 X 1050")
        {
            Screen.SetResolution(1680, 1050, _isFullscreen);
        }
        if (_resolution.options[_resolution.value].text == "1600 X 900")
        {
            Screen.SetResolution(1600, 900, _isFullscreen);
        }
        if (_resolution.options[_resolution.value].text == "1440 X 900")
        {
            Screen.SetResolution(1440, 900, _isFullscreen);
        }
        if (_resolution.options[_resolution.value].text == "1366 X 768")
        {
            Screen.SetResolution(1366, 768, _isFullscreen);
        }
        if (_resolution.options[_resolution.value].text == "1280 X 1024")
        {
            Screen.SetResolution(1280, 1024, _isFullscreen);
        }
        if (_resolution.options[_resolution.value].text == "1280 X 800")
        {
            Screen.SetResolution(1280, 800, _isFullscreen);
        }
        if (_resolution.options[_resolution.value].text == "1280 X 720")
        {
            Screen.SetResolution(1280, 720, _isFullscreen);
        }
        if (_resolution.options[_resolution.value].text == "1024 X 768")
        {
            Screen.SetResolution(1024, 768, _isFullscreen);
        }
        if (_resolution.options[_resolution.value].text == "800 X 600")
        {
            Screen.SetResolution(800, 600, _isFullscreen);
        }
        if (_resolution.options[_resolution.value].text == "720 X 576")
        {
            Screen.SetResolution(720, 576, _isFullscreen);
        }
        if (_resolution.options[_resolution.value].text == "720 X 480")
        {
            Screen.SetResolution(720, 480, _isFullscreen);
        }
        if (_resolution.options[_resolution.value].text == "720 X 400")
        {
            Screen.SetResolution(720, 400, _isFullscreen);
        }
        if (_resolution.options[_resolution.value].text == "640 X 480")
        {
            Screen.SetResolution(640, 480, _isFullscreen);
        }
    }
}
