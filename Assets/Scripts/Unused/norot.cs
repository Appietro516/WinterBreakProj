﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class norot : MonoBehaviour {

	Quaternion fixedRotation;
	void Awake(){
		fixedRotation = transform.rotation;
	}

	void LateUpdate(){
		transform.rotation = fixedRotation;
	}
}
