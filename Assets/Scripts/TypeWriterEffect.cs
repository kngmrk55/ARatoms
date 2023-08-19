using System.Collections;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 0.2f;
    private string elementName;
    private string currentText = "";


    void Start()
    {
        elementName = this.GetComponent<TMP_Text>().text;
    }

    public void StartC(){
        this.GetComponent<TMP_Text>().text = "";
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText(){
        for (int i=0; i<=elementName.Length; i++){
            currentText = elementName.Substring(0,i);
            this.GetComponent<TMP_Text>().text=currentText;
            yield return new WaitForSeconds(delay);
        }
        
    }
}
