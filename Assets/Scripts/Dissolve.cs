using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] private float DissolveTime = 0.5f;
    private Material dissMat;

    private void Awake()
    {
        dissMat = GetComponent<SpriteRenderer>().material;
    }

    private IEnumerator RunDissolve()
    {
        float time = DissolveTime;

        while(time >= 0)
        {
            time -= Time.deltaTime;
            dissMat.SetFloat("_Fade", time);
            yield return null;
        }
        gameObject.SetActive(false);
    }

    public IEnumerator PlayerDissolve()
    {
        float time = DissolveTime;

        while (time >= 0)
        {
            time -= Time.deltaTime;
            dissMat.SetFloat("_Fade", time);
            yield return null;
        }
    }
 
    public void StartDissolve()
    {
        StartCoroutine(RunDissolve());
    }

    public void StartPlayerDissolve()
    {
        StartCoroutine(PlayerDissolve());
    }
}
