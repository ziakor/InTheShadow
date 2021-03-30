 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MainMenu
{
  public class LoadPreferences : MonoBehaviour
  {
    #region Variables
    //BRIGHTNESS
    [SerializeField] private ColorAdjustEffect colorAdjustEffect;
    [Space(20)]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private Text brightnessText = null;
    //CONTRAST
    [Space(20)]
    [SerializeField] private Slider contrastSlider = null;
    [SerializeField] private Text contrastText = null;
    //SATURITY
    [Space(20)]
    [SerializeField] private Slider saturationSlider = null;
    [SerializeField] private Text saturationText = null;
    //VOLUME
    [Space(20)]
    [SerializeField] private Text volumeText = null;
    [SerializeField] private Slider volumeSlider = null;
    //SENSITIVITY
    [Space(20)]
    [SerializeField] private Text controllerText = null;
    [SerializeField] private Slider controllerSlider = null;
    //INVERT Y
    [Space(20)]
    [SerializeField] private Toggle invertYToggle = null;
    [Space(20)]
    // [SerializeField] private bool canUse = false;
    [SerializeField] private MainMenu mainMenu = null;
    #endregion
    private void Awake()
    {

      if (colorAdjustEffect != null)
      {
        if (PlayerPrefs.HasKey("Brightness"))
        {
          float prefBrightness = PlayerPrefs.GetFloat("Brightness");

					if (brightnessSlider)
						brightnessSlider.value = prefBrightness;
          if (brightnessText)
						brightnessText.text = prefBrightness.ToString("n1"); 
          colorAdjustEffect.brightness = prefBrightness;
					Player.brightness = prefBrightness;
        }
        else
          mainMenu.ResetBrightness();
        if (PlayerPrefs.HasKey("Contrast"))
        {
          float prefContrast = PlayerPrefs.GetFloat("Contrast");
          if(contrastSlider)
						contrastSlider.value = prefContrast;
          if (contrastText)
						contrastText.text = prefContrast.ToString("n1");
          colorAdjustEffect.contrast = prefContrast;
					Player.contrast = prefContrast;
        }
        else
          mainMenu.ResetContrast();
        if (PlayerPrefs.HasKey("Saturation"))
        {
          float prefSaturation = PlayerPrefs.GetFloat("Saturation");
					if (saturationSlider)
						saturationSlider.value = prefSaturation;
          if (saturationText)
						saturationText.text = prefSaturation.ToString("n1");
          colorAdjustEffect.saturation = prefSaturation;
					Player.saturation = prefSaturation;
        }
        else
				{
					if (mainMenu)
						mainMenu.ResetSaturation();
				}
      }
      if (PlayerPrefs.HasKey("Volume"))
      {
        float prefVolume = PlayerPrefs.GetFloat("Volume");
				if (volumeSlider)
					volumeSlider.value = prefVolume;
				if (volumeText)
					volumeText.text = prefVolume.ToString("n1");
      }
      else
			{
				if (mainMenu)
					mainMenu.resetSound();
			}
      if (PlayerPrefs.HasKey("SensibilityController"))
      {
        float prefSensiController = PlayerPrefs.GetFloat("SensibilityController");
				if(controllerSlider)
					controllerSlider.value = prefSensiController;
				if (contrastText)
					controllerText.text = prefSensiController.ToString("#");
				Player.sensibilityMouse = prefSensiController;
      }
      else
			{
				if (mainMenu)
					mainMenu.ResetSensi();
			}
      if (PlayerPrefs.HasKey("InvertY"))
      {
        if (PlayerPrefs.GetInt("InvertY") == 1)
        {
					if(invertYToggle)
						invertYToggle.isOn = true;
					Player.invertY = true;
        }
        else
				{
					if(invertYToggle)
						invertYToggle.isOn= false;
					Player.invertY = false;
					
				}
      }
      else
			{
				if (invertYToggle)
					invertYToggle.isOn = false;
					Player.invertY = false;
			}
    }
  }

  
}