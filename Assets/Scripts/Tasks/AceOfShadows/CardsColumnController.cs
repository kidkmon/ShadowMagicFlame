using System;
using System.Collections.Generic;
using UnityEngine;

public class CardsColumnController : MonoBehaviour
{
    [Header("Column Settings")]
    [SerializeField] private float cardOffset = 0.05f;

    private readonly Stack<CardController> _stack = new();
    private float _currentCardOffset;

    public event Action<int> OnCardCountChanged;

    public void AddCard(CardController card)
    {
        _stack.Push(card);
        card.SetSortingOrder(_stack.Count);
        card.transform.SetParent(transform);
        card.transform.localPosition = GetNewCardOffsetPosition();
        card.transform.SetAsLastSibling();
        OnCardCountChanged?.Invoke(_stack.Count);
    }

    public CardController RemoveCard()
    {
        if (_stack.Count == 0) return null;

        CardController card = _stack.Pop();
        card.transform.SetParent(null);
        OnCardCountChanged?.Invoke(_stack.Count);
        return card;
    }

    public Vector3 GetNewCardOffsetPosition()
    {
        _currentCardOffset += cardOffset;
        return new Vector3(0, _currentCardOffset, 0);
    }

    public Vector3 GetTopCardPosition()
    {
        if (_stack.Count == 0) return transform.position;
        return _stack.Peek().transform.position;
    }

    public int Count => _stack.Count;
    public bool IsEmpty => _stack.Count == 0;
}
