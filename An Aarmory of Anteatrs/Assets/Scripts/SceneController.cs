using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void inventory()
    {
        SceneManager.LoadScene("Inventory");
    }

    public void gacha()
    {
        SceneManager.LoadScene("Gacha");
    }

    public void home()
    {
        SceneManager.LoadScene("Home");
    }

    public void settings()
    {
        SceneManager.LoadScene("Settings");
    }
}
