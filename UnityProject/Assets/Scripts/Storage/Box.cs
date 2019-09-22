using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Controls the boxes illustrations.
/// </summary>
[RequireComponent(typeof(InteractableStorage))]
public class Box : NBHandActivateInteractable
{

	/// <summary>
	/// Sprite to be shown in the label of the box.
	/// </summary>
	[SerializeField]
	private Sprite illustration;

	public void Start()
	{
		
	}

	protected override void ServerPerformInteraction(HandActivate interaction)
	{


	}

	protected override void ClientPredictInteraction(HandActivate interaction)
	{
		//ToggleState();
	}
}
