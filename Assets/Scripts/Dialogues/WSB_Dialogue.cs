using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WSB_Dialogue : MonoBehaviour
{
    public List<SO_Dialogue> Dialogues;
    SO_Dialogue dialogue = null;

    int currentDialogue = 0;
    int currentLine = 0;
    int currentChar = 0;

    [SerializeField] TMP_Text shownLine = null;
    [SerializeField] TMP_Text shownName = null;

    [SerializeField] UnityEngine.UI.Image charImage = null;

    Coroutine playLine = null;

    string lineToShow = "";


    private void Start()
    {
        if (Dialogues.Count < 0) return;
        dialogue = Dialogues[0];
        charImage.sprite = dialogue.GetSprite();
        // switch de côter en fonction de dialogue.IsImageRight
        shownName.text = dialogue.GetCharacter();
        lineToShow = dialogue.GetText(0);
        playLine = StartCoroutine(PlayLine());
        // OnStartDialogue?.Invoke();
    }


    public void Skip(UnityEngine.InputSystem.InputAction.CallbackContext _ctx)
    {
        if (!_ctx.performed) return;
        NullPlay();
        if(shownLine.text.Length == lineToShow.Length)
        {
            if(dialogue.Texts.Count-1 > currentLine)
            {
                NextLine();
            }
            else
            {
                NextDialoge();
            }
        }
        else
        {
            EndLine();
        }
    }

    void NullPlay()
    {
        if (playLine == null) return;
        currentChar = 0;
        StopCoroutine(playLine);
        playLine = null;
    }

    IEnumerator PlayLine()
    {
        while(lineToShow.Length > currentChar)
        {
            shownLine.text += lineToShow[currentChar];
            currentChar++;
            yield return new WaitForFixedUpdate();
        }
        NullPlay();
    }

    void EndLine()
    {
        currentChar = 0;
        shownLine.text = lineToShow;
    }

    void NextLine()
    {
        currentChar = 0;
        currentLine++;
        shownLine.text = string.Empty;
        lineToShow = dialogue.GetText(currentLine);
        playLine = StartCoroutine(PlayLine());
    }

    void NextDialoge()
    {
        currentDialogue++;
        currentLine = 0;
        currentChar = 0;
        if(currentDialogue >= Dialogues.Count)
        {
            gameObject.SetActive(false);
            return;
        }
        dialogue = Dialogues[currentDialogue];
        charImage.sprite = dialogue.GetSprite();
        // switch l'image en fonction de dialogue.isimageright
        shownLine.text = string.Empty;
        lineToShow = dialogue.GetText(0);
        shownName.text = dialogue.GetCharacter();
        playLine = StartCoroutine(PlayLine());
    }

}

/*
 * 
 * 
 *      Debug : 
 *      Update(OnKeyDown(space) Skip()
 * 
 *      [SerializeField] List<SO_Dialogue> dialogues
 * 
 *      int currentLine
 *      int currentDialogue
 *      int currentChar
 *      
 *      string lineShown
 *      
 *      image charImage
 * 
 *      Coroutine playLine
 *  
 * 
 *      Start() OnStartDialogue?.Invoke()  <-- pour call les blocages des personnages par exemple
 * 
 *      Skip()
 *          - NullPlay()
 *          - Check si ligne terminée
 *              y - Check si le dialogue est terminé
 *                  y - NextDialogue()
 *                  n - NextLine()
 *              n - EndLine()
 *              
 *      Endline()
 *          - lineShown = line
 *          - feedback = enabled
 *      
 *      NextLine()
 *          - currentLine++
 *          - line = lines[currentLine]      
 *      
 *      NextDialogue()
 *          - currentDialogue++
 *          - charImage = dialogues[currentDialogue].image
 *          - charImage.position = dialogue[currentDialogue].isRight ? right : left
 *          - dialogue = dialogues[currentDialogue]
 *          
 *      
 *      Coroutine PlayLine()
 *          - while(dialogue[currentDialogue].line[currentLine].count > int currentChar)
 *              - lineShown = lineshown + dialogue[currentDialogue].line[currentLine][currentChar]
 *              - currentChar++
 *              - yield return temps
 *          - NullPlay()
 * 
 * 
 *      NullPlay()
 *          - StopCoroutine(playLine)
 *          - playLine = null
 */
