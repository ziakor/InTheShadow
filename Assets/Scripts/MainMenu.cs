using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace MainMenu
{


  public class MainMenu : MonoBehaviour
  {
    public enum Menu
    {
        IdNewGame = 1,
        IdContinueGame = 2,
        IdSettings = 3,
        IdCredits = 4,
        IdExit = 5,
        IdSettingsGraphic = 6,
        IdSettingsSound = 7,
        IdSettingsGameplay = 8,
        IdSettingsGameplayController = 9
    }
    #region Default Values
    [Header("Default Menu Values")]
    [SerializeField] private float defaultBrightness;
    [SerializeField] private float defaultConstrast;
    [SerializeField] private float defaultSaturation;
    [SerializeField] private float defaultVolume;
    [SerializeField] private int defaultSen;
    [SerializeField] private bool defaultInvertY;
    [Header("Levels To Load")]
    public string _newGameButtonLevel;
    private string levelToLoad;
    private int menuNumber;
    #endregion
    #region Menu Dialogs
    [Header("Main Menu Components")]
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject menuSettings;
    [SerializeField] private GameObject graphicsMenu;
    [SerializeField] private GameObject soundMenu;
    [SerializeField] private GameObject gameplayMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private GameObject confirmationMenu;
    [SerializeField] private GameObject levelSelection;

    

    [Space(10)]
    [Header("Menu Popout Dialogs")]
    [SerializeField] private GameObject noSaveDialog;
    [SerializeField] private GameObject newGameDialog;
    [SerializeField] private GameObject loadGameDialog;
    #endregion

    #region Slider Linking
    [Header("Menu Sliders")]
    [SerializeField] private Text controllerSensitivityText;
    [SerializeField] private Slider controllerSensitivitySlider;
    public float controlSenFloat = 2f;
    [Space(10)]
    // [SerializeField] private Brightness brightnessEffect;
    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private Text brightnessText;
    [SerializeField] private ColorAdjustEffect colorAdjustEffect;

    [Space(10)]
    [SerializeField] private Slider contrastSlider;
    [SerializeField] private Text contrastText;
    [Space(10)]
    [SerializeField] private Slider saturationSlider;
    [SerializeField] private Text saturationText;
    [Space(10)]
    [SerializeField] private Text volumeText;
    [SerializeField] private Slider volumeSlider;
    [Space(10)]
    [SerializeField] private Toggle invertYToggle;

    [SerializeField] private Toggle testMode;

    #endregion


    private Menu menuSelectedNumber;
    
    void Start()
    {
      menuSelectedNumber = Menu.IdNewGame;
    }


    private void ClickSound()
    {
      GetComponent<AudioSource>().Play();
    }

    public void MainMouseClick(string SelectedButton)
    {
      Debug.Log(SelectedButton);
      if (SelectedButton == "NewGame")
      {
        menuSelectedNumber = Menu.IdNewGame;
        mainMenuCanvas.SetActive(false);

        confirmationMenu.SetActive(true);
        newGameDialog.SetActive(true);
      }
      else if (SelectedButton == "ContinueGame")
      {
        menuSelectedNumber = Menu.IdContinueGame;
        mainMenuCanvas.SetActive(false);
        // add confirmation box with " Are you sure about that ?"
      }
      else if (SelectedButton == "Settings")
      {
        menuSelectedNumber = Menu.IdSettings;
        mainMenuCanvas.SetActive(false);
        menuSettings.SetActive(true);


      }
      else if (SelectedButton == "Credits")
      {
        menuSelectedNumber = Menu.IdCredits;
        mainMenuCanvas.SetActive(false);
        creditsMenu.SetActive(true);


      }
      else if (SelectedButton == "Exit")
      {
        Debug.Log("EXIT!");
        Application.Quit();

      }
      else if (SelectedButton == "SettingsGraphic")
      {
        menuSelectedNumber = Menu.IdSettingsGraphic;
        menuSettings.SetActive(false);
        graphicsMenu.SetActive(true);

      }
      else if (SelectedButton == "SettingsSound")
      {
        menuSelectedNumber = Menu.IdSettingsSound;
        menuSettings.SetActive(false);
        soundMenu.SetActive(true);

      }
      else if (SelectedButton == "SettingsGameplay")
      {
        menuSelectedNumber = Menu.IdSettingsGameplay;
        menuSettings.SetActive(false);
        gameplayMenu.SetActive(true);

      }
      else if (SelectedButton == "SettingsGameplayController")
      {
        menuSelectedNumber = Menu.IdSettingsGameplayController;
        gameplayMenu.SetActive(false);
        controlsMenu.SetActive(true);
      }
      Debug.Log((int)menuSelectedNumber);

    }

    public void BackToSettingsMenu(string current)
    {
      if (current == "Graphics")
        graphicsMenu.SetActive(false);
      else if (current == "Sound")
      {
        soundMenu.SetActive(false);
        //Get volume from player pref if exist or 0.5
      }
      else 
        gameplayMenu.SetActive(false);
      menuSettings.SetActive(true);
    }

    public void BackToMainMenu(string current)
    {
      if (current == "Credits")
        creditsMenu.SetActive(false);
      else if (current == "Settings")
        menuSettings.SetActive(false);
      else if (current == "NewGameModal")
      {
        confirmationMenu.SetActive(false);
        newGameDialog.SetActive(false);
      }
      else if (current == "LevelSelector")
      {
        levelSelection.SetActive(false);
      }
      mainMenuCanvas.SetActive(true);
    }
    
    public void BackToGameplaySettings()
    {
      gameplayMenu.SetActive(true);
      controlsMenu.SetActive(false);
    }
    public void VolumeSlider()
    {
      // AudioListener.volume = 0.0f;
      volumeText.text = volumeSlider.value.ToString("n1");
      AudioListener.volume = volumeSlider.value;
    }


    public void BrightnessSlider()
    {
      brightnessText.text = brightnessSlider.value.ToString("n1");
      colorAdjustEffect.brightness = brightnessSlider.value;
    }
    public void ContrastSlider()
    {
      contrastText.text = contrastSlider.value.ToString("n1");
      colorAdjustEffect.contrast = contrastSlider.value;
    }
    public void SaturationSlider()
    {
      saturationText.text = saturationSlider.value.ToString("n1");
      colorAdjustEffect.saturation = saturationSlider.value;
    }
    public void SoundApply()
    {
      Debug.Log("Volume Apply !");
      //add confirmation box 

      PlayerPrefs.SetFloat("Volume", volumeSlider.value);
      BackToSettingsMenu("Sound");
    }

    public void resetSound()
    {
      GetComponent<AudioSource>().volume = defaultVolume;
      volumeText.text = defaultVolume.ToString("n1");
      volumeSlider.value = defaultVolume;
      //reset player pref
      //Volume

    }

    public void ResetSensi()
    {
      controllerSensitivityText.text = defaultSen.ToString("#");
      controllerSensitivitySlider.value = defaultSen;
    }
    public void  ResetGameplay()
    {
      ResetSensi();
      invertYToggle.isOn = false;
    }

    public void ResetBrightness()
    {
      brightnessText.text = defaultBrightness.ToString("#");
      brightnessSlider.value = defaultBrightness;
    }
    
    public void ResetContrast()
    {
      contrastSlider.value = defaultConstrast;
      contrastText.text = defaultConstrast.ToString("#");
    }

    public void ResetSaturation()
    {
      saturationSlider.value = defaultSaturation;
      saturationText.text = defaultSaturation.ToString("#");
    }
    public void ResetGraphic()
    {
      ResetBrightness();
      ResetContrast();
      ResetSaturation();
    }

    public void SensitivitySlider()
    {
      
      Debug.Log("SALSIFI SLIDER " + controllerSensitivitySlider.value.ToString("#"));
      controllerSensitivityText.text = controllerSensitivitySlider.value.ToString("#");
    }

    public void GameplayApply()
    {
      Debug.Log("Gameplay Apply !");
      //add confirmation box 
      if (invertYToggle)
      {
        PlayerPrefs.SetInt("InvertY", 1);
      }
      else {
        PlayerPrefs.SetInt("InvertY", 0);
      }
      PlayerPrefs.SetFloat("SensibilityController", controllerSensitivitySlider.value);
      BackToSettingsMenu("Gameplay");
    }
    public void GraphicApply()
    {
      PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
      PlayerPrefs.SetFloat("Contrast", contrastSlider.value);
      PlayerPrefs.SetFloat("Saturation", saturationSlider.value);
      BackToSettingsMenu("Graphics");

    }
    public void OpenGithub()
    {
      Application.OpenURL("https://github.com/ziakor");
    }

    public void OpenLinkedin()
    {
      Application.OpenURL("https://www.linkedin.com/in/dihauet/");
    }
    
    public void StartNewGame()
    {
      if (testMode)
      {
        PlayerPrefs.SetInt("TestMode", 1);
      }
      else
        PlayerPrefs.SetInt("TestMode", 0);
      confirmationMenu.SetActive(false);
      newGameDialog.SetActive(false);
      levelSelection.SetActive(true);
      
      
    }
    void Update()
    {
    }
  }
}

