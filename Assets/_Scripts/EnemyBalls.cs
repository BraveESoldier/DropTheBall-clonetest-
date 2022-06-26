using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBalls : EnemyControls
{
    private int level;

    private void Start()
    {
        LevelCreate();
        LevelImage();
    }

    private void LevelCreate()
    {
        level = Random.Range(1, 3);
    }

    private void LevelImage()
    {
        TM.text = level.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            level = level - 1;
            LevelImage();
            if (level == 0)
            {
                Destroy(gameObject);
                SettingParameter.Points++;
            }
        }
    }
}
