using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCarController : Subject
{
    public static MainCarController Instance { get; private set; }
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private GameObject guidingFingerPrefab;
    private GameObject guidFinger;
    private GameObject playcar;

    private Car car;
    private Vector3 startPosition;

    private string typeCar;

    private float speedNormalBackGround = 7f;
    private float speedTriggerBackGround = 14f;
    private float speedAddforceBackGround = 24.5f;
    private float stopBackGround = 0f;

    private bool changeLane;
    private bool triggerAddforce;

    private SoundController soundController;
    private MusicController musicController;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        soundController = SoundController.Instant;
        musicController = MusicController.Instant;
    }
    private void Start()
    {
        car = GetComponent<MainCar>();
        typeCar = GameManager.Instant.GetIdSelectedCar();
        startPosition = transform.position;
        InitPlayCar();
        StartCoroutine(StartGame());
    }
    private void InitPlayCar()
    {
        playcar = Instantiate(carPrefab, transform.position, Quaternion.identity);
        playcar.transform.SetParent(this.transform); ;
        car.SetState(typeCar, 0, playcar);
    }
    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);
        soundController.PlaySound((int)Constant.SOUND.StadiumCrowdCheering);
        soundController.PlaySound((int)Constant.SOUND.Intro);
        yield return new WaitForSeconds(5f);
        soundController.StopSound();
        soundController.PlaySound((int)Constant.SOUND.CountDown);
        GameManager.Instant.StartCountDown();
        yield return new WaitForSeconds(3f);
        musicController.PlayMusic((int)Constant.MUSIC.PlayGame);
        SideRoadManager.Instant.StartGo();
        yield return new WaitForSeconds(1f);
        AutoCar1Controller.Instant.StartPlay();
        AutoCar2Controller.Instant.StartPlay();
        Notify(speedNormalBackGround);
        car.SetState(typeCar, 1, playcar);
        yield return new WaitForSeconds(2.5f);
        soundController.PlaySound((int)Constant.SOUND.Guiding);
        guidFinger = Instantiate(guidingFingerPrefab, new Vector3(7, -2, 0), Quaternion.identity);
        changeLane = true;
    }
    public void ChangeLane(Vector3 newPosition)
    {
        if (!changeLane) return;
        float Auto1PositionY = AutoCar1Controller.Instant.transform.position.y;
        float Auto2PositionY = AutoCar2Controller.Instant.transform.position.y;
        float moveTime;
        float positionY = this.transform.position.y;

        if (Mathf.Abs(positionY - newPosition.y) == 4)
        {
            moveTime = 0.35f;
            car.Move(moveTime, transform.position, newPosition);
            startPosition = newPosition;
        }
        else if (Mathf.Abs(positionY - newPosition.y) == 2)
        {
            StartCoroutine(FirstGuiding());
            moveTime = 0.25f;
            car.Move(moveTime, transform.position, newPosition);
            startPosition = newPosition;
        }
        else return;
        if (newPosition.y == Auto1PositionY)
        {
            AutoCar1Controller.Instant.ChangeLane(positionY);
        }
        else if (newPosition.y == Auto2PositionY)
        {
            AutoCar2Controller.Instant.ChangeLane(positionY);
        }
    }
    private IEnumerator FirstGuiding()
    {
        if (guidFinger != null)
        {
            soundController.StopSound();
            Destroy(guidFinger);
            soundController.PlaySound((int)Constant.SOUND.NiceDriving);
            yield return new WaitForSeconds(4f);
            MapManager.Instance.GenerateAlphabet();
        }
    }
    public void SetChangeLane(bool value)
    {
        this.changeLane = value;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.TAG.Alphabet.ToString()))
        {
            MapManager.Instance.TriggerAlphabet();
            StartCoroutine(TriggerAlphabet());
        }
        if(collision.CompareTag(Constant.TAG.AddForce.ToString()))
        {
            if (triggerAddforce) return;
            Destroy(collision.gameObject);
            StartCoroutine(Addforce());
            triggerAddforce = true;
        }
    }
    private IEnumerator TriggerAlphabet()
    {
        changeLane = false;
        yield return new WaitForSeconds(1f);
        car.SetState(typeCar, 2, playcar);
        yield return new WaitForSeconds(1f);
        car.Move(3, transform.position, new Vector3(0, startPosition.y, startPosition.z));
        Notify(speedTriggerBackGround);
        yield return new WaitForSeconds(3f);
        car.SetState(typeCar, 3, playcar);
        yield return new WaitForSeconds(1.5f);
        car.SetState(typeCar, 1, playcar);
        car.Move(2, transform.position, startPosition);
        yield return new WaitForSeconds(2f);
        Notify(speedNormalBackGround);
        changeLane = true;
        yield return new WaitForSeconds(1.5f);
        MapManager.Instance.GenerateAlphabet();
    }
    private IEnumerator Addforce()
    {
        changeLane = false;
        soundController.PlaySound((int)Constant.SOUND.EnergyTouch);
        yield return new WaitForSeconds(1f);
        car.SetState(typeCar, 4, playcar);
        yield return new WaitForSeconds(0.3f);
        car.SetState(typeCar, 5, playcar);
        soundController.PlaySound((int)Constant.SOUND.EnergyPowerUp);
        car.Move(3, transform.position, new Vector3(4, transform.position.y, transform.position.z));
        Notify(speedAddforceBackGround);
        MapManager.Instance.EndingGame();
    }
    public void EndingGame()
    {
        Notify(stopBackGround);
        car.Move(0.5f, transform.position, new Vector3(22, transform.position.y, 0));
    }
}
