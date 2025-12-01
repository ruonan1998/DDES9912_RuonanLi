//Edited by Ruonan 01 Dec 2025 for A2

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WinChecker : MonoBehaviour
{
    public SlotMachineWheels wheel1, wheel2, wheel3;
    public int berryindex = 0;
    public  TextMeshProUGUI resultText;
    public  GameObject Coin;
    public  GameObject CoinSpawnPoint; 
    public  Light RedLight;
    public  Light GreenLight;
    public  Light YellowLight;
    public void CheckWin()
    {
        int a = wheel1.laststopindex;
        int b = wheel2.laststopindex;
        int c = wheel3.laststopindex;
        
        if (a == berryindex && b == berryindex && c == berryindex)
        {
            StartCoroutine(ShowResultDelayed("Jackpot!!! 100", 6f));
            SpawnCoins(10);
            return;
        }
        
        if (a == b && b == c)
        {
            StartCoroutine(ShowResultDelayed("You win! 50", 6f));
            SpawnCoins(5);
            return;
        }
        if (a == b || b == c || a == c) 
        {
            StartCoroutine(ShowResultDelayed("Small win! 20", 6f));
            SpawnCoins(2);
            return;
        }

        else
        {
            StartCoroutine(ShowResultDelayed("Try Again:(", 6f));
        }
    }

    private IEnumerator ShowResultDelayed(string message, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (message == "")
        {
            ShowResult("");
        }
        else
        {
            ShowResult(message);
        }
    }

    private void SetActiveForDuration(GameObject obj, float duration)
    {
        StartCoroutine(ActivateForTime(obj, duration));
    }
    private IEnumerator ActivateForTime(GameObject obj, float duration)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(duration);
        obj.SetActive(false);
    }

    void ShowResult(string message)
    {
        resultText.text = message;
        if(message.Contains("Small win") || message.Contains("You win") || message.Contains("Jackpot"))
        {
            resultText.color = Color.green;
        }
        else if(message.Contains("Try Again"))
        {
            resultText.color = Color.red;
        }

        if(message.Contains("Jackpot"))
        SpawnCoins(10);
        else if(message.Contains("You win"))
        SpawnCoins(5);
        else if(message.Contains("Small win"))
        SpawnCoins(2);
        
        if(message.Contains("Small win"))

        {
            SetActiveForDuration(YellowLight.gameObject, 3f);
        }
        else if(message.Contains("You win"))
        {
            SetActiveForDuration(GreenLight.gameObject, 3f);
        }
        else if(message.Contains("Jackpot"))
        {
            SetActiveForDuration(RedLight.gameObject, 3f);
        }
        
    }   

    void SpawnCoins(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject CoinInstance = Instantiate(Coin, CoinSpawnPoint.transform.position, Quaternion.identity);
            Rigidbody coinRigidbody = CoinInstance.GetComponent<Rigidbody>();
            if (coinRigidbody != null)
            {
                Vector3 randomForce = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)) * Random.Range(2f, 5f);
                coinRigidbody.AddForce(randomForce, ForceMode.Impulse); 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
