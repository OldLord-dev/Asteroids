using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "spriteSet", menuName = "Sprite Set", order = 51)]
public class SpriteSet : ScriptableObject
{
    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();

    public List<Sprite> Sprites { get { return sprites; } }
}