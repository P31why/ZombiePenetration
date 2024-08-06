using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    private Image _staminaBar;
    [SerializeField]
    private Image _foodBar;
    [SerializeField]
    private Image _waterBar;
    [SerializeField]
    private float _staminaBuf = 6f;

    void Awake()//������� ������������� ������
    {
        _food = 100;
        _water = 100;
        _stamina = 20;
        _bodyParts = new BodyPart[6];
    }

    public float StaminaBuf
    {
        get { return _staminaBuf; }
        set { _staminaBuf = value; }

    }
    void Update()
    {

        if (_food < 30)//����� �� ������
        {
            if (_stamina >= 0 && _stamina - 3 >= 0)
            {
                _staminaBuf -= 3f;
            }
        }
        if (_water < 30)//����� �� �������������
        {
            if (_stamina >= 0 && _stamina-3>=0)
            {
                _staminaBuf -= 3f;
            }
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
            _stamina += _staminaBuf * Time.deltaTime;
        }
        //���������������� ���������
        _staminaBar.fillAmount = _stamina / 100;
        _foodBar.fillAmount=_food / 100;
        _waterBar.fillAmount=_water / 100;
    }
}
