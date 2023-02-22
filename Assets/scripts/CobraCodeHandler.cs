using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ViewControllTools;

public class CobraCodeHandler : MonoBehaviour
{

    [SerializeField]
    private Text firstLetter, secondLetter, thirdLetter, fourthLetter, fifthLetter;

    [SerializeField]
    private InputField[] codeInputs;

    private int selectedInput = 0;

    private PanelController panelController;

    public void ValidateCode()
    {
        //check code value and load next prefab
        if (firstLetter.text == "C" && secondLetter.text == "O" && thirdLetter.text == "B" && fourthLetter.text == "R" && fifthLetter.text == "A")
        {
            ViewController.LoadViewWithIndex(11);
        }
        else
        {
            ResetCode();
        }
    }

    private void ResetCode()
    {
        for (int index = 0; index < 5; index++)
        {
            codeInputs[index].text = "";
        }
        selectedInput = 0;
        codeInputs[selectedInput].Select();
    }

    public void BackButton()
    {
        ViewController.LoadViewWithIndex(9);
    }

    // Start is called before the first frame update
    void Start()
    {
        panelController = GameObject.FindObjectOfType<PanelController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedInput < 5 && codeInputs[selectedInput].text.Length != 0)
        {
            selectedInput++;
            if (selectedInput < 5)
                codeInputs[selectedInput].Select();
        }
        else if (selectedInput < 5 && selectedInput > 0 && codeInputs[selectedInput - 1].text.Length == 0 && codeInputs[selectedInput].text.Length >= 1)
        {
            selectedInput--;
            codeInputs[selectedInput].Select();
        }
        if (selectedInput == 5 && codeInputs[4].text.Length == 0) selectedInput = 4;
    }
}
