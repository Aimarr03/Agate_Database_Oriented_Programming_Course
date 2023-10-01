using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Initial Gameplay", menuName = "Quiz Game/New Inital Gameplay Data")]
public class InitialGameplayData : ScriptableObject
{
    public LevelPack levelPack;
    public int IndexLevel;
}
