using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
	public bool showController = false; // bool to show if the controller prefab should be active or not
	public InputDeviceCharacteristics controllerCharacteristics; // reference to InputDeviceCharacteristics script
	public List<GameObject> controllerPrefabs; // list of controller prefabs
	public GameObject handModelPrefab; // reference to our hand model prefab

	private InputDevice targetDevice; // reference to our input device
	private GameObject spawnedController; // reference to our controller prefab
	private GameObject spawnedHandModel; // reference to our hand model prefab
	private Animator handAnimator; // reference to our hand animator

	// Start is called before the first frame update
	void Start()
	{
		TryInitialize(); // call the TryInitialize function
	}

	/// <summary>
	/// Function to try and load the initial hand or controller prefabs
	/// based on the controller type you are using or hand tracking
	/// </summary>
	void TryInitialize()
	{
		List<InputDevice> devices = new List<InputDevice>(); // populate the list of available device types

		InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices); // find the input device being used and assign to references

		foreach (var item in devices) 
		{
			Debug.Log(item.name + item.characteristics); // for each iten log in console the item name and charactistics
		}

		if (devices.Count > 0) // if the list count is greater than zero
		{
			targetDevice = devices[0]; // take the first device from the list
			GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name); // match and assign the same prefab to the controller being used
			if (prefab)
			{
				spawnedController = Instantiate(prefab, transform); // spawn the prefab of the controller
			}
			else // otherwise
			{
				Debug.LogError("Error"); // debug error log saying Error
				spawnedController = Instantiate(controllerPrefabs[0], transform); // assign the default controller prefab and spawn it
			}

			spawnedHandModel = Instantiate(handModelPrefab, transform);
			handAnimator = spawnedHandModel.GetComponent<Animator>(); // get the Animator component from the hand prefab we spawned
		}
	}
	/// <summary>
	/// function controlleing the hand animations
	/// </summary>
	void UpdateHandAnimation()
	{
		if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) // if the trigger is used
		{
			handAnimator.SetFloat("Trigger", triggerValue); // 
		}
		else // otherwise
		{
			handAnimator.SetFloat("Trigger", 0);
		}
		if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue)) // if the grip button is used
		{
			handAnimator.SetFloat("Grip", gripValue);
		}
		else // otherwise
		{
			handAnimator.SetFloat("Grip", 0);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (!targetDevice.isValid) // if targetDevice.isValid is not equal to true
		{
			TryInitialize(); // call the TryInitialize function
		}
		else // Otherwise
		{
			if (showController) // if showController is true
			{
				spawnedHandModel.SetActive(false); // set the hand model prefab to inactive
				spawnedController.SetActive(true); // set the controller prefab to active
			}
			else
			{
				spawnedHandModel.SetActive(true); // set the hand model prefab to active
				spawnedController.SetActive(false); // set the controller prefab to inactive
				UpdateHandAnimation(); // call the UpdateHandAnimation function
			}
		}

		//if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
		//Debug.Log("Pressing Primary Button");

		//if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggervalue) && triggervalue > 0.1f)
		//Debug.Log("Trigger Pressed" + triggervalue);

		//if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
		//Debug.Log("Primary Analogue" + primary2DAxisValue);
	}
}

        


       