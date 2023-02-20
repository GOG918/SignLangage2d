using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Question",menuName ="ScriptableObjects/Question")]
public class QuestionSO : ScriptableObject
{
    public string question;
    public Sprite questionImage;
    public List<Response> responses;

}
[System.Serializable]
public class Response
{
    public Sprite responseImage;
    public bool isCorrect;
}
