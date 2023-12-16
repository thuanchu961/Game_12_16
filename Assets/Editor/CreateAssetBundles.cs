using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateAssetBundles 
{
    [MenuItem("Assets/Build AssetBundles")]
    public static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if (!Directory.Exists(assetBundleDirectory)) // nếu chưa có folder AssetBundles 
        {
            Directory.CreateDirectory(assetBundleDirectory); // tạo ra folder AssetBundles
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory,
                                        BuildAssetBundleOptions.None,
                                        EditorUserBuildSettings.activeBuildTarget);
        Debug.Log("Finish build asset bundles");
    }
}
