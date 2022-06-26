using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] protected TextMesh TM;

    protected float speed = 2.0f;
    public Vector3 destPos;


    public virtual void Update()
    {
        if (SettingParameter.isMoving == true)
        {
            SettingParameter.QuantityEnemy = 3;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, SettingParameter.destPos, step); 

            StartCoroutine(BreakCoroutine());
            SettingParameter.destPos = SettingParameter.destPos + new Vector3(0, 1, 0);
        }
    }

    protected IEnumerator BreakCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SettingParameter.isMoving = false;

    }

    private void OnTriggerEnter2D(Collider2D Coll)
    {
        if(Coll.gameObject.tag == "LoseBorder")
        {
            SettingParameter.lose = true;
        }
    }

    private void FixedUpdate()
    {
        print(SettingParameter.isMoving);
    }
}
