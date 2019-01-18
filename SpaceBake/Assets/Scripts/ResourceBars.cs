using UnityEngine;
using UnityEngine.UI;

public class ResourceBars : MonoBehaviour
{
    [SerializeField] private float _aminoAcidAddedValue;
    private float _aminoAcidCurValue;
    private readonly float _aminoAcidMaxValue = 180;
    [SerializeField] private GameObject _aminoAcidSlider;
    [SerializeField] private float _ethanolAddedValue;
    private float _ethanolCurValue;
    private readonly float _ethanolMaxValue = 180;
    [SerializeField] private GameObject _ethanolSlider;
    [SerializeField] private float _foodAddedValue;
    private float _foodCurValue;
    private readonly float _foodMaxValue = 180;
    [SerializeField] private GameObject _foodSlider;
    [SerializeField] private float _waterAddedValue;
    private float _waterCurValue;
    private readonly float _waterMaxValue = 180;
    [SerializeField] private GameObject _waterSlider;

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

        _foodSlider.GetComponent<Image>().fillAmount = _foodCurValue / 180;
        _waterSlider.GetComponent<Image>().fillAmount = _waterCurValue / 180;
        _ethanolSlider.GetComponent<Image>().fillAmount = _ethanolCurValue / 180;
        _aminoAcidSlider.GetComponent<Image>().fillAmount = _aminoAcidCurValue / 180;
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
}