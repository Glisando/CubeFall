using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class ConfigurationData
{
    const string ConfigurationDataFileName = "ConfigurationData.csv";

    Dictionary<string, float> _keyValues;

    static float platformSpeed = 1f;
    static float playerSpeed = 5f;

    public float PlayerSpeed { get => playerSpeed; }
    public float PlatformSpeed { get => platformSpeed; }

    public ConfigurationData()
    {
        StreamReader input = null;

        try
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            string names = input.ReadLine();
            string values = input.ReadLine();

            SetData(names, values);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    private void SetData(string names, string values)
    {
        _keyValues = new Dictionary<string, float>();

        string[] splittedNames = names.Split(',');
        string[] splittedValues = values.Split(',');

        if (splittedNames.Length != splittedValues.Length)
        {
            throw new Exception("Some keys or values are missing");
        }

        for (int i = 0, size = splittedValues.Length; i < size ; i++)
        {
            _keyValues.Add(splittedNames[i], float.Parse(splittedValues[i]));
        }

        playerSpeed = _keyValues["playerSpeed"];
        platformSpeed = _keyValues["platformSpeed"];
    }
}
