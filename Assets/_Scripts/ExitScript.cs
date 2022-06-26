using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit presset");
    }
}
