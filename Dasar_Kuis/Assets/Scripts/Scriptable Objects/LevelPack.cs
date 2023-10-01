using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Pack 0", menuName ="Quiz Game/New Level Pack")]
public class LevelPack : ScriptableObject
{
    public string _LevelPackName;
    public QuestionData[] levelPack = new QuestionData[0];

    public QuestionData GetQuestion(int index)
    {
        return levelPack[index];
    }
    public override string ToString()
    {
        return _LevelPackName;
    }
}
