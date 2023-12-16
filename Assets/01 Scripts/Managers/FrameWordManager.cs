using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameWordManager : Singleton<FrameWordManager>, IObserver
{
    Subject subject;
    IMoveToTarget moveToTarget;
    IFadeIn fadeInController;
    private void Awake()
    {
        subject = FindObjectOfType<MainCarController>();
        subject.AddObserver(this);
    }
    private void Start()
    {
        moveToTarget = GetComponent<IMoveToTarget>();
        fadeInController = GetComponent<IFadeIn>();
    }
    public void OnNotify(float value)
    {
        moveToTarget.MoveToTarget(0.5f, this.transform.position, new Vector3(0, -5, 0));
    }
    public void FadeInFrameWord()
    {
        moveToTarget.MoveToTarget(0.5f, this.transform.position, new Vector3(0, 0, 0));
        this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        fadeInController.FadeIn();
    }
    private void OnDestroy()
    {
        subject.RemoveObserver(this);
    }
}
