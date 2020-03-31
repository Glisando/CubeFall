using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        ConfigurationUtils.Initialize();   
    }
}
