using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class SelectOptionController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Constant.CAR car;
    public void OnPointerClick(PointerEventData eventData)
    {
        SoundController.Instant.PlaySound((int)Constant.SOUND.GreatChoice);
        Debug.Log("You selected " + gameObject.name);
        //StorageTypeCarManager.Instant.IDCar = car.ToString();
        GameManager.Instant.SetIdSelectedCar(car.ToString());
        GameManager.Instant.UpdateListCar();
        SelectCarManager.Instant.SetSelectedCar(transform.parent.gameObject);
    }
}
