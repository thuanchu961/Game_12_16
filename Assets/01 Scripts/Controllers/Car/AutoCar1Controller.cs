using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCar1Controller : Singleton<AutoCar1Controller>
{
    [SerializeField] private GameObject carPrefab;
    private Car car;
    private GameObject autoCar;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float moveTime = 1f;
    private string typeCar;

    private void Start()
    {
        car = GetComponent<AutoCar>();
        startPosition = transform.position;
        typeCar = GameManager.Instant.GetIdAutoCar(0);
        InitCar();
    }
    private void InitCar()
    {
        autoCar = Instantiate(carPrefab, transform.position, Quaternion.identity);
        autoCar.transform.SetParent(this.transform);
        car.SetState(typeCar, 0, autoCar);
    }
    public void StartPlay()
    {
        car.SetState(typeCar, 1, autoCar);
        targetPosition = new Vector3(19, transform.position.y, transform.position.z);
        car.Move(moveTime, startPosition, targetPosition);
    }
    public void ChangeLane(float newPositionY)
    {
        targetPosition = new Vector3(transform.position.x, newPositionY, transform.position.z);
        car.Move(0.2f, transform.position, targetPosition);
    }

    public void MoveForWard()
    {
        targetPosition = new Vector3(19, transform.position.y, transform.position.z);
        car.Move(3, transform.position, targetPosition);
    }
    public void MoveBackWard()
    {
        targetPosition = new Vector3(-19, transform.position.y, transform.position.z);
        car.Move(3, transform.position, targetPosition);
    }
    public void MoveDestination()
    {
        targetPosition = new Vector3(19, transform.position.y, transform.position.z);
        car.Move(1.7f, transform.position, targetPosition);
    }
}
