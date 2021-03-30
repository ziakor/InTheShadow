using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAdjustEffect : PostEffectBase {

 
	// Range controls the range of parameters that can be entered

	[Range(0.5f, 3.0f)]

	public float brightness = 1.0f; // Brightness

	[Range(0.5f, 1.5f)]

	public float contrast = 1.0f; // Contrast

	[Range(0.5f, 3.0f)]

	public float saturation = 1.0f; // Saturation

	// Overwrite OnRenderImage function

	void Start()
	{
		brightness = Player.brightness;
		contrast = Player.contrast;
		saturation = Player.saturation;
	}
	void OnRenderImage(RenderTexture src, RenderTexture dest)
	{

		// Post-process only when there is a material, if _Material is empty, no post-processing

		if (_Material)
		{

			// The parameter value in shader can be set through Material.SetXXX ("name", value)

			_Material.SetFloat("_Brightness", brightness);

			_Material.SetFloat("_Saturation", saturation);

			_Material.SetFloat("_Contrast", contrast);

			// Use Material to process Texture, dest is not necessarily the screen, post-processing effects can be superimposed!

			Graphics.Blit(src, dest, _Material);
		}

		else
		{
		// Draw directly
			Graphics.Blit(src, dest);
		}
	}
}