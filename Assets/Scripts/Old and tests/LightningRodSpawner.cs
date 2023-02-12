using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningRodSpawner : MonoBehaviour
{
    public LightningRod lightningPrefab;
    public float minFreq = 1;
    public float maxFreq = 4;
    public float fadeIncrement = 1f;

    public Transform startPos, endPos;



    void Start()
    {
        LightningRod.startPos = startPos;
        LightningRod.endPos = endPos;
        LightningRod.fadeIncrement = fadeIncrement;

        Invoke("RepeatRandom", 0.5f);
    }

    void RepeatRandom()
    {
        for (int i = 0; i < Random.Range(1, 3); i++)
        {
            InstantiateLightning();
        }

        Invoke("RepeatRandom", Random.Range(minFreq, maxFreq));
    }

    void InstantiateLightning()
    {
        //var obj = Instantiate(lightningPrefab, lightningPrefab.transform.position, transform.rotation);
        //obj.transform.parent = transform;
        var obj = Instantiate(lightningPrefab, transform);
        
    }
}
