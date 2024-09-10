using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCheck : MonoBehaviour
{
    public InputField text;
    public GameObject CardError;



    public void NumberCheck()
    {
        
        if(text.text.Length != 10)
        {
            text.text = "Λαθος Αριθμος";
            StartCoroutine(ErrorMessage("Λαθος Αριθμος, Πρεπει να εχει μηκος 10 χαρακτηρες", 2));
        }
        
    }

    public void CVVCheck()
    {

        if (text.text.Length != 3)
        {
            text.text = "Λαθος CVV";
            StartCoroutine(ErrorMessage("Λαθος CVV, Πρεπει να εχει μηκος 3 χαρακτηρες", 2));
        }
 
    }

    IEnumerator ErrorMessage(string message, float delay)
    {
        CardError.GetComponent<Text>().text = message;
        CardError.SetActive(true);
        yield return new WaitForSeconds(delay);
        CardError.SetActive(false);
    }
}
