using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public Slot parentSlot;
    public GameObject[] Towers;

    private int _startSortOrder;

    private void Awake()
    {
        _startSortOrder = Towers[id].GetComponent<SpriteRenderer>().sortingOrder;
    }

    public void Init(int id, Slot slot)
    {
        this.id = id;
        this.parentSlot = slot;
        Towers[id].SetActive(true);
        if (Towers[id].GetComponent<SpriteRenderer>().sortingOrder > _startSortOrder)
        {
            Towers[id].GetComponent<SpriteRenderer>().sortingOrder -= 500;

            // Проверяем каждый дочерний объект на наличие компонента SpriteRenderer и увеличиваем sortingOrder
            foreach (Transform child in Towers[id].transform)
            {
                SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();
                if (childRenderer != null)
                {
                    childRenderer.sortingOrder -= 500;
                }
            }
        }
    }
}
