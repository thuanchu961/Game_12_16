using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SetStateController : MonoBehaviour, ISetState
{
    ISetAnimation setAnimation;
    [SerializeField] Constant.BlueCar[] blueCarAnim;
    [SerializeField] Constant.PinkCar[] pinkCarAnim;
    [SerializeField] Constant.OrangeCar[] orangeCarAnim;
    Enum[] lstPinkCars = { Constant.PinkCar.Start, Constant.PinkCar.Move, Constant.PinkCar.Fadein, Constant.PinkCar.Flicker, Constant.PinkCar.AddForce1, Constant.PinkCar.AddForce2 };
    Enum[] lstBlueCars = { Constant.BlueCar.Start, Constant.BlueCar.Move, Constant.BlueCar.Fadein, Constant.BlueCar.Flicker, Constant.BlueCar.AddForce1, Constant.BlueCar.AddForce2 };
    Enum[] lstOrangeCars = { Constant.OrangeCar.Start, Constant.OrangeCar.Move, Constant.OrangeCar.Fadein, Constant.OrangeCar.Flicker, Constant.OrangeCar.AddForce1, Constant.OrangeCar.AddForce2 };
    private void Start()
    {
        blueCarAnim = (Constant.BlueCar[])Enum.GetValues(typeof(Constant.BlueCar));
        pinkCarAnim = (Constant.PinkCar[])Enum.GetValues(typeof(Constant.PinkCar));
        orangeCarAnim = (Constant.OrangeCar[])Enum.GetValues(typeof(Constant.OrangeCar));
    }
    public void SetState(string typeCar, int animNumber, GameObject gameObject)
    {
        setAnimation = GetComponent<ISetAnimation>();
        switch (typeCar)
        {
            case "PinkCar":
                setAnimation.SetAnim(ConvertStringController.Convert(lstPinkCars[animNumber]), gameObject, true);
                break;
            case "BlueCar":
                setAnimation.SetAnim(ConvertStringController.Convert(lstBlueCars[animNumber]), gameObject, true);
                break;
            case "OrangeCar":
                setAnimation.SetAnim(ConvertStringController.Convert(lstOrangeCars[animNumber]), gameObject, true);
                break;
        }
    }
}
