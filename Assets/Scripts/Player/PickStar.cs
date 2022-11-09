using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickStar : MonoBehaviour
{
    public static int StarCoinCount;
    public TMPro.TMP_Text StarCoinText;
    public AudioClip coinSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StarCoin"))
        {
            AudioSource.PlayClipAtPoint(coinSound, other.transform.position);
            StarCoinCount++;
            StarCoinText.text = StarCoinCount.ToString();
            Destroy(other.gameObject);
        }
    }
    public void IncreaseStarCoin(int numOfCoin)
    {
        StarCoinCount += numOfCoin;
        StarCoinText.text = StarCoinCount.ToString();
    }
    public void DecreaseStarCoin(int numOfCoin)
    {
        StarCoinCount -= numOfCoin;
        StarCoinText.text = StarCoinCount.ToString();
    }

}
