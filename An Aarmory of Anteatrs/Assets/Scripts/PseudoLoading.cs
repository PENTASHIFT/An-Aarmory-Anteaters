using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PseudoLoading : MonoBehaviour
{
    public float timeElapse;

    void Start()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(timeElapse);

        SceneManager.LoadScene("Home");
    }
}
