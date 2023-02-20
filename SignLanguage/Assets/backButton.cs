using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backButton : MonoBehaviour
{
    [SerializeField] private Button backB;
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject IntroPanel;
    [SerializeField] private GameObject ChoicePanel;
    [SerializeField] private GameObject Animals;
    [SerializeField] private GameObject Alphabet;
    [SerializeField] private GameObject Numbers;
    [SerializeField] private GameObject HomeButton;
    GameObject[] panelTable = new GameObject[20];
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
        IntroPanel.SetActive(true);
        ChoicePanel.SetActive(false);
        Animals.SetActive(false);
        Alphabet.SetActive(false);
        Numbers.SetActive(false);
        HomeButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IntroPanel.activeSelf == false)
        {
            HomeButton.SetActive(true);
        }
        else
        {
            HomeButton.SetActive(false);
        }
        if(Panel.activeSelf == true)
        {
            backB.onClick.AddListener(()=>deactivatePanel(Panel));
        }

    }

    void deactivatePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
