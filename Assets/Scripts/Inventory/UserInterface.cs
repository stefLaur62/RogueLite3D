using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public abstract class UserInterface : MonoBehaviour
{
    public InventoryObject inventory;
    protected Dictionary<GameObject, InventorySlot> slotsOnInterface = new Dictionary<GameObject, InventorySlot>();

    private PlayerActionControls playerActionControls;
    [SerializeField]
    private GameObject displayItemDescriptionPrefab;
    private GameObject tempDisplay;
    void Start()
    {
        for (int i = 0; i < inventory.container.items.Length; i++)
        {
            inventory.container.items[i].parent = this;
        }
        CreateSlot();
        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });
    }

    void Update()
    {
        //move it later outside update to when inventory open
        UpdateSlots();
    }

    private void Awake()
    {
        playerActionControls = new PlayerActionControls();
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }
    public abstract void CreateSlot();

    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> slot in slotsOnInterface)
        {
            if (slot.Value.item.id >= 0)
            {
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = slot.Value.ItemObject.uiDisplay;
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                slot.Key.transform.GetComponentInChildren<TextMeshProUGUI>().text = slot.Value.amount == 1 ? "" : slot.Value.amount.ToString("n0");
            }
            else
            {
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                slot.Key.transform.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }
    
    public void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }
    public void OnEnter(GameObject obj)
    {
        MouseData.slotHover = obj;
        DisplayItemBuffs(obj);
        
    }

    private void DisplayItemBuffs(GameObject obj)
    {
        tempDisplay = Instantiate(displayItemDescriptionPrefab, transform.parent.position, Quaternion.identity);
        tempDisplay.transform.SetParent(gameObject.transform);
        tempDisplay.transform.position = new Vector3(736, 437, 0);
        tempDisplay.GetComponent<DisplayItemDescription>().SetItem(slotsOnInterface[obj].item);
    }

    public void OnExit(GameObject obj)
    {
        MouseData.slotHover = null;
        Destroy(tempDisplay);
    }
    public void OnEnterInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = obj.GetComponent<UserInterface>();
        
    }
    public void OnExitInterface(GameObject obj)
    {
        //MouseData.interfaceMouseIsOver = null;
    }

    public void OnDragStart(GameObject obj)
    {
        Debug.Log("Drag start");
        Debug.Log(obj.name);
        MouseData.tempItem = createTempItem(obj);
    }

    public GameObject createTempItem(GameObject obj)
    {
        GameObject tempItem = null;
        if (slotsOnInterface[obj].item.id >= 0)
        {
            tempItem = new GameObject();
            var rt = tempItem.AddComponent<RectTransform>();
            rt.sizeDelta = new Vector2(60, 60);
            tempItem.transform.SetParent(transform.parent);
            var img = tempItem.AddComponent<Image>();
            img.sprite = slotsOnInterface[obj].ItemObject.uiDisplay;
            img.raycastTarget = false;
        }
        return tempItem;
    }

    public void OnDragEnd(GameObject obj)
    {
        Destroy(MouseData.tempItem);
        if(MouseData.interfaceMouseIsOver == null)
        {
            slotsOnInterface[obj].RemoveItem();
            return;
        }
        if (MouseData.slotHover)
        {
            InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.slotsOnInterface[MouseData.slotHover];
            inventory.SwapItems(slotsOnInterface[obj], mouseHoverSlotData);
        }

    }

    public void OnDrag(GameObject obj)
    {
        if (MouseData.tempItem != null)
            MouseData.tempItem.GetComponent<RectTransform>().position = playerActionControls.Player.MousePosition.ReadValue<Vector2>();
    }  
}