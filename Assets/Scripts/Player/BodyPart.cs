using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    private GameObject _part;
    private float _health;
    BodyPart()
    {
        this._health = 100f;
        this._part = null;
    }
    public GameObject Part
    {
    get { return _part; } 
    set { _part = value; }
    }
    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }
}
