using UnityEngine;


public class RandomEvent : MonoBehaviour
{
    [Header("��������")]
    public GameObject[] spawnables;
    public int maxObjects = 10;
    public float spawnXMin = -5f;
    public float spawnXMax = 5f;
    public float minY = 0f;
    public float maxY = 0f;

    [Header("ʱ����")]
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;

    private float timer;

    void Update()
    {
        // ʱ���ۼ���
        timer += Time.deltaTime;

        if (timer >= GetRandomDelay())
        {
            timer = 0f; // ���ü�ʱ��

            if (spawnables.Length == 0) return;

            GameObject selected = spawnables[Random.Range(0, spawnables.Length)];

            // λ�������߼�
            float randomX = Random.Range(spawnXMin, spawnXMax);
            float fixedY = (minY + maxY) / 2f;

            Vector2 spawnPos = new Vector2(randomX, fixedY);

            // ���ص����
            bool validPosition = false;
            while (!validPosition)
            {
                validPosition = !Physics2D.OverlapCircle(spawnPos, 0.5f, ~LayerMask.GetMask("IgnoreSpawner"));
                if (!validPosition)
                {
                    randomX = Random.Range(spawnXMin, spawnXMax);
                    spawnPos = new Vector2(randomX, fixedY);
                }
            }

            Instantiate(selected, spawnPos, Quaternion.identity);
        }
    }

    private float GetRandomDelay()
    {
        return Random.Range(minSpawnDelay, maxSpawnDelay);
    }
}