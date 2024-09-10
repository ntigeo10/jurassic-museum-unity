using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : Interactable
{
    public string sceneToGo;
    public GameObject Text;
    //public GameObject player;
    //public float x, y, z, rot;

    public override void OnFocus()
    {
        print("Looking at" + gameObject.name);
        Text.SetActive(true);
    }

    public override void onInteract()
    {
        SceneManager.LoadScene(sceneToGo);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        //player.transform.position = new Vector3(x,y,z);
        //player.transform.eulerAngles = new Vector3(rot,0,0);
    }

    public override void onLoseFocus()
    {
        print("stopped looking at " + gameObject.name);
        Text.SetActive(false);
    }

    public override void stopInteract()
    {
        //image.SetActive(false);
    }
}
