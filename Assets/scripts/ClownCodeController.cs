using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ViewControllTools;

public class ClownCodeController : MonoBehaviour
{
    [SerializeField]
    private Text greenDigit, redDigit, blueDigit;

    [SerializeField]
    private InputField[] codeInputs;

    private PanelController panelController;

    private int selectedInput = 0;


    public void ResetCode()
    {
        for (int index = 0; index < 3; index ++)
        {
            codeInputs[index].text = "";
        }
        selectedInput = 0;
        codeInputs[selectedInput].Select();
    }

    public void BackButton()
    {
        ViewController.LoadViewWithIndex(5);
    }

    public void ValidateColorCode()
    {
        //check code value and load next prefab
        if (greenDigit.text == "7" && redDigit.text == "3" && blueDigit.text == "1")
        {
            ViewController.LoadViewWithIndex(7);
        }
        else
        {
            ResetCode();
        }
    }

    private void Start()
    {
        panelController = GameObject.FindObjectOfType<PanelController>();
    }

    private void Update()
    {
        if (selectedInput < 3 && codeInputs[selectedInput].text.Length != 0)
        {
            selectedInput++;
            if (selectedInput < 3)
                codeInputs[selectedInput].Select();
        }
        else if (selectedInput < 3 && selectedInput > 0 && codeInputs[selectedInput - 1].text.Length == 0 && codeInputs[selectedInput].text.Length >= 1)
        {
            selectedInput--;
            codeInputs[selectedInput].Select();
        }

        if (selectedInput == 3 && codeInputs[2].text.Length == 0) selectedInput = 2;
    }
}
