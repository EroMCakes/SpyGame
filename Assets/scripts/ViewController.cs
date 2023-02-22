using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ViewControllTools
{
    public class ViewController : MonoBehaviour { 

        private static PanelController panelController;

        public static void LoadViewWithIndex(
            int viewIndex
        )
        {
            panelController = FindObjectOfType<PanelController>();

            var canvas = panelController.mainCanvas;
            if (canvas.transform.childCount > 0)
            {
                Destroy(canvas.transform.GetChild(0).gameObject);
            }
            if (panelController.language == "french"){
                Instantiate(panelController.panelPrefabs[viewIndex])
                .transform
                .SetParent(canvas.transform, false);
            } else
            {
                Instantiate(panelController.englishPrefabs[viewIndex])
                .transform
                .SetParent(canvas.transform, false);
            }
            if (viewIndex == 13)
            {
                panelController.step = 5;
            } else if (viewIndex == 17)
            {
                panelController.step = 7;
            }
        }

        public static void DestroyCurrentViewPanel()
        {
            var canvas = panelController.mainCanvas;
            Destroy(canvas.transform.GetChild(0).gameObject);
        }

        public void SelectLanguage(string language)
        {
            panelController.language = language;
            DestroyCurrentViewPanel();
            LoadViewWithIndex(2);
        }

        // Start is called before the first frame update
        void Start()
        {
            panelController = GameObject.FindObjectOfType<PanelController>();
        }
    }
}