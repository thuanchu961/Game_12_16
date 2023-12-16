using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Car : MonoBehaviour
{
    //public float speed;
    //public abstract void Move();
    //public abstract void ChangeLane();
    //public abstract void TriggerObject();
    //public abstract void Accelerate();

    protected float moveTime;
    protected Vector3 startPosition;
    protected Vector3 targetPosition;

    public abstract void Move(float moveTime, Vector3 startPst, Vector3 targetPst);
    public abstract void SetState(string typeCar, int animNumber, GameObject gameObject);
}
