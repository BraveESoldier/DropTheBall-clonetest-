using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour
{
    static private CreateBall S;

    [Header("Set in Inspector")]
    [SerializeField] private GameObject prefabPlayerProjectile;
    private float velocityMult = 8f;

    [SerializeField] private GameObject LaunchPoint;
    private Vector3 LaunchPos;
    private bool AimingMode;
    private GameObject PlayerProjectile;
    private Rigidbody2D projectileRigidbody2D;

    static public Vector3 LAUNCH_POS
    {
        get
        {
            if (S == null) return Vector3.zero;
            return S.LaunchPos;
        }
    }

    private void Awake()
    {
        S = this;
        Transform LaunchPointTrans = transform.Find("LaunchPoint");
        LaunchPoint = LaunchPointTrans.gameObject;
        LaunchPoint.SetActive(false);
        LaunchPos = LaunchPointTrans.position;
    }

    void OnMouseEnter()
    {
        print("PlayerBallController:OnMouseEnter()");
        LaunchPoint.SetActive(true);
    }

    void OnMouseExit()
    {
        print("PlayerBallController:OnMpuseExit()");
        LaunchPoint.SetActive(false);
    }

    void OnMouseDown()
    {
        if(SettingParameter.lose == false)
        {
            if (SettingParameter.shotFired == false)
            {
                AimingMode = true;
                //Создать снаряд 
                PlayerProjectile = Instantiate(prefabPlayerProjectile) as GameObject;
                //Поместить в точку LaunchPoint
                PlayerProjectile.transform.position = LaunchPos;
                //Сделать его кинематическим
                projectileRigidbody2D = PlayerProjectile.GetComponent<Rigidbody2D>();
                projectileRigidbody2D.isKinematic = true;
            }
        }
    }

    private void Update()
    {
        if (!AimingMode) return;

        //Получить текущие экранные координаты указателя мыши
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        //Найти разность координат между LaunchPos и mousePos3D
        Vector3 mouseDelta = mousePos3D - LaunchPos;
        float maxMagnitube = this.GetComponent<CircleCollider2D>().radius;
        if (mouseDelta.magnitude > maxMagnitube)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitube;
        }

        Vector3 projPos = LaunchPos + mouseDelta;
        PlayerProjectile.transform.position = projPos;
        if (Input.GetMouseButtonUp(0))
        {
            AimingMode = false;
            projectileRigidbody2D.isKinematic = false;
            projectileRigidbody2D.velocity = -mouseDelta * velocityMult;
            PlayerProjectile = null;
            SettingParameter.shotFired = true;
        }
    }
}
