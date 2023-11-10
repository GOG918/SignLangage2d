using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class Alphabet : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject Finish;
    [SerializeField] private GameObject Step1;
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;
    [SerializeField] private Button suivant;
    [SerializeField] private Button Play;
    [SerializeField] private Button quit;
    [SerializeField] private Text suivantText;
    [SerializeField]private Text AlphabetText;
    [SerializeField] private Text Score;
    [SerializeField] private Text Etat;
    [SerializeField] private Text FinishScore;
    [SerializeField] private Text NonFinishScore;
    [SerializeField] private Sprite[] Images;
    
    string[] Alphabets = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W","X", "Y", "Z"};
    List<String> AlphabetUse = new List<string>();
    List<string> AlphabetMelange = new List<string>();
    private int score;
    private IEnumerator coroutine;
    private bool Gamefinish;
    private Button correctButton;
    private Color ButtonInitColor= Color.white;

    // Start is called before the first frame update

     
    void Update()
    {
        
        if (Etat.text == "Vrai")
        {
            button1.interactable = false;
            button2.interactable = false;
            button3.interactable = false;
            suivant.interactable = true;
        }
        else if (Etat.text == "Faux")
        {
            button1.interactable = false;
            button2.interactable = false;
            button3.interactable = false;
            suivant.interactable = true;
            //suivantText.text = "Terminer";
        }
        if (Score.text == "100" || AlphabetUse.Count == 26)
        {
            suivantText.text = "Terminer";
            AlphabetUse.Clear();
        }  
    }

    public void MystartOnclick()
    {
        Buttoncolorinit(button1, button2, button3);
        if (suivantText.text == "suivant") {
            Mystart(0, 0, 0, 0, 0, 0);
        }else if(suivantText.text == "Terminer")
        {
            Finish.SetActive(true);
            FinishScore.text = Score.text;
            suivantText.text = "suivant";
        }
        Debug.Log(AlphabetUse.Count);
    }

    public void ChoiceButton(Button choiceButton)
    {
        if (suivantText.text == "suivant")
        {
            ButtonClick(choiceButton);
            Buttoncolor(choiceButton);
            suivant.interactable = false;
        }
        
    }

    public void home()
    {
        //Mystart(0, 0, 0, 0, 0, 0);
        score = 0;
        Score.text = score.ToString();
        suivantText.text = "suivant";
    }

    public void exit()
    {
        //Mystart(0, 0, 0, 0, 0, 0);
        score = 0;
        Score.text = score.ToString();
        suivantText.text = "suivant";
    }

    public void Mystart(int j,int  k, int l,int randomIndexAlphabet,int randomValue1, int randomValue2)
    {
        Etat.text = "";
        System.Random rng = new System.Random();
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;
        suivant.interactable = false;
        bool alphabetBool = false;

        //while (randomIndexAlphabet == randomValue1 || randomIndexAlphabet == randomValue2 || randomValue1 == randomValue2 || alphabetBool == false)
        while (randomValue1 == randomValue2 || randomValue1== randomIndexAlphabet || randomValue2 == randomIndexAlphabet || alphabetBool == false)
        {
                randomIndexAlphabet = rng.Next(0, Alphabets.Length);
                randomValue1 = rng.Next(0, Alphabets.Length);
                randomValue2 = rng.Next(0, Alphabets.Length);

            if (!AlphabetUse.Contains(Alphabets[randomIndexAlphabet]))
            {
                AlphabetText.text = Alphabets[randomIndexAlphabet];
                AlphabetUse.Add(Alphabets[randomIndexAlphabet]);
                alphabetBool = true;
            }
            else
            {
                alphabetBool = false;
            }
        }
        

        int[] tab = { randomIndexAlphabet, randomValue1, randomValue2 };
        while (j == k || k == l || l == j )
        {
            l = rng.Next(0, tab.Length);
            j = rng.Next(0, tab.Length);
            k = rng.Next(0, tab.Length);
        }

        button1.image.sprite = Images[tab[l]];
        button2.image.sprite = Images[tab[j]];
        button3.image.sprite = Images[tab[k]];

        if (button1.image.sprite.name == AlphabetText.text)
        {
            correctButton = button1;
        }
        else if(button2.image.sprite.name == AlphabetText.text)
        {
            correctButton = button2;
        }
        else
        {
            correctButton = button3;
        }
    }

    public void ButtonClick(Button buttonclicked)
    {
        if (buttonclicked.image.sprite.name == AlphabetText.text)
        {
            score = 0;
            score = int.Parse(Score.text) + 5;
            Score.text = score.ToString();
            score = 0;
            Etat.text = "Vrai";
        }
        else
        {
            Etat.text = "Faux";
        }
    }

    public void Buttoncolor(Button buttonclicked)
    {
        Color red = Color.red;
        Color green = Color.green;

        if (buttonclicked == correctButton)
        {
            buttonclicked.image.color = green;
        }
        else
        {
            buttonclicked.image.color = red;
            correctButton.image.color = green;
        }
    }

    public void Buttoncolorinit(Button button1, Button button2, Button button3)
    {
        button1.image.color = ButtonInitColor;
        button2.image.color = ButtonInitColor;
        button3.image.color = ButtonInitColor;
    }

    public void initUseAlphabet()
    {
        AlphabetUse.Clear();
    }
 }
