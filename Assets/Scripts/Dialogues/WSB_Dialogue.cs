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
    [SerializeField] TMP_Text shownNameRight = null;
    [SerializeField] TMP_Text shownNameLeft = null;

    [SerializeField] UnityEngine.UI.Image charImageLeft = null;
    [SerializeField] UnityEngine.UI.Image charImageRight = null;

    Coroutine playLine = null;

    private void Start()
    {
        if (Dialogues.Count < 0) return;
        dialogue = Dialogues[0];

        CheckSide();

        shownLine.text = dialogue.GetText(0);
        playLine = StartCoroutine(PlayLine());
        // OnStartDialogue?.Invoke();
    }


    public void Skip(UnityEngine.InputSystem.InputAction.CallbackContext _ctx)
    {
        if (!_ctx.performed) return;
        NullPlay();
        if(shownLine.maxVisibleCharacters == shownLine.text.Length)
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
        while (shownLine.text.Length > currentChar)
        {
            if (shownLine.text[currentChar] == '<')
            {
                int _i = currentChar;
                while(true)
                {
                    if (shownLine.text[_i] == '>')
                        break;
                    _i++;
                }
                currentChar += _i - currentChar;
            }
            else
                currentChar++;
            
            shownLine.maxVisibleCharacters = currentChar;
            yield return new WaitForFixedUpdate();
        }
        NullPlay();
    }

    /*
     * List<int> charWobbleIndex
     *      --> PlayLine if (shownLine.text[currentChar] == '<' && shownLine.Contains("wobble>", currentChar)
     *                      add shownLine.text[currentChar] while(shownLine.text[currentChar] != '<') currentChar++
     * 
     * IEnumerator Wobble()
     * {
     *      pour chaque char dans le <line-height=value>
     *          pingpong value entre min & max avec décalage du précédent
     * }
     * 
     */

    void EndLine()
    {
        currentChar = 0;
        shownLine.maxVisibleCharacters = shownLine.text.Length;
    }

    void NextLine()
    {
        currentChar = 0;
        currentLine++;
        shownLine.text = dialogue.GetText(currentLine);
        playLine = StartCoroutine(PlayLine());
    }
    void CheckSide()
    {
        if (dialogue.IsImageRight)
        {
            charImageRight.sprite = dialogue.GetSprite();
            shownNameRight.text = dialogue.GetCharacter();
            shownNameLeft.text = string.Empty;
            charImageRight.enabled = shownNameRight.enabled = true;
            charImageLeft.enabled = shownNameLeft.enabled = false;
        }
        else
        {
            charImageLeft.sprite = dialogue.GetSprite();
            shownNameLeft.text = dialogue.GetCharacter();
            shownNameRight.text = string.Empty;
            charImageLeft.enabled = shownNameLeft.enabled = true;
            charImageRight.enabled = shownNameRight.enabled = false;
        }
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
        CheckSide();
        shownLine.text = dialogue.GetText(0);
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
