using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Fossil/New fossil", order = 0)]
public class Fossil : ScriptableObject
{
    [SerializeField] int index;
    [SerializeField] Sprite spriteNotebookDino;
    [SerializeField] Sprite spriteInfo;
    [SerializeField] string nameFossil;
    [TextArea][SerializeField] string description;
    [SerializeField] AudioClip audioClipThisFossil;

    public int GetUniqueIndex() => index;

    public Sprite GetSpriteByNotebook() => spriteNotebookDino;

    public Sprite GetSpriteInfoNotebook() => spriteInfo;

    public string GetNameFossil() => nameFossil;


    public string GetDescFossil() => description;

    public AudioClip GetClipFossil() => audioClipThisFossil;
}
