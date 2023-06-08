using UnityEngine;

// NOTE(josh): Turned off "Adaptive Performance" in Edit->Project Settings.

public class GameManager : MonoBehaviour
{
    private uint currency;

    public static GameManager Instance;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {

    }

    public uint GetCurrency()
    {
        return currency;
    }
}
