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
    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private Text brightnessText;
    //CONTRAST
    [Space(20)]
    [SerializeField] private Slider contrastSlider;
    [SerializeField] private Text contrastText;
    //SATURITY
    [Space(20)]
    [SerializeField] private Slider saturationSlider;
    [SerializeField] private Text saturationText;
    //VOLUME
    [Space(20)]
    [SerializeField] private Text volumeText;
    [SerializeField] private Slider volumeSlider;
    //SENSITIVITY
    [Space(20)]
    [SerializeField] private Text controllerText;
    [SerializeField] private Slider controllerSlider;
    //INVERT Y
    [Space(20)]
    [SerializeField] private Toggle invertYToggle;
    [Space(20)]
    // [SerializeField] private bool canUse = false;
    [SerializeField] private MainMenu mainMenu;
    #endregion
    private void Awake()
    {
      Debug.Log("Load Player pref!");

      if (colorAdjustEffect != null)
      {
        if (PlayerPrefs.HasKey("Brightness"))
        {
          float prefBrightness = PlayerPrefs.GetFloat("Brightness");

          brightnessSlider.value = prefBrightness;
          brightnessText.text = prefBrightness.ToString("n1"); 
          colorAdjustEffect.brightness = prefBrightness;
        }
        else
          mainMenu.ResetBrightness();
        if (PlayerPrefs.HasKey("Contrast"))
        {
          float prefContrast = PlayerPrefs.GetFloat("Contrast");
          
          contrastSlider.value = prefContrast;
          contrastText.text = prefContrast.ToString("n1");
          colorAdjustEffect.contrast = prefContrast;
        }
        else
          mainMenu.ResetContrast();
        if (PlayerPrefs.HasKey("Saturation"))
        {
          float prefSaturation = PlayerPrefs.GetFloat("Saturation");

          saturationSlider.value = prefSaturation;
          saturationText.text = prefSaturation.ToString("n1");
          colorAdjustEffect.saturation = prefSaturation;
        }
        else
          mainMenu.ResetSaturation();
      }
      if (PlayerPrefs.HasKey("Volume"))
      {
        float prefVolume = PlayerPrefs.GetFloat("Volume");

        volumeSlider.value = prefVolume;
        volumeText.text = prefVolume.ToString("n1");
      }
      else
        mainMenu.resetSound();
      if (PlayerPrefs.HasKey("SensibilityController"))
      {
        float prefSensiController = PlayerPrefs.GetFloat("SensibilityController");
        controllerSlider.value = prefSensiController;
        controllerText.text = prefSensiController.ToString("#");
      }
      else
        mainMenu.ResetSensi();
      if (PlayerPrefs.HasKey("InvertY"))
      {
        if (PlayerPrefs.GetInt("InvertY") == 1)
        {
          invertYToggle.isOn = true;
        }
        else
          invertYToggle.isOn= false;
      }
      else
        invertYToggle.isOn = false;
    }
  }

  
}