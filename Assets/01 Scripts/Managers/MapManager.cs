using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get; private set; }

    [Header("References")]
    [SerializeField] private List<GameObject> lstAlphabet;
    [SerializeField] private List<GameObject> lstMotionAudience;
    [SerializeField] private GameObject road;
    [SerializeField] private GameObject frameWord;
    [SerializeField] private GameObject sideRoad;
    private List<float> listPositionYAlphabet = new List<float> { -3.5f, -1.5f, 0.5f };
    [Space(10)]
    [Header("Prefabs")]
    [SerializeField] private GameObject addForcePrefab;
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private GameObject flagPrefab;

    private GameObject alphabet;
    private int numberMiss = 0;
    private int passCarNumbers = 0;
    private int indexListWord = 0;
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
    public void GenerateAlphabet()
    {
        if (indexListWord > 2) return;
        StartCoroutine(Generate());
    }
    private IEnumerator Generate()
    {
        alphabet = Instantiate(lstAlphabet[indexListWord], new Vector3(20, listPositionYAlphabet[Random.Range(0, listPositionYAlphabet.Count)],0), Quaternion.identity);
        alphabet.transform.SetParent(road.transform);
        yield return null;
    }

    public void MissAlphabet()
    {
        if (numberMiss < 2) numberMiss += 1;
        if (passCarNumbers > 0) passCarNumbers -= 1;
        StartCoroutine(Miss());
    }
    private IEnumerator Miss()
    {
        GameObject audienceSad = Instantiate(lstMotionAudience[1], new Vector3(21, 2, 0), Quaternion.identity);
        audienceSad.transform.SetParent(sideRoad.transform);

        alphabet.transform.SetParent(this.transform);
        alphabet.transform.position = new Vector3(20, listPositionYAlphabet[Random.Range(0, listPositionYAlphabet.Count)],0);
        soundController.PlaySound((int)Constant.SOUND.CrowdDisappoint);
        // AutoCar vượt lên
        if (numberMiss == 1)
        {
            AutoCar1Controller.Instant.MoveForWard();
            MainCarController.Instance.SetChangeLane(false);
        }
        else if (numberMiss == 2)
        {
            AutoCar2Controller.Instant.MoveForWard();
            MainCarController.Instance.SetChangeLane(false);
        }
        yield return new WaitForSeconds(3f);
        MainCarController.Instance.SetChangeLane(true);
        alphabet.transform.SetParent(road.transform);
        if (numberMiss == 2)
        {
            yield return new WaitForSeconds(1.5f);
            alphabet.transform.SetParent(this.transform);
            alphabet.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void ChooseLane(float positionY)
    {
        if (numberMiss == 2 && alphabet.transform.position.y == positionY + 1)
        {
            numberMiss = 0;
            alphabet.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            alphabet.transform.SetParent(road.transform);
            MainCarController.Instance.SetChangeLane(false);
        }
    }

    public void TriggerAlphabet()
    {
        StartCoroutine(Trigger());
    }
    public IEnumerator Trigger()
    {
        passCarNumbers += 1;
        if (numberMiss > 0) numberMiss -= 1;

        GameObject audienceHappy = Instantiate(lstMotionAudience[0], new Vector3(21, 2, 0), Quaternion.identity);
        audienceHappy.transform.SetParent(sideRoad.transform);

        alphabet.transform.SetParent(frameWord.transform);
        alphabet.GetComponent<IMoveToTarget>().MoveToTarget(0.5f, alphabet.transform.position, lstAlphabet[indexListWord].transform.position);
        soundController.PlaySound((int)Constant.SOUND.ItemTouch);
        soundController.PlaySound((int)Constant.SOUND.CrowdCheering);
        yield return new WaitForSeconds(0.75f);
        alphabet.GetComponent<IAudioHandler>().PlayAudio(0);
        indexListWord += 1;

        if (passCarNumbers == 1)
        {
            yield return new WaitForSeconds(1f);
            AutoCar1Controller.Instant.MoveBackWard();
        }
        else if (passCarNumbers == 2)
        {
            yield return new WaitForSeconds(1f);
            AutoCar2Controller.Instant.MoveBackWard();
        }

        if (indexListWord == 3)
        {
            StartCoroutine(WinGame());
        }
    }

    private IEnumerator WinGame()
    {
        yield return new WaitForSeconds(8f);
        GameObject addforce = Instantiate(addForcePrefab, new Vector3(20, 0, 0), Quaternion.identity);
        addforce.transform.SetParent(road.transform);
    }

    public void EndingGame()
    {
        StartCoroutine(Ending());
    }

    private IEnumerator Ending()
    {
        if (passCarNumbers == 1)
        {
            yield return new WaitForSeconds(0.5f);
            AutoCar2Controller.Instant.MoveBackWard();
        }

        yield return new WaitForSeconds(5f);
        GameObject line = Instantiate(linePrefab, new Vector3(19, 0, 0), Quaternion.identity);
        GameObject audienceHappy100 = Instantiate(lstMotionAudience[2], new Vector3(21, 2, 0), Quaternion.identity);
        line.transform.SetParent(road.transform);
        audienceHappy100.transform.SetParent(sideRoad.transform);

        yield return new WaitForSeconds(0.75f);
        MainCarController.Instance.EndingGame();
        GameObject flag = Instantiate(flagPrefab, new Vector3(0, -3.5f, 0), Quaternion.identity);
        flag.GetComponent<IMoveToTarget>().MoveToTarget(0.5f, flag.transform.position, Vector3.zero);
        soundController.PlaySound((int)Constant.SOUND.CrowdCheering);
        yield return new WaitForSeconds(0.75f);
        AutoCar1Controller.Instant.MoveDestination();
        AutoCar2Controller.Instant.MoveDestination();
        yield return new WaitForSeconds(3);
        //Notify(1);
        flag.GetComponent<IMoveToTarget>().MoveToTarget(0.5f, flag.transform.position, new Vector3(0, -3.5f, 0));
        FrameWordManager.Instant.FadeInFrameWord();
    }
}
