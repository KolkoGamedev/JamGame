using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] private float dissolvePower = 1f;
    [SerializeField] private float DissolveTime = 0.5f;
    private Material dissMat;
    private Rigidbody2D rb;

    private void Awake()
    {
        if(gameObject.CompareTag("Player"))
        rb = GetComponent<Rigidbody2D>();

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
    private IEnumerator PlayerDissolve()
    {
        float time = DissolveTime;

        while (time >= 0)
        {
            time -= Time.deltaTime;
            dissMat.SetFloat("_Fade", time);
            yield return null;
        }
    }
    private IEnumerator PlayerReverseDissolve()
    {
        float time = 0f;

        while (time <= DissolveTime)
        {
            time += Time.deltaTime;
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
        rb.simulated = false;
        rb.gravityScale = 0;
        StartCoroutine(PlayerDissolve());
    }

    public void StartPlayerReverseDissolve(GameObject go)
    {
        StartCoroutine(PlayerReverseDissolve());
        rb.simulated = true;
        rb.gravityScale = 1;
    }
}
