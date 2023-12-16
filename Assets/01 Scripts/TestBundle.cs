using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Object = UnityEngine.Object;

public class TestBundle : MonoBehaviour
{
    LoadAssetBundlesFromWeb loadAssetBundle;
    public string bundleUrl = "";
    public string assetName = "TestAsset";
    public GameObject asset;
    public List<GameObject> lists;
    private void Awake()
    {
        loadAssetBundle = GetComponent<LoadAssetBundlesFromWeb>();
        loadAssetBundle.OnAssetBundleLoaded += OnAssetBundleLoaded;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //loadAssetBundle.LoadAssetBundleFromWeb(bundleUrl, assetName);
       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InitAsset();
        }
    }

    private void OnAssetBundleLoaded(Object loadedObject)
    {
        if (loadedObject == null)
            return;

        asset = loadedObject as GameObject;
        lists.Add(asset);
        //Instantiate(asset);
    }
    public void InitAsset()
    {
        List<string> enumStringList = Enum.GetNames(typeof(Constant.CAR)).ToList();

        // In danh sách chuỗi
        foreach (string value in enumStringList)
        {
            loadAssetBundle.LoadAssetBundleFromWeb(bundleUrl, value);
        }
    }
}
