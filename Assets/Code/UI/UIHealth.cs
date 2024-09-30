using UnityEngine;
using Zenject;

public class UIHealth : MonoBehaviour
{
    [Inject] HeartSystem heartSystem;
    [SerializeField] GameObject[] Heart;
    
    private void OnEnable()
    {
        heartSystem.OnHealthChange += ChangeHeart;
    }

    private void OnDisable()
    {
        heartSystem.OnHealthChange -= ChangeHeart;
    }

    private void ChangeHeart(int health)
    {
        if (health >= 0 && health < Heart.Length)
        {
            // Отключаем сердца начиная с конца массива, пока не достигнем нового значения здоровья
            for (int i = Heart.Length - 1; i >= health; i--)
            {
                Heart[i].SetActive(false);
            }
        }
    }
}
