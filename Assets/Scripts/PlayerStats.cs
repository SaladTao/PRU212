using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    public int currentExp = 0;
    public int level = 1;
    public int expToNextLevel = 100; // EXP cần để lên level tiếp theo

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddExp(int amount)
    {
        currentExp += amount;
        Debug.Log($"Nhận {amount} EXP. Tổng EXP: {currentExp}/{expToNextLevel}");

        if (currentExp >= expToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        currentExp -= expToNextLevel;
        expToNextLevel = Mathf.RoundToInt(expToNextLevel * 1.2f); // Tăng dần EXP cần để lên cấp
        Debug.Log($"🎉 Level UP! Level hiện tại: {level}. EXP cần cho level tiếp theo: {expToNextLevel}");
    }
}
