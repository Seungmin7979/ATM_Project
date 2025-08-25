using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string UserName;
    public int cash;
    public int bankBalance;

    public UserData(string name, int cash, int bankBalance)
    {
        this.UserName = name;
        this.cash = cash;
        this.bankBalance = bankBalance;
    }
}
