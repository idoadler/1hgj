using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardManager parent;
    public int id;
    public Image arrow;
    public Image plus;
    public Image num;

    public void Activate()
    {
        parent.Activate(id);
    }
}
