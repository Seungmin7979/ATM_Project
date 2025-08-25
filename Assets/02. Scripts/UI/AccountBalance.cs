using TMPro;
using UnityEngine;

public class AccountBalance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI accountBalance;
    private int balance = 50000;

    private void Start()
    {
        accountBalance.text = balance.ToString("N0");
    }
}
