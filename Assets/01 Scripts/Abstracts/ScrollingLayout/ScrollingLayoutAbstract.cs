using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScrollingLayoutAbstract : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Transform bg1;
    [SerializeField] protected Transform bg2;
    float offset;
    protected bool isStart = true;
    protected virtual void Awake()
    {
        offset = bg1.GetComponent<SpriteRenderer>().bounds.size.x;
        bg2.transform.position = new Vector3(
            bg1.transform.position.x + offset,
            bg1.transform.position.y,
            0f);
    }
    protected void Update()
    {
        if (!isStart) return;
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (bg1.position.x <= -offset)
        {
            bg1.position = new Vector3(
                bg2.transform.position.x + offset,
                bg2.transform.position.y,
                0f);
        }

        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }
}
