using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ViewControllTools;

public class FourDigitCodeController : MonoBehaviour
{
    [SerializeField]
    private InputField[] codeInputs;
    [SerializeField]
    private Text thousandsDigit, hundredsDigit, tensDigit, unitsDigit;

    private int selectedInput = 0;

    [SerializeField]
    private Text step;

    private PanelController panelController;

    public void ValidateCode()
    {
        //check code value and load next prefab
        if (thousandsDigit.text =="5" && hundredsDigit.text == "2" && tensDigit.text == "6" && unitsDigit.text == "0" &&  panelController.step == 5)
        {
            ViewController.LoadViewWithIndex(15);
        }
        else if (thousandsDigit.text == "7" && hundredsDigit.text == "2" && tensDigit.text == "1" && unitsDigit.text == "9" && panelController.step == 7)
        {
            ViewController.LoadViewWithIndex(19);
        }
        else 
        {
            ResetCode();
        }
    }

    private void ResetCode()
    {
        thousandsDigit.text = "";
        hundredsDigit.text = "";
        tensDigit.text = "";
        unitsDigit.text = "";
        selectedInput = 0;
        codeInputs[selectedInput].Select();
    }

    public void BackButton()
    {
        if (panelController.step == 5)
        {
            ViewController.LoadViewWithIndex(13);
        } else if (panelController.step == 7)
        {
            ViewController.LoadViewWithIndex(17);
        }
    }

    private void Start()
    {
        panelController = GameObject.FindObjectOfType<PanelController>();
        step.text = panelController.step + "/9";
    }

    private void Update()
    {
        if (selectedInput < 4 && codeInputs[selectedInput].text.Length != 0)
        {
            selectedInput++;
            if (selectedInput < 4 )
                codeInputs[selectedInput].Select();
        } else if (selectedInput < 4 && selectedInput > 0 && codeInputs[selectedInput - 1].text.Length == 0 && codeInputs[selectedInput].text.Length >= 1)
        {
            selectedInput--;
            codeInputs[selectedInput].Select();
        }

        if (selectedInput == 4 && codeInputs[3].text.Length == 0) selectedInput = 3;
    }
}
