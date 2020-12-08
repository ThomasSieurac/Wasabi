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


    private void OnEnable()
    {
        // If dialogues are empty stop
        if (Dialogues.Count < 0)
            return;

        // Setup first dialogue
        dialogue = Dialogues[0];

        // Set the side of the character image
        CheckSide();

        // Start the dialogue
        shownLine.text = dialogue.GetText(0);
        playLine = StartCoroutine(PlayLine());
    }

    public void Skip(UnityEngine.InputSystem.InputAction.CallbackContext _ctx)
    {
        // Exit if input is wrong
        if (!_ctx.performed) 
            return;

        // Call to stop the displayed line
        NullPlay();

        // If the line is complete
        if (shownLine.maxVisibleCharacters == shownLine.text.Length)
        {
            // If there is another line in the dialogue go to next line
            if (dialogue.Texts.Count - 1 > currentLine)
                NextLine();

            // If there is no other line in the dialogue go to next dialogue
            else
                NextDialoge();
        }
        // End the line
        else
            EndLine();
    }

    void NullPlay()
    {
        // If there is not a line playing exit
        if (playLine == null)
            return;

        // Stop the line playing
        currentChar = 0;
        StopCoroutine(playLine);
        playLine = null;
    }

    IEnumerator PlayLine()
    {
        // Loop until the line is fully shown
        while (shownLine.text.Length > currentChar)
        {
            // Hold if the game is paused
            while(WSB_GameManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }

            // Check if a RichText element starts
            if (shownLine.text[currentChar] == '<')
            {
                int _i = currentChar;

                // Count the number of char there is between the < & > characters
                while (true)
                {
                    if (shownLine.text[_i] == '>')
                        break;
                    _i++;
                }

                // Instantly show the whole richText element instead of one by one char
                currentChar += _i - currentChar;
            }
            // Increase the current char
            else
                currentChar++;

            // Show the updated number of char
            shownLine.maxVisibleCharacters = currentChar;

            yield return new WaitForFixedUpdate();
        }
        // Stop this coroutine
        NullPlay();
    }


    void EndLine()
    {
        // Reset currentChar & show all the line
        currentChar = 0;
        shownLine.maxVisibleCharacters = shownLine.text.Length;
    }

    void NextLine()
    {
        // Reset currentChar
        currentChar = 0;

        // Increase the line, updates it and start to play it
        currentLine++;
        shownLine.text = dialogue.GetText(currentLine);
        playLine = StartCoroutine(PlayLine());
    }

    void CheckSide()
    {
        // Enable each element on the right side and disable thoses on the left side
        if (dialogue.IsImageRight)
        {
            charImageRight.sprite = dialogue.GetSprite();
            shownNameRight.text = dialogue.GetCharacter();
            shownNameLeft.text = string.Empty;
            charImageRight.enabled = shownNameRight.enabled = true;
            charImageLeft.enabled = shownNameLeft.enabled = false;
        }
        // Enable each element on the left side and disable thoses on the right side
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
        // Increase the current dialogue, reset line and char
        currentDialogue++;
        currentLine = 0;
        currentChar = 0;

        // Check if there is no more dialogue
        if (currentDialogue >= Dialogues.Count)
        {
            // Stop everything and tells the game this dialogue is over
            StopAllCoroutines();
            WSB_GameManager.SetDialogue(false);
            transform.gameObject.SetActive(false);
            return;
        }

        // Get the new dialogue to show
        dialogue = Dialogues[currentDialogue];
        
        // Get the newt text to show
        shownLine.text = dialogue.GetText(0);

        // Set the side of the character image
        CheckSide();

        // Play the next line
        playLine = StartCoroutine(PlayLine());
    }

}
