using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class LoadCarOptionController : MonoBehaviour, ILoadSelectOption
{
    [SerializeField] private List<RectTransform> slotRectTransforms;
    [SerializeField] private List<GameObject> carOptionPrefabs;
    private List<int> carIndicators;
    private bool isLoadAssetDone;
    private LoadCarOptionPrefabFromWeb loadAssetBundles;
    [SerializeField] private List<GameObject> listPrefabs;
    private void Awake()
    {
        loadAssetBundles = GetComponent<LoadCarOptionPrefabFromWeb>();
        loadAssetBundles.LoadAssetBundleFromWeb();
    }
    public void LoadSelectOption()
    {
        listPrefabs = loadAssetBundles.GetList();
        StartCoroutine(LoadCarOption());
    }
    IEnumerator LoadCarOption()
    {
        carIndicators = new List<int>();
        for (int i = 0; i < carOptionPrefabs.Count; i++)
        {
            carIndicators.Add(i);
        }

        for (int i = 0; i < carOptionPrefabs.Count; i++)
        {
            int carIndexRandom = Random.Range(0, carIndicators.Count);
            int selectedIndex = carIndicators[carIndexRandom];
            carIndicators.RemoveAt(carIndexRandom);

            GameObject carPrefab = carOptionPrefabs[selectedIndex];
            RectTransform slot = slotRectTransforms[i];
            GameObject option = Instantiate(carPrefab, slot.position, Quaternion.identity);
            SelectCarManager.Instant.AddToListCar(option);
            RectTransform rectTransformOption = option.GetComponent<RectTransform>();
            rectTransformOption.SetParent(slot);
            Vector3 startPosition = new Vector3(0f, -800f, 0f);
            rectTransformOption.anchoredPosition = startPosition;
            rectTransformOption.localScale = Vector3.one;
            IMovable movable = option.GetComponent<IMovable>();
            movable.MoveToTarget(Vector3.zero, 0.5f);
            yield return new WaitForSeconds(0.1f);
            Rigidbody2D rigi = option.GetComponentInChildren<Rigidbody2D>();
            rigi.gravityScale = 1f;
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.5f);
    }

    public bool IsLoadAssetDone()
    {
        return isLoadAssetDone;
    }
}
