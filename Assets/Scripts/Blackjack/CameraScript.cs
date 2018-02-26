﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraScript : MonoBehaviour
{


	public Camera cameraComponent;
	public Text fpsCounter;
	// Use this for initialization
	void Start()
	{
		cameraComponent = GetComponent<Camera>();


		// Set the desired aspect ratio (the values in this example are hard-coded for 16:9, but you could make them into public
		// variables instead so you can set them at design time)
		float fTargetAspect = 800.0f / 450.0f;

		// determine the game window's current aspect ratio

		float fWindowAspect = (float)Screen.width / (float)Screen.height;

		// current viewport height should be scaled by this amount
		float fScaleHeight = fWindowAspect / fTargetAspect;

		// if scaled height is less than current height, add letterbox
		if (fScaleHeight < 1.0f)
		{
			Rect rect = cameraComponent.rect;

			rect.width = 1.0f;
			rect.height = fScaleHeight;
			rect.x = 0;
			rect.y = (1.0f - fScaleHeight) / 2.0f;
			cameraComponent.rect = rect;

		}
		else // add pillarbox
		{
			float fScaleWidth = 1.0f / fScaleHeight;

			Rect rect = cameraComponent.rect;

			rect.width = fScaleWidth;
			rect.height = 1.0f;
			rect.x = (1.0f - fScaleWidth) / 2.0f;
			rect.y = 0;
			cameraComponent.rect = rect;
		}
	}

	void LateUpdate()
	{
		fpsCounter.text = "fps : " + Mathf.FloorToInt(1f / Time.unscaledDeltaTime);
		GL.Clear(true, true, Color.black);
	}
}
