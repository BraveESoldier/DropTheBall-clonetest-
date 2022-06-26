using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private GameObject prefabCirle;
    [SerializeField] private GameObject prefabSqare;
    [SerializeField] private GameObject A1;
    [SerializeField] private GameObject A2;
    [SerializeField] private GameObject A3;
    [SerializeField] private GameObject A4;
    [SerializeField] private GameObject A5;
    [SerializeField] private GameObject A6;
    [SerializeField] private GameObject A7;

    private Vector3 EnemyPos;
    private int ñubeChance;

    private void Start()
    {
        SpawnEnemy();
        print(SettingParameter.MainCount[0]);
    }

    private void SpawnEnemy()
    {
        RandonCoun();
        int Enemy1 = SettingParameter.MainCount[0];
        BindingSetup(Enemy1);
        Binding();
        int Enemy2 = SettingParameter.MainCount[1];
        BindingSetup(Enemy2);
        Binding();
        int Enemy3 = SettingParameter.MainCount[2];
        BindingSetup(Enemy3);
        Binding();
    }

    private void Binding()
    {
        int ñubeChance = Random.Range(0, 4);
        if (ñubeChance == 3)
        {
            Instantiate(prefabSqare, EnemyPos, Quaternion.identity);
        }
        else
        {
            Instantiate(prefabCirle, EnemyPos, Quaternion.identity);
        }
        SettingParameter.destPos = new Vector3(0, 0, 0);
    }

    private void BindingSetup(int Enemy)
    {
        Vector3 ration = new Vector3(0, 1, 0);
        switch (Enemy)
        {
            case 1:
                EnemyPos = A1.transform.position;
                SettingParameter.destPos = A1.transform.position + ration;
                Debug.Log(SettingParameter.destPos);
                Debug.Log(EnemyPos);
                break;
            case 2:
                EnemyPos = A2.transform.position;
                SettingParameter.destPos = A2.transform.position + ration;
                Debug.Log(SettingParameter.destPos);
                Debug.Log(EnemyPos);
                break;
            case 3:
                EnemyPos = A3.transform.position;
                SettingParameter.destPos = A3.transform.position + ration;
                Debug.Log(SettingParameter.destPos);
                Debug.Log(EnemyPos);
                break;
            case 4:
                EnemyPos = A4.transform.position;
                SettingParameter.destPos = A4.transform.position + ration;
                Debug.Log(SettingParameter.destPos);
                Debug.Log(EnemyPos);
                break;
            case 5:
                EnemyPos = A5.transform.position;
                SettingParameter.destPos = A5.transform.position + ration;
                Debug.Log(SettingParameter.destPos);
                Debug.Log(EnemyPos);
                break;
            case 6:
                EnemyPos = A6.transform.position;
                SettingParameter.destPos = A6.transform.position + ration;
                Debug.Log(EnemyPos);
                Debug.Log(SettingParameter.destPos);
                break;
            case 7:
                EnemyPos = A7.transform.position;
                SettingParameter.destPos = A7.transform.position + ration;
                Debug.Log(EnemyPos);
                Debug.Log(SettingParameter.destPos);
                break;
        }
    }

    private void RandonCoun()
    {
        SettingParameter.MainCount = UniqeRandomArray(3, 1, 8);
        var rr = string.Join(" ", SettingParameter.MainCount);
        Debug.Log(rr);
        Debug.Log(ñubeChance);
    }

    //ooooyeeee
    public int[] UniqeRandomArray(int size, int Min, int Max)
    {

        int[] UniqueArray = new int[size];
        System.Random rnd = new System.Random();
        int CountRnd;

        for (int i = 0; i < size; i++)
        {

            CountRnd = rnd.Next(Min, Max);

            for (int j = i; j >= 0; j--)
            {

                if (UniqueArray[j] == CountRnd)
                { CountRnd = rnd.Next(Min, Max); j = i; }

            }

            UniqueArray[i] = CountRnd;

        }
        return UniqueArray;

    }

    private IEnumerator NeedCreateCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SpawnEnemy();
    }

    private void Update()
    {
        if(SettingParameter.needCreate == true)
        {
            SettingParameter.needCreate = false;
            StartCoroutine(NeedCreateCoroutine());
        }
    }

}
