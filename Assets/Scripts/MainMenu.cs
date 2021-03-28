using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System;


namespace MainMenu
{


  public class MainMenu : MonoBehaviour
  {
    public enum Menu
    {
				MainMenu = 0,
        NewGame = 1,
        ContinueGame = 2,
        Settings = 3,
        Credits = 4,
        Exit = 5,
        SettingsGraphic = 6,
        SettingsSound = 7,
        SettingsGameplay = 8,
        SettingsGameplayController = 9,
				LevelSelector = 10
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

    [SerializeField] private bool testMode = false;
    [SerializeField] private GameObject continueButton;
		[SerializeField]private GameObject myEventSystem;
		public PlayerControls controls;
    #endregion
    private Menu menuSelectedNumber;
    


		void Awake()
		{
			controls = new PlayerControls();
			controls.Player.Escape.performed += context => HandleEscapeButton();
		}
    void Start()
    {

			myEventSystem = GameObject.Find("EventSystem");
      menuSelectedNumber = Menu.MainMenu;
			if (Player.HasSavegame)
			{
				continueButton.GetComponent<Button>().interactable = true;
			}
    }
		void Update()
		{
			// print(menuSelectedNumber);
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
        menuSelectedNumber = Menu.NewGame;
        mainMenuCanvas.SetActive(false);

        confirmationMenu.SetActive(true);
        newGameDialog.SetActive(true);
				myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(newGameDialog.transform.Find("Button").gameObject.transform.GetChild(0).gameObject);
      }
      else if (SelectedButton == "ContinueGame")
      {
        menuSelectedNumber = Menu.ContinueGame;
        mainMenuCanvas.SetActive(false);
        ContinueGame();
      }
      else if (SelectedButton == "Settings")
      {
        menuSelectedNumber = Menu.Settings;
        mainMenuCanvas.SetActive(false);
        menuSettings.SetActive(true);
				myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(menuSettings.transform.GetChild(0).gameObject);



      }
      else if (SelectedButton == "Credits")
      {
        menuSelectedNumber = Menu.Credits;
        mainMenuCanvas.SetActive(false);
        creditsMenu.SetActive(true);
				myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(creditsMenu.transform.GetChild(3).gameObject);



      }
      else if (SelectedButton == "Exit")
      {
        Debug.Log("EXIT!");
        Application.Quit();

      }
      else if (SelectedButton == "SettingsGraphic")
      {
        menuSelectedNumber = Menu.SettingsGraphic;
        menuSettings.SetActive(false);
        graphicsMenu.SetActive(true);
				myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(graphicsMenu.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject);


      }
      else if (SelectedButton == "SettingsSound")
      {
        menuSelectedNumber = Menu.SettingsSound;
        menuSettings.SetActive(false);
        soundMenu.SetActive(true);
				myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(soundMenu.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject);


      }
      else if (SelectedButton == "SettingsGameplay")
      {
        menuSelectedNumber = Menu.SettingsGameplay;
        menuSettings.SetActive(false);
        gameplayMenu.SetActive(true);
				myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(gameplayMenu.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject);


      }
      else if (SelectedButton == "SettingsGameplayController")
      {
        menuSelectedNumber = Menu.SettingsGameplayController;
        gameplayMenu.SetActive(false);
        controlsMenu.SetActive(true);
				myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(controlsMenu.transform.GetChild(2).gameObject);

      }

    }

    public void BackToSettingsMenu(string current)
    {
      if (current == "SettingsGraphic")
        graphicsMenu.SetActive(false);
      else if (current == "SettingsSound")
      {
        soundMenu.SetActive(false);
      }
      else if (current == "SettingsGameplay")
        gameplayMenu.SetActive(false);
			else
				return;
      menuSettings.SetActive(true);
			myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(menuSettings.transform.GetChild(0).gameObject);
			menuSelectedNumber = Menu.Settings;

    }

