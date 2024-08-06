using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    private GameObject _part;
    private float _health;


    private void Awake()
    {
        _health = 100;
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
