using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{

    [SerializeField]
    private float _stamina;
    [SerializeField] 
    private float _food;
    [SerializeField] 
    private float _water;
    [SerializeField]
    private BodyPart[] _bodyParts;
  
   




    void Awake()//������� ������������� ������
    {
        _food = 100;
        _water = 100;
        _bodyParts = null;
        _stamina = 20;

    }


    void Update()
    {
        float staminaBuf = 8f;
        if (_food < 30)
        {
            staminaBuf -= 3f;
        }
        if (_water < 30)
        {
            staminaBuf -= 3f;
        }
        if (_food >= 0)//���������� ������
        {
            _food -= 0.5f * Time.deltaTime;
        }
        if (_water >= 0)//���������� �����
        {
            _water -= 0.5f * Time.deltaTime;
        }
        if (_stamina < 100)//���������� �������
        {
            _stamina += staminaBuf * Time.deltaTime;
        }
    }
}
