using UnityEngine;

public class Dropexp : MonoBehaviour
{
    public GameObject expPrefab; // Prefab của EXP
    public int expAmount = 10;   // Số EXP rơi ra

    private void OnMouseDown()
    {
        Die();
    }

    private void Die()
    {
        DropExp();
        Destroy(gameObject);
    }

    private void DropExp()
    {
        if (expPrefab != null)
        {
            Vector3 dropPosition = transform.position + new Vector3(0, 0.5f, 0);
            Instantiate(expPrefab, dropPosition, Quaternion.identity);
        }
    }
}