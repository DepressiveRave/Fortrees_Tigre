using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public int slotId;
    public int itemId;
    public GameObject[] Towers;

    public void InitDummy(int slotId, int itemId)
    {
        this.slotId = slotId;
        this.itemId = itemId;
        Towers[itemId].SetActive(true);
        Towers[itemId].GetComponent<SpriteRenderer>().sortingOrder += 500;
        // Проверяем каждый дочерний объект на наличие компонента SpriteRenderer и увеличиваем sortingOrder
        foreach (Transform child in Towers[itemId].transform)
        {
            SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();
            if (childRenderer != null)
            {
                childRenderer.sortingOrder += 500;
            }
        }
    }
}