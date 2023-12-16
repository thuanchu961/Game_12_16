using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Linq;

public class LoadMusicAudioFromWeb : MonoBehaviour, ILoadAssetBundleFromWeb
{
    public string bundleUrl = "https://firebasestorage.googleapis.com/v0/b/fir-c8254.appspot.com/o/AssetBundles%2Fmusic?alt=media&token=2e97419a-2499-490a-a776-55eee223ddc0";
    public string assetName = "";
    public List<string> enumStringList;
    public List<AudioClip> audioList;
    public List<AudioClip> GetList()
    {
        return audioList;
    }
    public void LoadAssetBundleFromWeb()
    {
        StartCoroutine(LoadAssetBundles(bundleUrl));
    }
    IEnumerator LoadAssetBundles(string bundleURL)
    {
        enumStringList = Enum.GetNames(typeof(Constant.MUSIC)).ToList();
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
                assetName = value + ".mp3";
                AudioClip assetBundleLoaded = remoteAssetBundle.LoadAsset<AudioClip>(assetName);
                if (assetBundleLoaded == null)
                {
                    Debug.Log("assetBundleLoaded is null");
                }
                audioList.Add(assetBundleLoaded);
            }

            remoteAssetBundle.Unload(false);
        }
        web.Dispose();
        yield return new WaitForEndOfFrame();
    }
}
