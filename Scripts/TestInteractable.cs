using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInteractable : Interactable
{
    public GameObject image;
    public GameObject Text;
    public GameObject ConfirmPurchase;
    public GameObject Button;
    public override void OnFocus()
    {
        print ("Looking at" + gameObject.name);
        Text.SetActive (true);
        

    }

    public override void onInteract()
    {
        image.SetActive (true);
        Text.SetActive(false);
        if(Button !=null)
            Button.SetActive (true);
    }

    public override void onLoseFocus()
    {
        print("stopped looking at " + gameObject.name);
        Text.SetActive(false);
    }

    public override void stopInteract()
    {
        image.SetActive(false);
        if (Button != null)
            Button.SetActive(false);
    }

    public void purchase()
    {
        if(ConfirmPurchase!=null)
        StartCoroutine(ShowMessage("Προσθηκη στο καλαθι", 2));
    }

    IEnumerator ShowMessage(string message,float delay)
    {
        ConfirmPurchase.GetComponent<Text>().text = message;
        ConfirmPurchase.SetActive(true);
        yield return new WaitForSeconds(delay);
        ConfirmPurchase.SetActive(false);
    }
}
   
