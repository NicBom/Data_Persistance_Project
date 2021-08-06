using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

    string namePut;
    public InputField nameInput;
    // Start is called before the first frame update
   
    public void OnStartClicked()
    {
        PersistName.PersistentName.setName(nameInput.text);
        SceneManager.LoadScene("main");
    }

    public void OnExitClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif

        Application.Quit();
    }
}
