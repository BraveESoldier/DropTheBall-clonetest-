using UnityEngine;
using TMPro;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text TMPPoints;

    private void FixedUpdate()
    {
        TMPPoints.text = "Your points: " + SettingParameter.Points.ToString();
    }
}
