using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class Flicker : MonoBehaviour
{
    [SerializeField] bool isFlicker = false;
    private void Update()
    {
        if (isFlicker == false)
        {
            StartCoroutine(FlickerLight());
        }
    }
    IEnumerator FlickerLight()
    {
        isFlicker = true;
        this.gameObject.GetComponent<Light2D>().enabled = false;
        float randDelay = Random.Range(0.0f, 0.5f);
        yield return new WaitForSeconds(randDelay );
        this.gameObject.GetComponent<Light2D>().enabled = true;
        randDelay = Random.Range(0.0f, 0.5f);
        yield return new WaitForSeconds(randDelay);
        isFlicker = false;
    }
}
