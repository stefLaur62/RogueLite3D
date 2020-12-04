﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemBuff
{
    public Attributes attributes;
    public int value;
    public int min;
    public int max;
    public ItemBuff(int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateValues();
    }
    public void GenerateValues()
    {
        value = Random.Range(min, max);
    }
}
