using UnityEngine;
using UnityEngine.UI;

public class ResourceBars : MonoBehaviour
{
    [SerializeField] private float _aminoAcidAddedValue = 20;
    private float _aminoAcidCurValue;
    private readonly float _aminoAcidMaxValue = 120;
    [SerializeField] private GameObject _aminoAcidSlider;
    [SerializeField] private float _ethanolAddedValue = 20;
    private float _ethanolCurValue;
    private readonly float _ethanolMaxValue = 120;
    [SerializeField] private GameObject _ethanolSlider;
    [SerializeField] private float _foodAddedValue = 20;
    private float _foodCurValue;
    private readonly float _foodMaxValue = 120;
    [SerializeField] private GameObject _foodSlider;
    [SerializeField] private float _waterAddedValue = 20;
    private float _waterCurValue;
    private readonly float _waterMaxValue = 120;
    [SerializeField] private GameObject _waterSlider;

    private float _gameWinTimer;

    private float _gameLoseLives = 2;

    // Use this for initialization
    private void Start()
    {
        _foodCurValue = Random.Range(80f, 120);
        _waterCurValue = Random.Range(80f, 120);
        _ethanolCurValue = Random.Range(80f, 120);
        _aminoAcidCurValue = Random.Range(80f, 120);
    }

    // Update is called once per frame
    private void Update()
    {
        calculateBarValues();
        CalculateWin();

        _foodSlider.GetComponent<Image>().fillAmount = _foodCurValue / 120;
        _waterSlider.GetComponent<Image>().fillAmount = _waterCurValue / 120;
        _ethanolSlider.GetComponent<Image>().fillAmount = _ethanolCurValue / 120;
        _aminoAcidSlider.GetComponent<Image>().fillAmount = _aminoAcidCurValue / 120;
    }

    public void AddO2()
    {
        _foodCurValue += _foodAddedValue;
    }

    public void AddH2O()
    {
        _waterCurValue += _waterAddedValue;
    }

    public void AddC2H5OH()
    {
        _ethanolCurValue += _ethanolMaxValue;
    }

    public void AddC2H3NO2()
    {
        _aminoAcidCurValue += _aminoAcidAddedValue;
    }

    private void calculateBarValues()
    {
        if (_foodCurValue >= _foodMaxValue)
            _foodCurValue = _foodMaxValue;
        else if (_foodCurValue <= 0)
        {
            _gameLoseLives++;
            _foodCurValue = _foodMaxValue;
        }
        if (_waterCurValue >= _waterMaxValue)
            _waterCurValue = _waterMaxValue;
        else if (_foodCurValue <= 0)
        {
            _gameLoseLives++;
            _waterCurValue = _waterMaxValue;
        }
        if (_ethanolCurValue >= _ethanolMaxValue)
            _ethanolCurValue = _ethanolMaxValue;
        else if (_foodCurValue <= 0)
        {
            _gameLoseLives++;
            _ethanolCurValue = _ethanolMaxValue;
        }
        if (_aminoAcidCurValue >= _aminoAcidMaxValue)
            _aminoAcidCurValue = _aminoAcidMaxValue;
        else if (_foodCurValue <= 0)
        {
            _gameLoseLives++;
            _aminoAcidCurValue = _aminoAcidMaxValue;
        }

        _foodCurValue -= Time.deltaTime * 2.0f;
        _waterCurValue -= Time.deltaTime * 1.25f;
        _ethanolCurValue -= Time.deltaTime * 0.5f;
        _aminoAcidCurValue -= Time.deltaTime * 0.75f;
    }

    void CalculateWin()
    {
        _gameWinTimer += Time.deltaTime;

        if (_gameWinTimer >= 180)
        {
            if (_gameLoseLives >= 2)
                Debug.Log("You missed the good cake...");
            else
                Debug.Log("This cake is huge!!!");
        }
    }
}