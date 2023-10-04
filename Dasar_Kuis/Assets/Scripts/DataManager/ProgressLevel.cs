using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

[System.Serializable]
public class ProgressLevel
{
    public int koin;
    public List<DataProgress> _PlayerProgressLevel;
    [Serializable]
    public class DataProgress
    {
        public string _NamaLevelPack = "";
        public bool[] _LevelPackProgress = new bool[5];
        public DataProgress(string name)
        {
            _NamaLevelPack = name;
        }
    }
    public ProgressLevel()
    {
        koin = 50;
        _PlayerProgressLevel = new List<DataProgress>();
    }

    public static explicit operator ProgressLevel(UnityEngine.Object v)
    {
        throw new NotImplementedException();
    }
}
