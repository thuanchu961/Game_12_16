using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private string _idSelectedCar;
    [SerializeField] private List<string> listCars = new List<string>
    {
        Constant.CAR.PinkCar.ToString(), 
        Constant.CAR.OrangeCar.ToString(), 
        Constant.CAR.BlueCar.ToString(), 
    };
    private ICountDown countDownController;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        countDownController = GetComponent<ICountDown>();
    }
    public void SetIdSelectedCar(string id)
    {
        _idSelectedCar = id;
    }
    public string GetIdSelectedCar()
    {
        return _idSelectedCar;
    }
    public void UpdateListCar()
    {
        for (int i = 0; i < listCars.Count; i++)
        {
            if (_idSelectedCar == listCars[i])
            {
                listCars.RemoveAt(i);
            }
        }
    }
    public string GetIdAutoCar(int i)
    {
        return listCars[i];
    }
    public void StartCountDown()
    {
        countDownController.CountDown();
    }
}
