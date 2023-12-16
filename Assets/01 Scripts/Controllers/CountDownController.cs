using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownController : MonoBehaviour, ICountDown
{
    [SerializeField] private GameObject countDownPrefab;
    public void CountDown()
    {
        Instantiate(countDownPrefab, Vector3.zero, Quaternion.identity);
    }
}
