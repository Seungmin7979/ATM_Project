using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UserData userData;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI cashText;
    [SerializeField] private TextMeshProUGUI balanceText;

    private string savePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            savePath = Path.Combine(Application.persistentDataPath, "userdata.json");

            LoadUserData();
        }

        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        Refresh();
    }

    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData, true);
        File.WriteAllText(savePath, json);

        Debug.Log("저장완료: " + savePath);
    }

    public void LoadUserData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userData = JsonUtility.FromJson<UserData>(json);
            Debug.Log("로드 완료: " + savePath);
        }

        else
        {
            userData = new UserData("신승민", 100000, 50000);
            SaveUserData();
        }
    }

    public void Refresh()
    {
        nameText.text = userData.UserName;
        cashText.text = userData.cash.ToString("N0");
        balanceText.text = userData.bankBalance.ToString("N0");
    }
}
