﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalAgent : MonoBehaviour, IDamageable {

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    #region Interface

    public void Damage(float _damage)
    {
        throw new NotImplementedException();
    }

    #endregion
}