using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ViewControllTools;

public class FinalCodeHandler : MonoBehaviour
{

    [SerializeField]
    private InputField victim, position;

    private PanelController panelController;

    public void Reset()
    {
        victim.text = "";
        position.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        panelController = GameObject.FindObjectOfType<PanelController>();   
    }

    public void CodeValidate()
    {
        if (victim.text == "008" && position.text == "4")
        {
            ViewController.LoadViewWithIndex(24);
        } else
        {
            Reset();
        }
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (victim.text == "008" && position.text == "4")
    //    {
    //        ViewController.LoadViewWithIndex(22);
    //    } else
    //    {
    //        Reset();
    //    }
    //}
}
