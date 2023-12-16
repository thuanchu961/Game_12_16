using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimationHandler
{
    public void SetAnim(string name, GameObject gameObject, bool loop);
    public void SetState(string typeCar, int animNumber, GameObject gameObject);
}
