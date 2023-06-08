using System.Collections;
using UnityEngine;

#if UNITY_ANDROID
using UnityEngine.Android;
#elif UNITY_IOS
using UnityEngine.iOS;
#endif

using TMPro;

public class Location : MonoBehaviour
{
    TMP_Text locationText;

    void Start()
    {
        locationText = gameObject.GetComponent<TMP_Text>();
    }

    public void CallSetTracking()
    {
        IEnumerator cor = SetTracking();
        StartCoroutine(cor);
    }

    IEnumerator SetTracking()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
        {
            // Request Permission.
            Permission.RequestUserPermission(Permission.CoarseLocation);

            // If Permission still not granted, handle gracefully.
            if (!Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
            {
                Debug.Log("Permission not Granted!");
                yield break;
            }
        }
#elif UNITY_IOS
        if (!location.isEnabledByUser)
        {
            yield break;
        }
#else
        yield break;
#endif

        Input.location.Start(10.0f, 10.0f);

        uint maxWait = 20;

        while (LocationServiceStatus.Running != Input.location.status && 0 < maxWait)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (1 > maxWait)
        {
            Debug.Log("Timed Out!");
            yield break;
        }

        locationText.text = $"{ Input.location.lastData.latitude }, { Input.location.lastData.longitude }";

        Input.location.Stop();
    }
}
