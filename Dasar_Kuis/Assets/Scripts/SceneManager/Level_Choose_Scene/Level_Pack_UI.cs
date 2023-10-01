using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Level_Pack_UI : MonoBehaviour
{
    private LevelPack _levelPack;
    [SerializeField] private TextMeshProUGUI _ButtonText;
    public void _SetLevelPack(LevelPack currentLevelPack)
    {
        _levelPack = currentLevelPack;
        _ButtonText.text = _levelPack.ToString();
    }
    public LevelPack GetLevelPack()
    {
        return _levelPack;
    }
}
