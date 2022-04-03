using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ImageList", menuName = "ImageList")]
public class ImageList : ScriptableObject
{
    [FormerlySerializedAs("sprites")] public Sprite[] Sprites;
    public Sprite DarkSprite;

    public Sprite GetRandomSprite() => DarkSprite;
}
