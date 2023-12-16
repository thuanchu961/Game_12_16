using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SpotLightController : MonoBehaviour, IImageUI
{
    [SerializeField] private Image spotLight;

    private float flashSpeed = 2f;
    private Color flashColor = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    private Color originalColor;
    private bool isFlashing;
 
    private void Start()
    {
        originalColor = spotLight.material.color;
        Blink();
    }
    private void Update()
    {
        //if (isFlashing)
        //{
        //    float lerp = Mathf.PingPong(Time.time * flashSpeed, 1.0f);
        //    spotLight.material.color = Color.Lerp(originalColor, flashColor, lerp);  
        //}
        
    }
    public void EnableImage()
    {
        spotLight.enabled = true;
        isFlashing = true;
    }
    public void DisableImage()
    {
        spotLight.enabled = false;
        isFlashing = false;
    }
    private void Blink()
    {
        // Thời gian mỗi lần nhấp nháy
        float blinkDuration = 0.5f;
        // Thực hiện hiệu ứng nhấp nháy với độ trễ
        spotLight.DOFade(0.5f, blinkDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
