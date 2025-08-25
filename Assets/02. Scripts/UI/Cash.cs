using TMPro;
using UnityEngine;

public class Cash : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cashBalance;
    private int currentCash = 100000;

    private void Start()
    {
        cashBalance.text = currentCash.ToString("N0");
    }
}
