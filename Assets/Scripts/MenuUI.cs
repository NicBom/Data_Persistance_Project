using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

    public InputField nameInput;
    
   //sets methods for when Start and Exit buttons are clicked. 
    public void OnStartClicked()
    {
        PersistName.PersistentName.setName(nameInput.text);
        SceneManager.LoadScene("main"); //could also be LoadScene(0); based on Build Settings. 
    }

    public void OnExitClicked()
    { //first section will exit the editor, second for application. 
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif

        Application.Quit();
    }
}
