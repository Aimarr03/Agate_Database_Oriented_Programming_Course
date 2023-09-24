using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Windows;
using System.IO.Enumeration;

public class Latihan : MonoBehaviour
{
    string fileName, directory, path;
    void Awake()
    {
        fileName = "latihan01.txt";
        directory = Application.dataPath + "/Temporary/";
        path = directory + fileName;
    }

    // Update is called once per frame
    void Start()
    {
        TestSave();   
    }
    void TestSave()
    {
        if (!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(directory);
            Debug.Log($"Directory {directory} created!");
        }
        if(!System.IO.File.Exists(path))
        {
            System.IO.File.Create(path).Dispose();
            Debug.Log($"File {fileName} created!");
        }
        var FileStream = System.IO.File.Open(path, FileMode.Open);
        var binaryWrite = new BinaryWriter(FileStream);

        var a = "testing angka";
        var b = 124531;
        var c = 3.2314;
        var d = true;
        binaryWrite.Write(a);
        binaryWrite.Write(b);
        binaryWrite.Write(c);
        binaryWrite.Write(d);

        binaryWrite.Dispose();

        var binaryReader = new BinaryReader(System.IO.File.Open(path, FileMode.Open));
        a = binaryReader.ReadString();
        b = (int)binaryReader.ReadInt32();
        c = (float)binaryReader.ReadDouble();
        d = (bool)binaryReader.ReadBoolean();

        binaryReader.Dispose();
    }
}
