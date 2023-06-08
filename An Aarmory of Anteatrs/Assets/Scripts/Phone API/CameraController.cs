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

    string QrCode = string.Empty;

    void Start()
    {

        // defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;
        Debug.LogFormat("background: {0}", background.enabled);
        
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

        camAvailable = true;
    }

    public void StartCamera()
    {
        Debug.LogFormat("background: {0} {1}",
        background.rectTransform.rect.height, background.enabled);

        if (!camAvailable)
        {
            Debug.Log("No camera available.");
            // background.enabled = true;
            return;
        }
        
        StartCoroutine(GetQRCode());
        background.enabled = true;
    }

    IEnumerator GetQRCode()
    {
        backCam.Play();
        background.enabled = true;
        background.texture = backCam;

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

            yield return new WaitForSeconds(1);
            // yield return null;
        }

        backCam.Stop();
        background.enabled = false;

        QrCode = string.Empty;
    }
}
