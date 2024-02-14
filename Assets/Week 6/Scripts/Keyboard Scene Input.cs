using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardSceneInput : MonoBehaviour
{
    public GameObject loaderObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            loaderObject.SendMessage("LoadNextScene");
        }
    }
}
