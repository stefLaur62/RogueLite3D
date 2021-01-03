using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItemDescription : MonoBehaviour
{
    private Item item;
    [SerializeField]
    private Text[] text;

    public void AddText()
    {
        if (item != null)
        {
            for (int i = 0; i < item.buffs.Length && text.Length >= item.buffs.Length; i++)
            {
                text[i].text = item.buffs[i].attributes + ": " + item.buffs[i].value;
            }
        }
    }
    public void SetItem(Item _item)
    {
        item = _item;
        AddText();
    }
}
