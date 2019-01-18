using UnityEngine;
using UnityEngine.UI;

public class ResourceBars : MonoBehaviour
{
    [SerializeField] private float _aminoAcidAddedValue;
    private float _aminoAcidCurValue;
    private readonly float _aminoAcidMaxValue = 120;
    [SerializeField] private GameObject _aminoAcidSlider;
    [SerializeField] private float _ethanolAddedValue;
    private float _ethanolCurValue;
    private readonly float _ethanolMaxValue = 120;
    [SerializeField] private GameObject _ethanolSlider;
    [SerializeField] private float _foodAddedValue;
    private float _foodCurValue;
    private readonly float _foodMaxValue = 120;
    [SerializeField] private GameObject _foodSlider;
    [SerializeField] private float _waterAddedValue;
    private float _waterCurValue;
    private readonly float _waterMaxValue = 120;
    [SerializeField] private GameObject _waterSlider;

    private float _gameWinTimer;

    // Use this for initialization
    private void Start()
    {
        _foodCurValue = _foodMaxValue;
        _waterCurValue = _waterMaxValue;
        _aminoAcidCurValue = _aminoAcidMaxValue;
        _ethanolCurValue = _ethanolMaxValue;
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
        if (_waterCurValue >= _waterMaxValue)
            _waterCurValue = _waterMaxValue;
        if (_ethanolCurValue >= _ethanolMaxValue)
            _ethanolCurValue = _ethanolMaxValue;
        if (_aminoAcidCurValue >= _aminoAcidMaxValue)
            _aminoAcidCurValue = _aminoAcidMaxValue;

        _foodCurValue -= Time.deltaTime;
        _waterCurValue -= Time.deltaTime;
        _ethanolCurValue -= Time.deltaTime;
        _aminoAcidCurValue -= Time.deltaTime;
    }

    void CalculateWin()
    {
        _gameWinTimer += Time.deltaTime;

        if (_gameWinTimer >= 180)
        {
            //TODO: Game win text.

        }
    }
}