using UnityEngine;

[CreateAssetMenu]
public class CardAssetConfig : ScriptableObject
{
    [SerializeField] int _id;
    [SerializeField] Sprite _icon;
    
    public int Id => _id;
    public Sprite Icon => _icon;
}