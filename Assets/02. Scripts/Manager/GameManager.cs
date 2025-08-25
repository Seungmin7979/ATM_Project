using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userData;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI cashText;
    [SerializeField] private TextMeshProUGUI balanceText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        userData = new UserData("½Å½Â¹Î", 100000, 50000);
    }

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        nameText.text = userData.UserName;
        cashText.text = userData.cash.ToString("N0");
        balanceText.text = userData.bankBalance.ToString("N0");
    }
}
