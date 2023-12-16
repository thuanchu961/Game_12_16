using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCarController : MonoBehaviour, IGetIDCar, IGetObjectCar
{
    public List<Constant.CAR> lstIDCar;

    public string GetIDCar()
    {
        return lstIDCar[0].ToString();
    }
    public GameObject GetGameObject()
    {
        return transform.parent.gameObject;
    }
}
