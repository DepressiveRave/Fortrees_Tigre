using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintWordScript : MonoBehaviour
{
    private float timer = 0f;
    private float interval = 2f;
    private float duration = 6f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            Debug.LogError("Привет");
            timer = 0f;

            if (timer >= duration)
            {
                enabled = false; // Отключаем скрипт после завершения вывода "Привет" на протяжении 6 секунд
            }
        }
    }
}
