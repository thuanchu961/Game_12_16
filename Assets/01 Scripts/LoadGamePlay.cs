using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGamePlay : MonoBehaviour
{
    private void Awake()
    {
        if (GameManager.Instant != null)
        {
            //Instantiate(GameManager.Instant.gamePlayPrefab, Vector3.zero, Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
