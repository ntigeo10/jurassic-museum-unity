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
            text.text = "����� �������";
            StartCoroutine(ErrorMessage("����� �������, ������ �� ���� ����� 10 ����������", 2));
        }
        
    }

    public void CVVCheck()
    {

        if (text.text.Length != 3)
        {
            text.text = "����� CVV";
            StartCoroutine(ErrorMessage("����� CVV, ������ �� ���� ����� 3 ����������", 2));
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
