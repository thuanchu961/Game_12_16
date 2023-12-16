using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageTypeCarManager : Singleton<StorageTypeCarManager>
{
    public List<string> lstCarAuto = new List<string>
    {
        "PinkCar", "BlueCar", "OrangeCar"
    };
    public string IDCar { get; set; }
    public void GetListCar()
    {
        for (int i = 0; i < lstCarAuto.Count; i++)
        {
            if (IDCar == lstCarAuto[i])
            {
                lstCarAuto.RemoveAt(i);
            }
        }
    }
}
