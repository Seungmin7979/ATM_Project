using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    [SerializeField] private Button depositButton;
    [SerializeField] private Button withdrawalButton;

    [SerializeField] private Button depositBackButton;
    [SerializeField] private Button withdrawalBackButton;

    [SerializeField] private GameObject buttonController;

    [SerializeField] private GameObject deposit;
    [SerializeField] private GameObject withdrawal;

    [Header("Deposit")]
    [SerializeField] private Button deposit1;
    [SerializeField] private Button deposit2;
    [SerializeField] private Button deposit3;
    [SerializeField] private Button deposit4;
    [SerializeField] private Text inputDeposit;

    [Header("Withdrawal")]
    [SerializeField] private Button withdrawal1;
    [SerializeField] private Button withdrawal2;
    [SerializeField] private Button withdrawal3;
    [SerializeField] private Button withdrawal4;
    [SerializeField] private Text inputWithdrawal;

    [SerializeField] private GameObject errorPanel;
    [SerializeField] private Button exitButton;


    private void Start()
    {
        depositButton.onClick.AddListener(DepositButton);
        withdrawalButton.onClick.AddListener(WithdrawalButton);

        depositBackButton.onClick.AddListener(BackButton);
        withdrawalBackButton.onClick.AddListener(BackButton);

        deposit1.onClick.AddListener(() => Deposit(10000));
        deposit2.onClick.AddListener(() => Deposit(30000));
        deposit3.onClick.AddListener(() => Deposit(50000));
        deposit4.onClick.AddListener(InputDeposit);

        withdrawal1.onClick.AddListener(() => Withdrawal(10000));
        withdrawal2.onClick.AddListener(() => Withdrawal(30000));
        withdrawal3.onClick.AddListener(() => Withdrawal(50000));
        withdrawal4.onClick.AddListener(InputWithdrawal);

        exitButton.onClick.AddListener(ExitButton);
    }

    public void DepositButton()
    {
        deposit.SetActive(true);
        buttonController.SetActive(false);
    }

    public void WithdrawalButton()
    {
        withdrawal.SetActive(true);
        buttonController.SetActive(false);
    }

    public void BackButton()
    {
        deposit.SetActive(false);
        withdrawal.SetActive(false);
        buttonController.SetActive(true);
    }

    public void Deposit(int amount)
    {
        var info = GameManager.Instance.userData;

        if (info.cash >= amount)
        {
            info.cash -= amount;
            info.bankBalance += amount;

            GameManager.Instance.Refresh();
        }

        else
        {
            errorPanel.SetActive(true);
        }
    }

    public void Withdrawal(int amount)
    {
        var info = GameManager.Instance.userData;

        if (info.bankBalance >= amount)
        {
            info.bankBalance -= amount;
            info.cash += amount;

            GameManager.Instance.Refresh();
        }

        else
        {
            errorPanel.SetActive(true);
        }
    }

    public void InputDeposit()
    {
        if (int.TryParse(inputDeposit.text, out int amount) && amount > 0)
            Deposit(amount);

        else
            errorPanel.SetActive(true);
    }

    public void InputWithdrawal()
    {
        if (int.TryParse(inputWithdrawal.text, out int amount) && amount > 0)
            Withdrawal(amount);

        else
            errorPanel.SetActive(true);
    }

    public void ExitButton()
    {
        buttonController.SetActive(true);
        deposit.SetActive(false);
        withdrawal.SetActive(false);
        errorPanel.SetActive(false);
    }
}
