using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBorderController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.TAG.Alphabet.ToString()))
        {
            MapManager.Instance.MissAlphabet();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
