using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class DayEventController : MonoBehaviour
{
    public DateTime currentDay = new DateTime(2142, 11, 18);
    public TextMeshProUGUI date;
    public int dailyEventCount;
    public System.Random random = new System.Random();


    private void NextDay()
    {
        date.text = currentDay.ToShortDateString();
        dailyEventCount = random.Next(5,12); // g�n i�erisinde ger�ekle�ecek olay say�s�n� belirler. - minimum 5, maksimum 11 adet - 

        this.gameObject.GetComponent<CharacterStatus>().ForAllCharacterStatus(this.gameObject.GetComponent<CharacterStatus>().hunger, -20f); // g�nl�k a�l�k, susuzluk ve mental sa�l�k de�i�imleri
        this.gameObject.GetComponent<CharacterStatus>().ForAllCharacterStatus(this.gameObject.GetComponent<CharacterStatus>().thirst, -40f);
        this.gameObject.GetComponent<CharacterStatus>().ForAllCharacterStatus(this.gameObject.GetComponent<CharacterStatus>().mhealth, -5f);

       // this.gameObject.GetComponent<Cards>().ShowEventCard(this.gameObject.GetComponent<Cards>().);
        DisplayEventCard(dailyEventCount); // ger�ekle�ecek olay say�s� kadar kart �a��r�r


        currentDay.AddDays(1);
    }

    void DisplayEventCard(int eventCount)
    {
        if (eventCount > 0)
        {
            for (int i = eventCount; i > 0; i--)
            {
                CreateEventCard(random.Next(0, 51));
            }
        }
    }

    void CreateEventCard(int cardnumber)
    {

    }

}
