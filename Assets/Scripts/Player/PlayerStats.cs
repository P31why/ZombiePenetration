using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEditor;
using UnityEditor.Rendering;
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
    private bool _run;
    private System.Timers.Timer _runTimer;
    private bool _readyToRun;
    



    void Awake()//базовая инициализация статов
    {
        _food = 100;
        _water = 100;
        _stamina = 100;
        _bodyParts = new BodyPart[6];
        _runTimer = new System.Timers.Timer();
        _runTimer.Interval = 5000;
        _runTimer.Elapsed += OnTimedEvent;
        _readyToRun = true;
    }

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        _run = true;
        _readyToRun = true;
    }


    void Update()
    {

        if (_food < 30)//дебаф от голода
        {
            if (_stamina - (5 * Time.deltaTime)>=0)
            {
                _stamina-=5*Time.deltaTime;
            }
        }
        if (_water < 30)//дебаф от обезвоживания
        {
            if (_stamina - (5 * Time.deltaTime) >= 0)
            {
                _stamina -= 5 * Time.deltaTime;
            }
        }
        if (_food >= 0)//уменьшение голода
        {
            _food -= 0.5f * Time.deltaTime;
        }
        if (_water >= 0)//уменьшение жажды
        {
            _water -= 0.5f * Time.deltaTime;
        }

        if (_player.IsRunning && _stamina - (10 * Time.deltaTime)>=0)//проверка если бег
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



        //бег
        if (_stamina>20 && _readyToRun)
        {
            _run = true;
        }
        else
        {
            _run = false;
            _readyToRun = false;
            _runTimer.Start();
        }
       


        //пользовательский интерфайс
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
