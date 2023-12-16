using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetController : MonoBehaviour, IMoveToTarget
{
    private float timeElapse;
    public virtual void MoveToTarget(float moveTime, Vector3 startPosition, Vector3 targetPosition)
    {
        StartCoroutine(MoveToPosition(moveTime, startPosition, targetPosition));
    }

    protected IEnumerator MoveToPosition(float moveTime, Vector3 startPosition, Vector3 targetPosition)
    {
        timeElapse = 0;
        while (timeElapse < moveTime)
        {
            timeElapse += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapse / moveTime);
            Vector3 newPosition = Vector3.Lerp(startPosition, targetPosition, t);
            transform.position = newPosition;
            yield return null;
        }
        transform.position = targetPosition;
        timeElapse = 0;
    }
}
