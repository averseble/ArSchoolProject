using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class DotsTextScript : MonoBehaviour
{
    public GameObject[] dots;
    Text[] texts;
    public Canvas canvas;
    public Text textPrefabForLetters;
    public Text textPrefabForNumbers;

    public GameObject TargetImage;

    void Start()
    {
        texts = new Text[dots.Length];
        for(int i = 0; i < dots.Length; i++)
        {
            if (dots[i].tag == "num" && textPrefabForNumbers != null)
            {
                texts[i] = Instantiate(textPrefabForNumbers, this.transform.position, Quaternion.identity);
            }
            else
            {
                texts[i] = Instantiate(textPrefabForLetters, this.transform.position, Quaternion.identity);
            }          
            texts[i].text = dots[i].name;
            texts[i].transform.parent = canvas.transform;
            
        }
    }

    void Update()
    {
        for (int i = 0; i < dots.Length; i++)
        {
            Vector3 worldPos = new Vector3(dots[i].transform.position.x, dots[i].transform.position.y, dots[i].transform.position.z);
            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

            texts[i].transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);
            //если нет target то текст не отображается
            texts[i].gameObject.SetActive(TargetImage.GetComponent<IsDetectedTarget>().IsDetected());
           
        }
       
    }
}
