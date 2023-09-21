using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BlackScreenLoader : MonoBehaviour
{
    static BlackScreenLoader instance;

    [SerializeField] Image image;

    [SerializeField] LoadingCircle LoaderIcon;

    [SerializeField] float fadeTime = 0.3f;

    private void Awake()
    {
        instance = this;
        LoaderIcon.gameObject.SetActive(false);
        image.color =new Color32(0,0,0,0);
        image.gameObject.SetActive(false);
    }

    public static void FadeToBlack(Action OnFinishTrans)
    {
        instance.image.gameObject.SetActive(true);
        instance.image.DOFade(1f, instance.fadeTime).SetUpdate(true).OnComplete(() => { instance.LoaderIcon.gameObject.SetActive(true); OnFinishTrans.Invoke(); });
    }

    public static void FadeToInvisible(Action onFinishTransition)
    {
        instance.LoaderIcon.gameObject.SetActive(false);
        instance.image.DOFade(0f, instance.fadeTime).SetUpdate(true).OnComplete(() => { instance.image.gameObject.SetActive(false); onFinishTransition.Invoke(); });
    }
}
