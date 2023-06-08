using UnityEngine;
using UnityEngine.InputSystem;

#if UNITY_ANDROID
using UnityEngine.Android;
#elif UNITY_IOS
using UnityEngine.iOS;
#endif

using TMPro;

public class StepController : MonoBehaviour
{
    bool SC;
    TMP_Text text;
    // int rv, ruv, rvo, rdv, rvfpf;

    void Start()
    {
        if (null != StepCounter.current)
        {
            InputSystem.EnableDevice(StepCounter.current);
            // InputSystem.AddDevice<StepCounter>();    // This breaks it on Android???
            Debug.Log("StepCounter initialized!");
            SC = true;

            // rv = 0;
            // ruv = 0;
            // rvo = 0;
            // rdv = 0;
            // rvfpf = 0;

#if UNITY_ANDROID
            Debug.Log("Android!");

            // If permission was not granted via Android Manifest, request permission manually.
            if (!Permission.HasUserAuthorizedPermission("android.permission.ACTIVITY_RECOGNITION"))
            {
                Permission.RequestUserPermission("android.permission.ACTIVITY_RECOGNITION");
            }
#endif

        }
        else
        {
            Debug.Log("StepCounter was not able to be retrieved.");
            SC = false;
        }

        text = gameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (SC)
        {
            // rv = StepCounter.current.stepCounter.ReadValue();
            // ruv = StepCounter.current.stepCounter.ReadUnprocessedValue();
            // rvo += StepCounter.current.stepCounter.ReadValueAsObject();
            // rdv = StepCounter.current.stepCounter.ReadDefaultValue();
            // rvfpf = StepCounter.current.stepCounter.ReadValueFromPreviousFrame();

            text.text = $"Steps: { StepCounter.current.stepCounter.ReadValue() }";
        }
        else
        {
            text.text = "Steps: Null";
        }

// #if UNITY_ANDROID
//         if (!Permission.HasUserAuthorizedPermission("android.permission.ACTIVITY_RECOGNITION"))
//         {
//             // If permission was revoked or some other weirdness, fallback to "Step Counter: Null".
//             SC = false;
//         }
//         else if (!SC)
//         {
//             // If it wasn't working prior but now has permission, start working.
//             SC = true;
//         }
// #endif

    }
}
