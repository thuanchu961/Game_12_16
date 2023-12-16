using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChooseCarController : MonoBehaviour, ITextUI
{
    [SerializeField] private TMP_Text textChooseCar;
    
    public void EnableText()
    {
        textChooseCar.enabled = true;
    }
    public void DisableText()
    {
        textChooseCar.enabled = false;
    }
}