    public void BackToMainMenu(string current)
    {
      if (current == "Credits")
        creditsMenu.SetActive(false);
      else if (current == "Settings")
        menuSettings.SetActive(false);
      else if (current == "NewGame")
      {
        confirmationMenu.SetActive(false);
        newGameDialog.SetActive(false);
      }
      else if (current == "LevelSelector")
      {
        levelSelection.SetActive(false);
      }
			else
				return;
      mainMenuCanvas.SetActive(true);
			myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(mainMenuCanvas.transform.GetChild(0).gameObject);
			menuSelectedNumber = Menu.MainMenu;

    }
    
    public void BackToGameplaySettings()
    {
      gameplayMenu.SetActive(true);
      controlsMenu.SetActive(false);
			myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(gameplayMenu.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject);
			menuSelectedNumber = Menu.SettingsGameplay;
    }
		private void HandleEscapeButton()
		{
			

			foreach (string str in Enum.GetNames(typeof(Menu)))
			{
				if (menuSelectedNumber.ToString() == str)
				{
					Debug.Log("str: " + str);
					Debug.Log("selected: "  + menuSelectedNumber.ToString());
					BackToMainMenu(str);
					BackToSettingsMenu(str);
					if(str == "SettingsGameplayController")
					{
						Debug.Log("ENTER SET GAME");
						BackToGameplaySettings();
					}
					if (str == "MainMenu")
					{
						Debug.Log("Exit");
						Application.Quit();
					}
					return;
				}
			}

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
      Debug.Log("Gameplay Apply ! ");
      //add confirmation box 
      if (invertYToggle.isOn)
      {
				Debug.Log("InvertY On");
        PlayerPrefs.SetInt("InvertY", 1);
      }
      else {
				Debug.Log("InvertY Off");

        PlayerPrefs.SetInt("InvertY", 0);
      }
			Player.ChangeInvertY(invertYToggle.isOn);
      PlayerPrefs.SetFloat("SensibilityController", controllerSensitivitySlider.value);
			Player.ChangeControllerSensibility(controllerSensitivitySlider.value);
      BackToSettingsMenu("SettingsGameplay");
    }
    public void GraphicApply()
    {
      PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
      PlayerPrefs.SetFloat("Contrast", contrastSlider.value);
      PlayerPrefs.SetFloat("Saturation", saturationSlider.value);
			Player.ChangeColorAdjustEffect(brightnessSlider.value,contrastSlider.value,saturationSlider.value);
      BackToSettingsMenu("SettingsGraphic");
    }

		public void SoundApply()
    {
      Debug.Log("Volume Apply !");
      //add confirmation box 

      PlayerPrefs.SetFloat("Volume", volumeSlider.value);
      BackToSettingsMenu("SettingsSound");
    }
    public void OpenGithub()
    {
      Application.OpenURL("https://github.com/ziakor");
    }

    public void OpenLinkedin()
    {
      Application.OpenURL("https://www.linkedin.com/in/dihauet/");
    }
    
		public void HandleChangeTestMode()
		{
			testMode = !testMode;
		}
    public void StartNewGame()
    {
			Debug.Log("test mode " + testMode);
      Player.TestModePlayer(testMode);
			Debug.Log("PlayerTestMode : " + Player.testmode);
			Player.ChangeLevel(1);
			Player.ChangeCurrentLevel(1);
			Player.SavePlayer();
			for (int i = 1; i < 4; i++)
			{
					Player.ChangeBestTime(i, 0f);
			}
      confirmationMenu.SetActive(false);
      newGameDialog.SetActive(false);
      levelSelection.SetActive(true);
			myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(levelSelection.transform.GetChild(2).gameObject);
			menuSelectedNumber = Menu.LevelSelector;
		}
		public void ContinueGame()
		{
			confirmationMenu.SetActive(false);
      newGameDialog.SetActive(false);
      levelSelection.SetActive(true);
			myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(levelSelection.transform.GetChild(2).gameObject);
			menuSelectedNumber = Menu.LevelSelector;
		}
		void OnEnable()
		{
			controls.Enable();
		}

		void OnDisable()
		{
			controls.Disable();
		}
  }

}

