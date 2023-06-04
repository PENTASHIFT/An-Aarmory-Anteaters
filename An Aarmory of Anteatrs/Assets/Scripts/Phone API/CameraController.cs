using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

#if UNITY_ANDROID
using UnityEngine.Android;

using ZXing;
#endif

public class CameraController : MonoBehaviour
{
    private bool camAvailable;
    private bool camRunning;
    private WebCamTexture backCam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

    string QrCode = string.Empty;

    void Start()
    {

        // defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;
        
        if (0 == devices.Length)
        {
            Debug.Log("No camera detected.");
            camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                Debug.Log(devices[i].name);
                break;
            }
        }

        if (null == backCam)
        {
            Debug.Log("Unable to find back camera.");
            return;
        }

        // backCam.Play();
        // background.texture = backCam;

        camAvailable = true;
    }

    void Update()
    {
        // if (!camAvailable)
        //     return;

        // float ratio = (float)backCam.width / (float)backCam.height;
        // fit.aspectRatio = ratio;

        // float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        // background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        // int orient = -backCam.videoRotationAngle;
        // background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }

    public void StartStopCamera()
    {
        Debug.LogFormat("background: {0} {1}",
        background.rectTransform.rect.height, background.enabled);

        if (!camAvailable)
        {
            Debug.Log("No camera available.");
            background.enabled = true;
            return;
        }

        if (camRunning)
        {
            // Stop Camera.
            Debug.Log("foo");
            backCam.Stop();
            background.enabled = false;
            camRunning = false;
        }
        else
        {
            background.enabled = true;
            backCam.Play();
            background.texture = backCam;
            camRunning = true;

            StartCoroutine(GetQRCode());
        }
    }

    IEnumerator GetQRCode()
    {
        Debug.Log("Bar!");
        IBarcodeReader barCodeReader = new BarcodeReader();
        var snap = new Texture2D(backCam.width, backCam.height, TextureFormat.ARGB32, false);

        while (string.IsNullOrEmpty(QrCode))
        {
            try
            {
                snap.SetPixels32(backCam.GetPixels32());
                var Result = barCodeReader.Decode(snap.GetRawTextureData(), backCam.width, backCam.height, RGBLuminanceSource.BitmapFormat.ARGB32);

                if (Result != null)
                {
                    QrCode = Result.Text;
                    if (!string.IsNullOrEmpty(QrCode))
                    {
                        Debug.Log("DECODED TEXT FROM QR: " + QrCode);
                        break;
                    }
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }

            yield return null;
        }

        QrCode = string.Empty;
    }
}
