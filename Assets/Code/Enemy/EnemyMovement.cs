using UnityEngine;
using Zenject;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    private Waypoints waypoints;
    private int waypointIndex = 0;
    [SerializeField] private Transform spriteRotate; // Add this line
    [Inject] HeartSystem heartSystem;
    [SerializeField] int Damage = 1;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        waypoints = FindObjectOfType<Waypoints>();

        if (waypoints != null && waypoints.waypoints.Length > 0)
        {
            transform.position = waypoints.waypoints[waypointIndex].transform.position;
        }
        else
        {
            Debug.LogError("No waypoints found or waypoints array is empty.");
            // Можно добавить логику для обработки отсутствия путевых точек
        }
    }

    private void OnDisable()
    {
        try
        {
            // При отключении монстра сбрасываем позицию и индекс путевых точек
            if (waypoints != null && waypoints.waypoints.Length > 0)
            {
                transform.position = waypoints.waypoints[0].transform.position;
                waypointIndex = 0;
            }
        }
        catch
        {
            Debug.Log("Enemy Back To Pool");
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // Проверяем, что есть путевые точки и индекс не выходит за пределы массива
        if (waypoints != null && waypointIndex < waypoints.waypoints.Length)
        {
            Vector3 targetPosition = waypoints.waypoints[waypointIndex].transform.position;

            // Перемещаем монстра к следующей путевой точке
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemy.GetSpeed() * Time.deltaTime);

            // Rotate the sprite based on the direction of movement
            if (targetPosition.x < transform.position.x)
            {
                spriteRotate.rotation = Quaternion.Euler(0, 0, 0); // Facing right
            }
            else if (targetPosition.x > transform.position.x)
            {
                spriteRotate.rotation = Quaternion.Euler(0, 180, 0); // Facing left
            }

            // Проверяем, достиг ли монстр текущей путевой точки
            if (Vector2.Distance(transform.position, targetPosition) <= 0.1f)
            {
                waypointIndex++;

                // Если достигнута последняя путевая точка, можно добавить дополнительную логику
                if (waypointIndex >= waypoints.waypoints.Length)
                {
                    heartSystem.ApplyDamage(Damage);
                    Destroy(gameObject);
                    Debug.Log("Enemy reached the end of waypoints.");
                }
            }
        }
    }
}
