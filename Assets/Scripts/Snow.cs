using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    private SceneryItem[] sceryItems;

    public void Start()
    {
        sceryItems = GameObject.FindObjectsOfType<SceneryItem>();
        StartSnow();
    }

    public void StartSnow()
    {
        StartCoroutine(SnowRoutine());
    }

    public IEnumerator SnowRoutine()
    {
        foreach(var item in sceryItems)
        {
            yield return new WaitForSeconds(Random.Range(.1f, 1));
            item.SnowOn();
            item.Shake();
        }
    }
}
