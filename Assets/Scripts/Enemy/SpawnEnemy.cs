using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject pref;
    public GameObject enemy;

    private void Start()
    {
        enemy.GetComponent<EnemyAI>();
    }

    private void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy == null)
        {
            StartCoroutine(DelaySpawm());
            spawnEnemy();
        }
    }
    IEnumerator DelaySpawm()
    {
        float random = Random.Range(0, 1.2f);
        yield return new WaitForSeconds(random);
    }
    private void spawnEnemy()
    {
        Instantiate(pref, new Vector3(Random.Range(-8f, 80f), 3.6f, 0f), Quaternion.identity);
    }
}
