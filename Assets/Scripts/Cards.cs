using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Cards;


public class Cards : MonoBehaviour
{

    public GameObject cardPrefab;
    public Transform canvasTransform;

    List<GameObject> activeCards = new List<GameObject>();
    public List<Card> allCards = new List<Card>();

    public class Card
    {
        public string eventName;
        public string description;
        public int positiveEffect;
        public int negativeEffect;
        public string posEffectTo;
        public string negEffectTo;
        public Card (string name, string desc, int posEffect, int negEffect, string posEffect2, string negEffect2)
        {
            eventName = name;
            description = desc;
            positiveEffect = posEffect;
            negativeEffect = negEffect;
            posEffectTo = posEffect2;
            negEffectTo = negEffect2;
        }
    }

    public Card card1 = new Card("Victoria", "Commander, i think we should party to night. what do you think?", +20, -9, "Mental Health", "Beer");
    public Card card2 = new Card("Radio", "xxxxxxxxx", +65 , -10, "Water", "Mental Health");
    private Card card3 = new Card("xxxxx", "xxxxxxxxxx", +25, -100, "Mental Health", "Bread");
    

    public void ShowEventCard(Card card)
    {
        // Kart prefab'ýný oluþtur
        GameObject cardObject = Instantiate(cardPrefab, canvasTransform);
        activeCards.Add(cardObject);


        // Kartýn içindeki bileþenleri bul
        TextMeshProUGUI titleText = cardObject.transform.Find("Victoria").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI descriptionText = cardObject.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI positiveEffectText = cardObject.transform.Find("PosEffects").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI negativeEffectText = cardObject.transform.Find("NegEffects").GetComponent<TextMeshProUGUI>();
        Button acceptButton = cardObject.transform.Find("BTN-Ok").GetComponent<Button>();
        Button rejectButton = cardObject.transform.Find("BTN-Nope").GetComponent<Button>();


        // Metinleri güncelle
        titleText.text = card.eventName;
        descriptionText.text = card.description;
        positiveEffectText.text = "+" + card.positiveEffect + " " + card.posEffectTo;
        negativeEffectText.text = card.negativeEffect + " " + card.negEffectTo;

        //Buton olaylarýný ayarlama
        acceptButton.onClick.AddListener(() => AcceptCard(card, cardObject));
        rejectButton.onClick.AddListener(() => RejectCard(cardObject));

    }


    void AcceptCard(Card card, GameObject cardObject)
    {
        switch (card.posEffectTo) {

            case "Bread":
                this.GetComponent<InventoryManager>().bread += card.positiveEffect;
                break;

            case "Water":
                this.GetComponent<InventoryManager>().water += card.positiveEffect;
                break;

            case "Medkit":
                this.GetComponent<InventoryManager>().medkit += card.positiveEffect;
                break;

            case "Beer":
                this.GetComponent<InventoryManager>().beer += card.positiveEffect;
                break;

            case "Cigarette":
                this.GetComponent<InventoryManager>().cigarette += card.positiveEffect;
                break;

            case "Hunger":
                this.GetComponent<CharacterStatus>().ForAllCharacterStatus(GetComponent<CharacterStatus>().hunger, card.positiveEffect);
                break;

            case "Thirst":
                this.GetComponent<CharacterStatus>().ForAllCharacterStatus(GetComponent<CharacterStatus>().thirst, card.positiveEffect);
                break;

            case "Health":
                this.GetComponent<CharacterStatus>().ForAllCharacterStatus(GetComponent<CharacterStatus>().health, card.positiveEffect);
                break;

            case "Mental Health":
                this.GetComponent<CharacterStatus>().ForAllCharacterStatus(GetComponent<CharacterStatus>().mhealth,card.positiveEffect);
                break;
        }


        switch (card.negEffectTo) {

            case "Bread":
                this.GetComponent<InventoryManager>().bread += card.negativeEffect;
                break;

            case "Water":
                this.GetComponent<InventoryManager>().water += card.negativeEffect;
                break;

            case "Medkit":
                this.GetComponent<InventoryManager>().medkit += card.negativeEffect;
                break;

            case "Beer":
                this.GetComponent<InventoryManager>().beer += card.negativeEffect;
                break;

            case "Cigarette":
                this.GetComponent<InventoryManager>().cigarette += card.negativeEffect;
                break;

            case "Hunger":
                this.GetComponent<CharacterStatus>().ForAllCharacterStatus(GetComponent<CharacterStatus>().hunger, card.negativeEffect);
                break;

            case "Thirst":
                this.GetComponent<CharacterStatus>().ForAllCharacterStatus(GetComponent<CharacterStatus>().thirst, card.negativeEffect);
                break;

            case "Health":
                this.GetComponent<CharacterStatus>().ForAllCharacterStatus(GetComponent<CharacterStatus>().health, card.negativeEffect);
                break;

            case "Mental Health":
                this.GetComponent<CharacterStatus>().ForAllCharacterStatus(GetComponent<CharacterStatus>().mhealth, card.negativeEffect);
                break;
        }




        RemoveAndDestroyCard(cardObject);

    }

    void RejectCard( GameObject cardObject)
    {
        RemoveAndDestroyCard(cardObject);
    }

    void RemoveAndDestroyCard(GameObject cardObject)
    {
        activeCards.Remove(cardObject); // Kartý listeden çýkar.
        Destroy(cardObject); // Kartý sahneden yok et.
    }

    public void Start()
    {

       ShowEventCard(card2);
       ShowEventCard(card3);
       ShowEventCard(card1);
    }


}
