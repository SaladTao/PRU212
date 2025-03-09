using UnityEngine;
using UnityEngine.Events;

public class PlayerLevelSystem : MonoBehaviour
{
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int currentExp = 0;
    [SerializeField] private int expToNextLevel = 100; // EXP cơ bản cần cho cấp 2
    [SerializeField] private float expIncreasePerLevel = 1.5f; // Hệ số tăng EXP cần cho mỗi cấp

    public UnityEvent onLevelUp; // Sự kiện để kích hoạt hiệu ứng lên cấp (ví dụ: cập nhật UI, tăng chỉ số)

    public void AddExp(int amount)
    {
        currentExp += amount;
        Debug.Log($"Nhận được {amount} EXP. EXP hiện tại: {currentExp}/{expToNextLevel}");

        while (currentExp >= expToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        currentExp -= expToNextLevel;
        expToNextLevel = Mathf.RoundToInt(expToNextLevel * expIncreasePerLevel);

        Debug.Log($"Lên cấp! Cấp mới: {currentLevel}. Cấp tiếp theo cần {expToNextLevel} EXP.");

        // Kích hoạt sự kiện lên cấp (ví dụ: cho UI, hiệu ứng âm thanh, tăng chỉ số)
        onLevelUp?.Invoke();
    }

    // Phương thức getter cho UI hoặc debug
    public int GetCurrentLevel() => currentLevel;
    public int GetCurrentExp() => currentExp;
    public int GetExpToNextLevel() => expToNextLevel;
}