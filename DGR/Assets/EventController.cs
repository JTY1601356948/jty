using UnityEngine;

public class EventController : MonoBehaviour
{
    public enum EventType { Fire, Bandit, Treasure, None }

    [System.Serializable]
    public class SpawnPointConfig
    {
        [Header("λ������")]
        public Transform position;

        [Header("�¼�����")]
        public EventType eventType;

        [Header("����Ԥ����")]
        public GameObject prefab;
    }

    [Header("�¼�����")]
    public SpawnPointConfig[] spawnPoints;

    [Header("���ɲ���")]
    public float spawnRadius = 1f;
    public LayerMask obstacleLayer;

    void Start()
    {
        SpawnPointConfig selectedPoint = GetRandomValidPoint();
        if (selectedPoint != null && selectedPoint.eventType != EventType.None)
        {
            ExecuteEvent(selectedPoint);
        }
    }

    private SpawnPointConfig GetRandomValidPoint()
    {
        var validPoints = new System.Collections.Generic.List<SpawnPointConfig>();
        foreach (var point in spawnPoints)
        {
            if (point.position != null && !CheckObstacleAtPosition(point.position.position))
            {
                validPoints.Add(point);
            }
        }
        return validPoints.Count > 0 ? validPoints[Random.Range(0, validPoints.Count)] : null;
    }

    private bool CheckObstacleAtPosition(Vector2 position)
    {
        Collider2D hit = Physics2D.OverlapCircle(position, spawnRadius, obstacleLayer);
        return hit != null;
    }

    private void ExecuteEvent(SpawnPointConfig config)
    {
        if (config.prefab != null)
        {
            Instantiate(config.prefab, config.position.position, Quaternion.identity);
        }

        // �����Ҫ�����¼��߼������ڴ���ӣ�
        switch (config.eventType)
        {
            case EventType.Fire:
                Debug.Log("���������¼�");
                break;
            case EventType.Bandit:
                Debug.Log("���������¼�");
                break;
        }
    }
}
