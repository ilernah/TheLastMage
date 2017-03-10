﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject {   
   

	// Use this for initialization
	protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        int inputX = (int)Input.GetAxisRaw("Horizontal");
        int inputY = (int)Input.GetAxisRaw("Vertical");

        Move(inputX, inputY);
    }
    
}
