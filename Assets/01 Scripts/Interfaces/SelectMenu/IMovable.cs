using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable 
{
    void MoveToTarget(Vector3 targetPosition, float duration);
}
