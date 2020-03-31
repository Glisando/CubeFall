using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigurationUtils
{
    private static ConfigurationData _configurationData;

    public static float PlayerSpeed { get => _configurationData.PlayerSpeed; }
    public static float PlatformSpeed { get => _configurationData.PlatformSpeed; }

    public static void Initialize()
    {
        _configurationData = new ConfigurationData();
    }
}
