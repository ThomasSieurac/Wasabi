using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/CreateDialogue", order = 1)]
public class SO_Dialogue : ScriptableObject
{
    [Tooltip("The sprite that will represent the character speaking")]
    public Sprite Image = null;

    [Tooltip("True if the image is on the right side, False is the image is on the left side")]
    public bool IsImageRight = true;

    [Tooltip("Name of the speaking character")]
    public Character Character = Character.Lux;

    [Tooltip("List of all the text of this character dialogue")]
    public List<string> Texts;

    [Tooltip("Used in Editor only")]
    public bool ShowTexts = false;

    [Tooltip("Used in Editor only")]
    public List<bool> ShowPreview;

    [Tooltip("Default size of the text")]
    public int DefaultSize = 36;

    public Sprite GetSprite() => Image;
    public string GetCharacter() => Character.ToString();
    public string GetText(int _index)
    {
        if (Texts.Count < _index) return null;
        return Texts[_index];
    }
}

// Enum regrouping all the names of the characters that can speak in a dialogue
public enum Character
{
    Lux,
    Ban,
    Yonix,
    Katrine,
    Lhudo,
    Kristof,
    Wasabi,
    Camy,
    Yuki,
    Ugo
}
