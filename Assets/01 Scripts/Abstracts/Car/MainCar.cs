using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCar : Car
{
    IMoveToTarget moveToTarget;
    ISetState setState;
    private void Awake()
    {
        moveToTarget = GetComponent<IMoveToTarget>();
        setState = GetComponent<ISetState>();
    }
    public override void Move(float moveTime, Vector3 startPst, Vector3 targetPst)
    {
        moveToTarget.MoveToTarget(moveTime, startPst, targetPst);
    }

    public override void SetState(string typeCar, int animNumber, GameObject gameObject)
    {
        setState.SetState(typeCar, animNumber, gameObject);
    }
}
