using UnityEngine;

[CreateAssetMenu]
public class CardAssetConfig : ScriptableObject
{
    [SerializeField] int _id;
    [SerializeField] Sprite _sprite;
    
    public int Id => _id;
    public Sprite Sprite => _sprite;
}