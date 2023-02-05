using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameUIController", menuName = "Controllers/GameUIController")]
public class GameUIController : ScriptableObject
{
    public Action<UIType> SwitchUIType;
}
