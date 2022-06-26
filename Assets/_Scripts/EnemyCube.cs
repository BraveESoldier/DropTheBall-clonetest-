using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : EnemyControls
{
    private int level;

    private void Start()
    {
        LevelCreate();
        LevelImage();
    }

    private void LevelCreate()
    {
        level = Random.Range(1, 4);
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

    public override void Update()
    {
        if (SettingParameter.isMoving == true)
        {
            SettingParameter.QuantityEnemy = 3;
            float step = speed * Time.deltaTime;//расстояние, которое нужно пройти в текущем кадре
            transform.position = Vector3.MoveTowards(transform.position, SettingParameter.destPos, step);//двигаем 

            StartCoroutine(BreakCoroutine());
            SettingParameter.destPos = SettingParameter.destPos + new Vector3(0, 1, 0);
        }
        transform.Rotate(0,0, 0.5f);


    }

}
