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
    private PlayerMovment _player;
    [SerializeField]
    protected bool _run;





    void Awake()//������� ������������� ������
    {
        _food = 100;
        _water = 100;
        _stamina = 100;
        _bodyParts = new BodyPart[6];
    }

   
    void Update()
    {

        if (_food < 30)//����� �� ������
        {
            if (_stamina - (5 * Time.deltaTime)>=0)
            {
                _stamina-=5*Time.deltaTime;
            }
        }
        if (_water < 30)//����� �� �������������
        {
            if (_stamina - (5 * Time.deltaTime) >= 0)
            {
                _stamina -= 5 * Time.deltaTime;
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

        if (_player.IsRunning && _stamina - (10 * Time.deltaTime)>=0)//�������� ���� ���
        {
            _stamina -= 10 * Time.deltaTime;
        }
        else
        {
            if (_stamina + (2 * Time.deltaTime) <= 100)
            {
                _stamina += 2 * Time.deltaTime;
            }
        }
        if (_stamina + (2 * Time.deltaTime)<=100)
        {
            _stamina += 2 * Time.deltaTime;
        }
       
        if(_stamina > 20)
        {
            _run = true;
        }
        else
        {
            _run = false;
        }
        


        //���������������� ���������
        _staminaBar.fillAmount = _stamina / 100;
        _foodBar.fillAmount=_food / 100;
        _waterBar.fillAmount=_water / 100;
    }
    public bool Run
    {
        get { return _run; }
        set { _run = value; }
    }
}
