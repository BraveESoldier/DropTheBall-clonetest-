using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    [SerializeField] private Animator loseAnim;

    public void Lose()
    {

        SceneManager.LoadScene("Scene_0");
        SettingParameter.lose = false;
        loseAnim.SetBool("Lose", false);
        SettingParameter.Points = 0;
    }

    private void FixedUpdate()
    {
        if (SettingParameter.lose == true)
        {
            loseAnim.SetBool("Lose", true);
        }
    }
}
