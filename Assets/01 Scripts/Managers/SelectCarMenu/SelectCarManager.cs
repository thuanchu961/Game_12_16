using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCarManager : Singleton<SelectCarManager>
{
    [SerializeField] private List<GameObject> listCar;
    [SerializeField] private GameObject selectedCar;
    private ILoadSelectOption loadSelectOption;
    private IImageUI spotLight;
    private ITextUI textChooseCar;
    private ISelectedCar selectCarController;
    private bool isSelectedCar;
    private void Awake()
    {
        selectCarController = GetComponent<ISelectedCar>();
        loadSelectOption = GetComponentInChildren<ILoadSelectOption>();
        
        spotLight = GetComponentInChildren<IImageUI>();
        spotLight.DisableImage();

        textChooseCar = GetComponentInChildren<ITextUI>();
        textChooseCar.DisableText();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroGame());
    }
    // Update is called once per frame
    void Update()
    {
        if (isSelectedCar)
        {
            StartCoroutine(SelectedCar());
        }
    }
    IEnumerator IntroGame()
    {
        MusicController.Instant.PlayMusic((int)Constant.MUSIC.WaittingSelectedCar);
        yield return new WaitForSeconds(1f);
        loadSelectOption.LoadSelectOption();
        yield return new WaitForSeconds(0.6f);
        textChooseCar.EnableText();
    }
    IEnumerator SelectedCar()
    {
        textChooseCar.DisableText();
        selectCarController.OnSelectCar();
        spotLight.EnableImage();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
        Debug.Log("load scene game play");
    }
    public void AddToListCar(GameObject car)
    {
        listCar.Add(car);
    }
    public List<GameObject> GetListCar()
    {
        return listCar;
    }
    public void SetSelectedCar(GameObject car)
    {
        selectedCar = car;
        isSelectedCar = true;
    }
    public GameObject GetSelectedCar()
    {
        return selectedCar;
    }
}
