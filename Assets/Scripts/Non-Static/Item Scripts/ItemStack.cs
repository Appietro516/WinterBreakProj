﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemStack {

	public Item item;
	public int amount;

	public ItemStack(Item item, int amt){
		this.item = item;
		this.amount = amt;
	}
}
