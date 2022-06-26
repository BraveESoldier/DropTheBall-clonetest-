using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallControll : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D Coll)
    {
        switch (Coll.gameObject.tag)
        {
            case "DestroyBall":
                SettingParameter.isMoving = true;
                SettingParameter.shotFired = false;
                SettingParameter.needCreate = true;
                Destroy(gameObject);
                break;
        }
    }
}
