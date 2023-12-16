using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCarController : MonoBehaviour, ISelectedCar
{
    private SelectCarManager selectCarManager;
    [SerializeField] private List<GameObject> _listCar;
    [SerializeField] private GameObject _selectedCar;
    [SerializeField] private GameObject carMidParent;
    [SerializeField] private List<GameObject> rectTransforms;
    private void Awake()
    {
        selectCarManager = SelectCarManager.Instant;
    }
    private void Start()
    {
        
    }
    public void OnSelectCar()
    {
        StartCoroutine(SelectedCar());

    }
    IEnumerator SelectedCar()
    {
        _listCar = selectCarManager.GetListCar();
        _selectedCar = selectCarManager.GetSelectedCar();
        carMidParent = rectTransforms[1].transform.gameObject;
        GameObject selectedCarParent = _selectedCar.transform.parent.gameObject;

        if (selectedCarParent != carMidParent)
        {
            _selectedCar.transform.SetParent(carMidParent.transform);
        }

        _listCar.Remove(_selectedCar);
        foreach (GameObject car in _listCar)
        {
            car.GetComponent<IMovable>().MoveToTarget(new Vector3(0f, -800f, 0f), 0.1f);
        }
        yield return new WaitForSeconds(0.25f);
        _selectedCar.GetComponent<IMovable>().MoveToTarget(Vector3.zero, 0.05f);
        yield return new WaitForSeconds(0.25f);
        _selectedCar.GetComponent<IScale>().OnScale(1.5f, 0.1f);
    }
}
