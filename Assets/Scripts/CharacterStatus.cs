using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    // karakter durumlar�
    public float[] hunger = { 100f, 100f, 100f, 100f, 100f };
    public float[] thirst = { 100f, 100f, 100f, 100f, 100f };
    public float[] health = { 100f, 100f, 100f, 100f, 100f };
    public float[] mhealth = { 100f, 100f, 100f, 100f, 100f };
    public UnityEngine.UI.Image[] hungerBar = new UnityEngine.UI.Image[5];
    public UnityEngine.UI.Image[] thirstBar = new UnityEngine.UI.Image[5];
    public UnityEngine.UI.Image[] healthBar = new UnityEngine.UI.Image[5];
    public UnityEngine.UI.Image[] mHealthBar = new UnityEngine.UI.Image[5];
    private float maxStatus = 100f, lerpSpeed = 0.02f;


    public void ForAllCharacterStatus(float[] arr, float x) // t�m karakter durumlar� �zerinde oynama
    {
        for (int i = 0; i < 5; i++)
        {
            arr[i] += x;
            if (arr[i] >= 100) {     
              arr[i]=100; 
            }
        }
    }

    void BarFiller(UnityEngine.UI.Image bar, float status) // karakter durumunu g�stergeye yans�tma
    {
        bar.fillAmount = Mathf.Lerp(bar.fillAmount, (status / maxStatus), lerpSpeed);
        Color healthColor = Color.Lerp(Color.red, Color.white, (status / maxStatus));
        bar.color = healthColor;
    }

    void Update()
    {
        for (int j = 0; j < 5; j++) // karakter durumlar� ile aray�z� e�itleme
        {
            BarFiller(hungerBar[j], hunger[j]);
            BarFiller(thirstBar[j], thirst[j]);
            BarFiller(healthBar[j], health[j]);
            BarFiller(mHealthBar[j], mhealth[j]);
        }
    }
}
