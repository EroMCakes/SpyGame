using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ViewControllTools;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    public GameObject[] panelPrefabs,englishPrefabs;

    [SerializeField]
    public string language = "french";

    public int step = 0;

    [SerializeField]
    public GameObject mainCanvas;

    private void Awake()
    {
        ViewController.LoadViewWithIndex(0);
    }
}
