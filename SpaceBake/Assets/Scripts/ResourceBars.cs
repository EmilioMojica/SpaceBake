using UnityEngine;
using UnityEngine.UI;

public class ResourceBars : MonoBehaviour
{
    private readonly float _aminoAcidMaxValue = 120;
    private readonly float _ethanolMaxValue = 120;
    private readonly float _oxygenMaxValue = 120;
    private readonly float _waterMaxValue = 120;
    [SerializeField] private readonly float _aminoAcidAddedValue = 20;
    private float _aminoAcidCurValue;
    [SerializeField] private GameObject _aminoAcidSlider;
    [SerializeField] private float _ethanolAddedValue = 20;
    private float _ethanolCurValue;
    [SerializeField] private GameObject _ethanolSlider;
    [SerializeField] private readonly float _foodAddedValue = 20;

    private float _gameLoseLives = 2;

    private float _gameWinTimer;
    private float _oxygenCurValue;
    [SerializeField] private GameObject _oxygenSlider;
    [SerializeField] private readonly float _waterAddedValue = 20;
    private float _waterCurValue;
    [SerializeField] private GameObject _waterSlider;

    [SerializeField] private Slider _winSlider;

    // Use this for initialization
    private void Start()
    {
        _oxygenCurValue = Random.Range(80f, 120);
        _waterCurValue = Random.Range(80f, 120);
        _ethanolCurValue = Random.Range(80f, 120);
        _aminoAcidCurValue = Random.Range(80f, 120);
    }

    // Update is called once per frame
    private void Update()
    {
        _winSlider.value = _gameWinTimer / 180;

        calculateBarValues();
        CalculateWin();

        _oxygenSlider.GetComponent<Image>().fillAmount = _oxygenCurValue / 120;
        _waterSlider.GetComponent<Image>().fillAmount = _waterCurValue / 120;
        _ethanolSlider.GetComponent<Image>().fillAmount = _ethanolCurValue / 120;
        _aminoAcidSlider.GetComponent<Image>().fillAmount = _aminoAcidCurValue / 120;
    }

    public void AddO2()
    {
        _oxygenCurValue += _foodAddedValue;
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
        if (_oxygenCurValue >= _oxygenMaxValue)
        {
            _oxygenCurValue = _oxygenMaxValue;
        }
        else if (_oxygenCurValue <= 0)
        {
            _gameLoseLives++;
            _oxygenCurValue = _oxygenMaxValue;
        }

        if (_waterCurValue >= _waterMaxValue)
        {
            _waterCurValue = _waterMaxValue;
        }
        else if (_waterCurValue <= 0)
        {
            _gameLoseLives++;
            _waterCurValue = _waterMaxValue;
        }

        if (_ethanolCurValue >= _ethanolMaxValue)
        {
            _ethanolCurValue = _ethanolMaxValue;
        }
        else if (_ethanolCurValue <= 0)
        {
            _gameLoseLives++;
            _ethanolCurValue = _ethanolMaxValue;
        }

        if (_aminoAcidCurValue >= _aminoAcidMaxValue)
        {
            _aminoAcidCurValue = _aminoAcidMaxValue;
        }
        else if (_aminoAcidCurValue <= 0)
        {
            _gameLoseLives++;
            _aminoAcidCurValue = _aminoAcidMaxValue;
        }

        _oxygenCurValue -= Time.deltaTime * 1;
        _waterCurValue -= Time.deltaTime * 0.75f;
        _ethanolCurValue -= Time.deltaTime * 0.25f;
        _aminoAcidCurValue -= Time.deltaTime * 0.5f;
    }

    private void CalculateWin()
    {
        _gameWinTimer += Time.deltaTime;

        if (_gameWinTimer >= 180)
        {
            if (_gameLoseLives >= 2)
                Debug.Log("You missed the good cake...");
            else
            {
                Debug.Log("This cake is huge!!!");
                _oxygenCurValue = _oxygenMaxValue;
                _aminoAcidCurValue = _aminoAcidMaxValue;
                _ethanolCurValue = _ethanolMaxValue;
                _waterCurValue = _waterMaxValue;
            }
        }
    }
}