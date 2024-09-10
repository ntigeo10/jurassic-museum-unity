using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToLobby : MonoBehaviour
{
    public GameObject ThanksScreen;
    public GameObject CardError;
    public GameObject BasketScreen;
    public GameObject CardScreen;
    public Text Card, CVV;
    bool CardCheck, CVVCheck;


    public void Start()
    {
        CardCheck = false;
        CVVCheck = false;
    }
    public void Update()
    {
        if (Card.GetComponent<Text>().text.Length == 10)
        {
            CardCheck = true;
        }
        if (CVV.GetComponent<Text>().text.Length == 3)
        {
            CVVCheck = true;
        }
    }


    public void ConfirmPurchase()
    {
        if (CardCheck && CVVCheck)
        { 
            StartCoroutine(Thanks(2));
        }
        else
        {
            StartCoroutine(ErrorMessage("Λαθος Στοιχεια Καρτας",2));
        }
    }

    IEnumerator Thanks(float delay)
    {
        ThanksScreen.SetActive(true);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Lobby");
    }

    IEnumerator ErrorMessage(string message, float delay)
    {
        CardError.GetComponent<Text>().text = message;
        CardError.SetActive(true);
        yield return new WaitForSeconds(delay);
        CardError.SetActive(false);
    }

    public void ReturnToBasket()
    {
        BasketScreen.SetActive(true);
        CardScreen.SetActive(false);
    }

}
