using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UniqueId))]

public class ShopKeeper : MonoBehaviour {
    [SerializeField] private ShopItemList L_shopItemsHeld;
    private ShopSystem shopSystem;

    public UnityAction<IInteractable> OnInteractionComplete { get; set; }

    public bool Interact(Interactor interactor, out bool interactSuccessful) {
        throw new System.NotImplementedException();
    }

    public void EndInteraction() {
        throw new System.NotImplementedException();
    }
}
