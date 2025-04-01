using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialougManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text setencetext;
    public Text nextText;
    
    // Start is called before the first frame update
    void Start()
    {
      
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    public void startDialoug(Dialoug dialoug)
    {
        sentences.Clear();
        foreach (string sentence in dialoug.sentences)
        {
            sentences.Enqueue(sentence);
        }
        displaysentence();
    }
   public void displaysentence()
    {
        if (sentences.Count == 0)
        {
            EndDialoug();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(SentencesLetter(sentence));
    }
    IEnumerator SentencesLetter(string Sentence)
    {
        setencetext.text = "";
        foreach (char letter  in Sentence.ToCharArray())
        {
            setencetext.text += letter;
            yield return null;
        }
    }
    void EndDialoug()
    {
        nextText.text = "End";
        setencetext.text = "";
    }
}
