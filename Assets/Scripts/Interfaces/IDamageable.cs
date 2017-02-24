﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interfaccia per tutti coloro che possono subire dei danni.
/// </summary>
public interface IDamageable {

    void Damage(float _damage, GameObject _attacker);
}
