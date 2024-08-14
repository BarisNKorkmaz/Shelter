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
        dailyEventCount = random.Next(5,12); // gün içerisinde gerçekleþecek olay sayýsýný belirler. - minimum 5, maksimum 11 adet - 

        this.gameObject.GetComponent<CharacterStatus>().ForAllCharacterStatus(this.gameObject.GetComponent<CharacterStatus>().hunger, -20f); // günlük açlýk, susuzluk ve mental saðlýk deðiþimleri
        this.gameObject.GetComponent<CharacterStatus>().ForAllCharacterStatus(this.gameObject.GetComponent<CharacterStatus>().thirst, -40f);
        this.gameObject.GetComponent<CharacterStatus>().ForAllCharacterStatus(this.gameObject.GetComponent<CharacterStatus>().mhealth, -5f);

       // this.gameObject.GetComponent<Cards>().ShowEventCard(this.gameObject.GetComponent<Cards>().);
        DisplayEventCard(dailyEventCount); // gerçekleþecek olay sayýsý kadar kart çaðýrýr


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
