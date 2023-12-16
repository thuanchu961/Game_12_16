using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Linq;

public class LoadCarOptionPrefabFromWeb : MonoBehaviour, ILoadAssetBundleFromWeb
{
    public string bundleUrl = "https://firebasestorage.googleapis.com/v0/b/fir-c8254.appspot.com/o/AssetBundles%2Fcaroptions?alt=media&token=7f0f5d32-a2a2-45b4-b3de-684851fcfe52";
    public string assetName = "BundledObject";

    public List<string> enumStringList;
    public List<GameObject> carOptionsPrefabs;
    private void Awake()
    {
        
    }
    public List<GameObject> GetList()
    {
        return carOptionsPrefabs;
    }
    public void LoadAssetBundleFromWeb()
    {
        StartCoroutine(LoadAssetBundles(bundleUrl));
    }

    // Start is called before the first frame update
    IEnumerator LoadAssetBundles(string bundleURL)
    {
        enumStringList = Enum.GetNames(typeof(Constant.CAR_OPTION)).ToList();
        UnityWebRequest web = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL);
        yield return web.SendWebRequest();
        if (web.result == UnityWebRequest.Result.ConnectionError || web.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error at: " + bundleURL + " " + web.error);
        }
        else
        {
            AssetBundle remoteAssetBundle = DownloadHandlerAssetBundle.GetContent(web);
            if (remoteAssetBundle == null)
            {
                Debug.LogError("Failed to download AssetBundle!");
                yield break;
            }

            foreach (string value in enumStringList)
            {
                assetName = value + ".prefab";
                GameObject assetBundleLoaded = remoteAssetBundle.LoadAsset<GameObject>(assetName);
                if (assetBundleLoaded == null)
                {
                    Debug.Log("assetBundleLoaded is null");
                }
                carOptionsPrefabs.Add(assetBundleLoaded);
            }
           
            remoteAssetBundle.Unload(false);
        }
        web.Dispose();
        yield return new WaitForEndOfFrame();
    }
}
