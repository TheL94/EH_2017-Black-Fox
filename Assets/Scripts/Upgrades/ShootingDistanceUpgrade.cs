﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackFox
{
    public class ShootingDistanceUpgrade : IUpgrade
    {
        public ShootingDistanceUpgrade(float[] _upgradeValues)
        {
            Values = _upgradeValues;
        }

        private int _currentUpgradeLevel;

        public int CurrentUpgradeLevel
        {
            get { return _currentUpgradeLevel; }
            set
            {
                if (value >= MinLevel && value <= MaxLevel)
                    _currentUpgradeLevel = value;
            }
        }

        public int MaxLevel { get { return Values.Length - 1; } }
        public int MinLevel { get; set; }

        UpgardeTypes IUpgrade.ID
        {
            get
            {
                return UpgardeTypes.BulletsRange;
            }
        }

        public float[] Values { get; set; }

        public float CalculateValue(float _value)
        {
            return _value + Values[CurrentUpgradeLevel];
        }
    }
}
