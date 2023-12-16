using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : BaseButton
{
    [SerializeField] private Vector3 offset;
    protected override void OnClick()
    {
        MainCarController.Instance.ChangeLane(offset);
        MapManager.Instance.ChooseLane(offset.y);
    }
}
