using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBuildingIsDumb : MonoBehaviour
{
    void Awake()
    {
#if UNITY_STANDALONE_WIN
        Screen.SetResolution(450, 900, false);
#endif
    }
}
