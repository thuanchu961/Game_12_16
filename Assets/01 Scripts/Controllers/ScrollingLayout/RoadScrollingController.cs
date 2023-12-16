using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScrollingController : ScrollingLayoutAbstract, IObserver
{
    Subject subject;
    protected override void Awake()
    {
        base.Awake();
        subject = FindObjectOfType<MainCarController>();
        subject.AddObserver(this);
    }
    public void OnNotify(float value)
    {
        speed = value;
    }
}
