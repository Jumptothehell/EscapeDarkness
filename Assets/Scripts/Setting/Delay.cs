using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Animator>().enabled = false;
        StartCoroutine(DelayAnimation());
    }
    IEnumerator DelayAnimation()
    {
        float random = Random.Range(0, 1.2f);
        yield return new WaitForSeconds(random);
        GetComponent<Animator>().enabled = true;
    }
}
