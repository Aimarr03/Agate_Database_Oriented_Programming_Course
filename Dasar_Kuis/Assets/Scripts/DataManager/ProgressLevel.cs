using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class ProgressLevel
{
    public int koin;
    public Dictionary<string, int> levelPackProgress;
    public ProgressLevel()
    {
        koin = 50;
        levelPackProgress = new Dictionary<string, int>();
    }
}
