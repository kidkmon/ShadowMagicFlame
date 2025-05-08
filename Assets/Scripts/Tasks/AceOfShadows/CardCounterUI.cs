using TMPro;
using UnityEngine;

public class CardCounterUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text cardCountText;

    private CardsColumnController _cardsColumnController;

    void Awake()
    {
        _cardsColumnController = GetComponent<CardsColumnController>();
    }

    void UpdateCardCount(int count)
    {
        cardCountText.text = $"Cards: {count}";
    }

    void OnEnable()
    {
        _cardsColumnController.OnCardCountChanged += UpdateCardCount;
    }
    void OnDisable()
    {
        _cardsColumnController.OnCardCountChanged -= UpdateCardCount;
    }

}
