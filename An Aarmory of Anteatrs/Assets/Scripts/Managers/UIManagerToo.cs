using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManagerToo : MonoBehaviour
{
    public float fadeTime = 1f;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;
    public CanvasGroup displayCanvasGroup;
    public RectTransform displayRectTransform;

    public void PanelFadeIn(){

        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition =new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);


        displayCanvasGroup.alpha = 1f;
        displayRectTransform.transform.localPosition =new Vector3(0f, 0f, 0f);
        displayRectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        displayCanvasGroup.DOFade(0, fadeTime);
    }

    public void PanelFadeOut(){
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition =new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, fadeTime);


        displayCanvasGroup.alpha = 0f;
        displayRectTransform.transform.localPosition =new Vector3(0f, -1000f, 0f);
        displayRectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        displayCanvasGroup.DOFade(1, fadeTime);
    }
}
