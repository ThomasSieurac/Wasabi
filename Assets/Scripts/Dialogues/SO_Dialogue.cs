using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/CreateDialogue", order = 1)]
public class SO_Dialogue : ScriptableObject
{
    public Sprite Image = null;
    public bool IsImageRight = true;
    public Character Character = Character.Lux;
    public List<string> Texts;
    public bool ShowTexts = false;
    public List<bool> ShowPreview;
    public int DefaultSize = 36;

    public Sprite GetSprite() => Image;
    public string GetCharacter() => Character.ToString();
    public string GetText(int _index)
    {
        if (Texts.Count < _index) return null;
        return Texts[_index];
    }
}

public enum Character
{
    Lux,
    Ban,
    Yonix,
    Katrine,
    Lhudo,
    Kristof
}
