using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ViewControllTools;

public class SecretCodeHandler : MonoBehaviour
{
    [SerializeField]
    private Text firstLetter, secondLetter, thirdLetter, fourthLetter, fifthLetter, sixthLetter;

    [SerializeField]
    private InputField[] codeInputs;

    private int selectedInput = 0;

    private PanelController panelController;

    public void ValidateCode()
    {
        //check code value and load next prefab
        if (firstLetter.text == "S" && secondLetter.text == "E" && thirdLetter.text == "C" && fourthLetter.text == "R" && fifthLetter.text == "E" && sixthLetter.text == "T")
        {
            ViewController.LoadViewWithIndex(21);
        }
        else
        {
            ResetCode();
        }
    }

    private void ResetCode()
    {
        for (int index = 0; index < 6; index++)
        {
            codeInputs[index].text = "";
        }
        selectedInput = 0;
        codeInputs[selectedInput].Select();
    }

    public void BackButton()
    {
        ViewController.LoadViewWithIndex(19);
    }


    // Start is called before the first frame update
    void Start()
    {
        panelController = GameObject.FindObjectOfType<PanelController>();
    }

    private void Update()
    {
        if (selectedInput < 6 && codeInputs[selectedInput].text.Length != 0)
        {
            selectedInput++;
            if (selectedInput < 6)
                codeInputs[selectedInput].Select();
        }
        else if (selectedInput < 6 && selectedInput > 0 && codeInputs[selectedInput - 1].text.Length == 0 && codeInputs[selectedInput].text.Length >= 1)
        {
            selectedInput--;
            codeInputs[selectedInput].Select();
        }

        if (selectedInput == 6 && codeInputs[5].text.Length == 0) selectedInput = 5;
    }
}
