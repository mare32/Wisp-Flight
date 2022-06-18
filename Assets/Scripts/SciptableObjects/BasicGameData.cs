using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicGameData", menuName = "BasicGameData")]
public class BasicGameData : ScriptableObject
{
    public Vector2 constantGravityModifier = new Vector2(0.0f, -1.0f);
}
