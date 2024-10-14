using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMergeSystem : MonoBehaviour
{

    public Slot[] slots;
    private Slot originalSlot;

    private Vector3 _target;
    private ItemInfo carryingItem;
    private Dictionary<int, Slot> slotDictionary;


    private void Start()
    {
        slotDictionary = new Dictionary<int, Slot>();

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].id = i;
            slotDictionary.Add(i, slots[i]);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SendRayCast();
        }

        if (Input.GetMouseButton(0) && carryingItem)
        {
            OnItemSelected();
        }

        if (Input.GetMouseButtonUp(0))
        {
            //Drop item
            SendRayCast();
        }
    }

    void SendRayCast()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            var slot = hit.transform.GetComponent<Slot>();
            if (slot != null)
            {
                // Проверяем, что перетаскиваемый предмет существует
                if (carryingItem != null)
                {
                    // Проверяем, что слот не пустой и предмет в слоте совпадает с предметом, который перетаскиваем
                    if (slot.state == SlotState.Full && slot.currentItem.id == carryingItem.itemId)
                    {
                        // Объединяем башни только если предмет не достиг максимального уровня
                        if (carryingItem.itemId < carryingItem.Towers.Length - 1)
                        {
                            OnItemMergedWithTarget(slot.id);
                        }
                        else
                        {
                            Debug.Log("Cannot merge item at maximum level");
                            OnItemCarryFail();
                        }
                    }
                    // Перемещаем предмет в пустой слот
                    else if (slot.state == SlotState.Empty)
                    {
                        slot.CreateItem(carryingItem.itemId);
                        Destroy(carryingItem.gameObject);
                    }
                    // При других условиях сбрасываем предмет
                    else
                    {
                        OnItemCarryFail();
                    }
                }
                // Если предмета нет, пытаемся подобрать предмет из слота
                else if (slot.state == SlotState.Full)
                {
                    var itemGO = (GameObject)Instantiate(Resources.Load("TowerBuilder/ItemDummy"));
                    itemGO.transform.position = slot.transform.position;
                    itemGO.transform.localScale = Vector3.one * 1;

                    carryingItem = itemGO.GetComponent<ItemInfo>();
                    carryingItem.InitDummy(slot.id, slot.currentItem.id);

                    slot.ItemGrabbed();
                }
            }
        }
        else
        {
            // Сбрасываем предмет, если его нет и щелчок был за пределами слотов
            if (!carryingItem)
            {
                return;
            }
            OnItemCarryFail();
        }
    }

    void OnItemSelected()
    {
        _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _target.z = 0;
        var delta = 10 * Time.deltaTime;

        delta *= Vector3.Distance(transform.position, _target);
        carryingItem.transform.position = Vector3.MoveTowards(carryingItem.transform.position, _target, delta);
    }

    void OnItemMergedWithTarget(int targetSlotId)
    {
        var slot = GetSlotById(targetSlotId);
        Destroy(slot.currentItem.gameObject);

        slot.CreateItem(carryingItem.itemId + 1);

        Destroy(carryingItem.gameObject);
    }

    void OnItemCarryFail()
    {
        var slot = GetSlotById(carryingItem.slotId);
        slot.CreateItem(carryingItem.itemId);
        Destroy(carryingItem.gameObject);
    }

    public void PlaceItem()
    {
        if (AllSlotsOccupied())
        {
            Debug.Log("No empty slot available!");
            return;
        }

        var rand = UnityEngine.Random.Range(0, slots.Length);
        var slot = GetSlotById(rand);

        while (slot.state == SlotState.Full)
        {
            rand = UnityEngine.Random.Range(0, slots.Length);
            slot = GetSlotById(rand);
        }

        slot.CreateItem(0);
    }

    public bool AllSlotsOccupied()
    {
        foreach (var slot in slots)
        {
            if (slot.state == SlotState.Empty)
            {
                //empty slot found
                return false;
            }
        }
        //no slot empty 
        return true;
    }

    Slot GetSlotById(int id)
    {
        return slotDictionary[id];
    }
}
