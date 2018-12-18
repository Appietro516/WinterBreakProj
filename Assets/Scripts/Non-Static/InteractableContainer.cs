using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractableContainer : ItemContainer, Interactable {

    public void Interact(playerModel model){
        foreach(Item item in this.inventory){
            model.inventory.Add(item);
        }
        Destroy(this.gameObject);

    }




}
