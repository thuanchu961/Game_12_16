using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using Object = UnityEngine.Object;

public class LoadAssetBundlesFromWeb : Singleton<LoadAssetBundlesFromWeb> //ILoadAssetBundleFromWeb
{
    public Action<Object> OnAssetBundleLoaded;
    public string bundleUrl = "";
    public string assetName = "BundledObject";

    [SerializeField]private Object assetBundleLoaded;

    public void LoadAssetBundleFromWeb(string bundleURL, string assetName)
    {
        StartCoroutine(LoadAssetBundles(bundleURL, assetName));
    }

    // Start is called before the first frame update
    IEnumerator LoadAssetBundles(string bundleURL, string assetName)
    {
        UnityWebRequest web = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL);
        Debug.Log(bundleURL + " ||| " +assetName);
        yield return web.SendWebRequest();
        if(web.result == UnityWebRequest.Result.ConnectionError || web.result == UnityWebRequest.Result.ProtocolError)
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
            assetBundleLoaded = remoteAssetBundle.LoadAsset(assetName);
            OnAssetBundleLoaded?.Invoke(assetBundleLoaded);
            //Instantiate(loadedObject);
            remoteAssetBundle.Unload(false);
        }
        web.Dispose();
    }
}
