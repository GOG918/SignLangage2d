using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


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
    [SerializeField] private Text suivantText;
    [SerializeField]private Text AlphabetText;
    [SerializeField] private Text Score;
    [SerializeField] private Text Etat;
    [SerializeField] private Text FinishScore;
    [SerializeField] private Text NonFinishScore;
    [SerializeField] private Sprite[] Images;
    System.Random rng = new System.Random();
    string[] Alphabets = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W","X", "Y", "Z" };
    List<String> AlphabetUse = new List<string>();
    List<string> AlphabetMelange = new List<string>();
    private int score;
    // Start is called before the first frame update
    void Start()
    { 
       if (suivantText.text == "suivant")
        {
            Play.onClick.AddListener(() => Mystart(0, 0, 0, 0, 0, 0));
            suivant.onClick.AddListener(() => Mystart(0, 0, 0, 0, 0, 0));
            button1.onClick.AddListener(() => ButtonClick(button1));
            button2.onClick.AddListener(() => ButtonClick(button2));
            button3.onClick.AddListener(() => ButtonClick(button3));
            suivant.interactable = false;
        }
       

    }
    
    // Update is called once per frame
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
            suivantText.text = "Terminer";
        }
        if (Score.text == "130")
        {
            suivantText.text = "Terminer";
        }
        if (suivantText.text == "Terminer")
        {
            suivantText.text = "suivant";
            Finish.SetActive(true);
            FinishScore.text = Score.text;
        }
        if (suivantText.text == "suivant")
        {
            Play.onClick.AddListener(() => Mystart(0, 0, 0, 0, 0, 0));
            suivant.onClick.AddListener(() => Mystart(0, 0, 0, 0, 0, 0));
            button1.onClick.AddListener(() => ButtonClick(button1));
            button2.onClick.AddListener(() => ButtonClick(button2));
            button3.onClick.AddListener(() => ButtonClick(button3));
            suivant.interactable = false;
        }
    }
    
    public void Mystart(int j,int  k, int l,int randomIndexAlphabet,int randomValue1, int randomValue2)
    {
        Etat.text = "";
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;
        suivant.interactable = false;
        bool alphabetBool = false;
        
            while (randomIndexAlphabet == randomValue1 || randomIndexAlphabet == randomValue2 || randomValue1 == randomValue2 || alphabetBool == false)
        {
                randomIndexAlphabet = rng.Next(0, Alphabets.Length);
                randomValue1 = rng.Next(0, Alphabets.Length);
                randomValue2 = rng.Next(0, Alphabets.Length);
                if (!AlphabetUse.Contains(Alphabets[randomIndexAlphabet]))
                {
                    AlphabetText.text = Alphabets[randomIndexAlphabet];
                    AlphabetUse.Add(Alphabets[randomIndexAlphabet]);
                    alphabetBool = true;
                break;
            }
            else
            {
                alphabetBool = false;
                
            }
            }
        
        int[] tab = { randomIndexAlphabet, randomValue1, randomValue2 };
        while (j == k || k == l || l == j)
        {
            l = rng.Next(0, tab.Length);
            j = rng.Next(0, tab.Length);
            k = rng.Next(0, tab.Length);

        }
        button1.image.sprite = Images[tab[l]];
        button2.image.sprite = Images[tab[j]];
        button3.image.sprite = Images[tab[k]];
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

}
