using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    // This method will be called when the Exit button is clicked
    public void ExitApplication()
    {
        #if UNITY_EDITOR
        // If in the Unity Editor, stop play mode
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // If in the actual build, quit the application
        Application.Quit();
        #endif
    }
}
