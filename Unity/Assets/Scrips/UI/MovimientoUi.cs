using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MovimientoUi : MonoBehaviour
{
    public Transform logo;
    public RectTransform game;
    public RectTransform options;
    public RectTransform info;
    public RectTransform pressStart;
    // Start is called before the first frame update
    void Start()
    {        

    }

    // Update is called once per frame
    public void PressStart()
    {
        logo.DOMoveY(800, 1.0f, true).SetEase(Ease.Linear);
        logo.DOScale(new Vector3(1, 1, 1), 1.0f).SetEase(Ease.Linear);
        game.DOScale(new Vector3(1,1,1), 1.0f).SetEase(Ease.Linear);
        options.DOScale(new Vector3(1,1,1), 1.0f).SetEase(Ease.Linear);
        info.DOScale(new Vector3(1,1,1), 1.0f).SetEase(Ease.Linear);
        pressStart.DOScale(new Vector3(0,0,0), 0.1f).SetEase(Ease.Linear);
    }
}
