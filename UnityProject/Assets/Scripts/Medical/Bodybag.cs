using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
/// <summary>
///     Generic grenade base.
/// </summary>
[RequireComponent(typeof(Pickupable))]
public class Bodybag : NBHandActivateInteractable
{
	public SpriteRenderer spriteRenderer;

	/// <summary>
	/// Sound played when you unzip the bodybag
	/// </summary>
	[SerializeField]
	private string soundToggle;

	/// <summary>
	/// Sprite to be shown when the bodybag unfolds
	/// </summary>
	[SerializeField]
	private Sprite spriteActive;

	/// <summary>
	/// Sprite to be shown when the bodybag folds
	/// </summary>
	[SerializeField]
	private Sprite spriteInactive;

	[SyncVar(hook = nameof(UpdateState))]
	private bool folded;

	public bool isFolded => folded;

	public void ToggleState()
	{
		UpdateState(!folded);
	}
	private void UnfoldBodybag(GameObject item, Vector3 dropPos, PlayerNetworkActions pna)
	{
		//var slot = GetSlotFromItem(item, pna);
		//item.BroadcastMessage("OnRemoveFromInventory", null, SendMessageOptions.DontRequireReceiver);
		//var objTransform = item.GetComponent<CustomNetTransform>();
		//if (dropPos != TransformState.HiddenPos)
		//{
		//	if (slot.Owner != null)
		//	{
		//		//Inertia drop works only if player has external impulse (space floating etc.)
		//		var playerScript = slot.Owner.GetComponent<PlayerScript>();
		//		objTransform.InertiaDrop(dropPos, playerScript.PlayerSync.SpeedServer, playerScript.PlayerSync.ServerImpulse);
		//	}
		//	else
		//	{
		//		objTransform.AppearAtPositionServer(dropPos);
		//	}
		//}
		//ObjectBehaviour itemObj = item.GetComponent<ObjectBehaviour>();
		//if (itemObj)
		//{
		//	itemObj.parentContainer = null;
		//}
		//item.GetComponent<RegisterTile>().UpdatePositionServer();
		//ClearInvSlot(slot);
	}

	private void UpdateState(bool newState)
	{
		folded = newState;

		//UpdateSprite();
	}

	//private void UpdateSprite()
	//{
	//	if (active)
	//	{
	//		spriteRenderer.sprite = spriteActive;
	//	}
	//	else
	//	{
	//		spriteRenderer.sprite = spriteInactive;
	//	}

	//	// UIManager doesn't update held item sprites automatically
	//	if (UIManager.Hands.CurrentSlot.Item == gameObject)
	//	{
	//		UIManager.Hands.CurrentSlot.UpdateImage(gameObject);
	//	}
	//}

	protected override void ClientPredictInteraction(HandActivate interaction)
	{
		ToggleState();
	}

	protected override void ServerPerformInteraction(HandActivate interaction)
	{
		SoundManager.PlayNetworkedAtPos(soundToggle, interaction.Performer.transform.position);
		ToggleState();
	}
}
