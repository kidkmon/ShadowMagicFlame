using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystem : MonoBehaviour
{
    [Header("Card Settings")]
    [SerializeField] private int totalCards = 144;
    [SerializeField] private float moveDuration = 1f;

    [Header("Card Elements")]
    [SerializeField] private CardsAssetCollection cardsAssetCollection;
    [SerializeField] private CardController cardPrefab;
    [SerializeField] private List<CardsColumnController> columns = new();

    void Awake()
    {
        cardsAssetCollection.Initialize();
    }

    void Start()
    {
        InitializeCards();
        StartCoroutine(MoveCardsToNewColumn(columns[0], columns[1], true));
    }

    private void InitializeCards()
    {
        for (int i = 0; i < totalCards; i++)
        {
            CardController card = Instantiate(cardPrefab, columns[0].transform);
            card.SetCardSprite(GetRandomSprite());

            columns[0].AddCard(card);
        }
    }

    private IEnumerator MoveCardsToNewColumn(CardsColumnController currentColumn, CardsColumnController targetColumn, bool showMessage)
    {
        while (!currentColumn.IsEmpty)
        {
            CardController card = currentColumn.RemoveCard();
            var targetPosition = targetColumn.GetTopCardPosition();

            if (card == null) yield break;

            card.MoveTo(targetPosition, moveDuration, () =>
            {
                targetColumn.AddCard(card);
            });

            yield return new WaitForSeconds(moveDuration);
        }

        yield return new WaitForSeconds(0.5f);

        if (showMessage)
        {
            ToastMessageUI.Instance.ShowMessage("All cards moved to the new column!", RevertCards);
        }
    }

    private void RevertCards()
    {
        moveDuration = 0.25f;
        StartCoroutine(MoveCardsToNewColumn(columns[1], columns[0], false));
    }

    private Sprite GetRandomSprite()
    {
        int randomIndex = Random.Range(1, cardsAssetCollection.Size + 1);
        return cardsAssetCollection.GetConfig(randomIndex).Sprite;
    }
}
