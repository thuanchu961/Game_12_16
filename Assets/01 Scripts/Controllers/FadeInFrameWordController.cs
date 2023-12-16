using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInFrameWordController : MonoBehaviour, IFadeIn
{
    public void FadeIn()
    {
        StartCoroutine(FadeInFrameWord());
    }
    private IEnumerator FadeInFrameWord()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < transform.childCount; i++)
        {
            SpriteRenderer sprite = transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>();
            Color coler = sprite.color;
            coler.b = 0;
            sprite.color = coler;
            if (i == 0) SoundController.Instant.PlaySound((int)Constant.SOUND.m);
            else if (i == 1) SoundController.Instant.PlaySound((int)Constant.SOUND.a);
            else if (i == 2) SoundController.Instant.PlaySound((int)Constant.SOUND.t);
            yield return new WaitForSeconds(1f);
        }
        SoundController.Instant.PlaySound((int)Constant.SOUND.mat);
    }
}
