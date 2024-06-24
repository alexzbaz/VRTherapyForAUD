using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction2 : MonoBehaviour
{
    private Dictionary<int, string> interactionText;
    private List<int> interactionFlow;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    public Canvas ui;
    private bool active;

    [SerializeField] private InteractionManager interactionManager;
    [SerializeField] private Pointsystem pointsystem;

    [SerializeField] private AudioClip interactionAudioTest;
    [SerializeField] private AudioClip interactionAudio1;
    [SerializeField] private AudioClip interactionAudio2;
    [SerializeField] private AudioClip interactionAudio3;
    [SerializeField] private AudioClip interactionAudio4;
    [SerializeField] private AudioClip interactionAudio5;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        animator = GetComponent<Animator>();
        interactionFlow = new List<int>();
        interactionText = new Dictionary<int, string>();
        // First answer
        interactionText[0] = "Nein, möchte mich enthalten.";
        interactionText[1] = "Nein, ich mache eine Pause vom Alkohol.";
        interactionText[2] = "Heute nicht, danke.";
        // Second answer
        interactionText[3] = "Ablehnend: 'Ja, aber das war früher. Der Alkohol schadet mir mehr, als dass er mir hilft.'";
        interactionText[4] = "Ablehnend: 'Ja, aber am nächsten Tag hab' ich es immer bereut.'";
        interactionText[5] = "Annehmend: 'Hast recht, heute kann ich mal einen trinken.'";
        // If Option 5: Finished - Deduction of Points
        // Third answer - Ablehnend
        interactionText[6] = "Ablehnend: 'Ich brauch’ keinen Alkohol, um Spaß zu haben.'";
        interactionText[7] = "Eingeschüchtert: 'Bin ich ohne Alkohol etwa langweilig?'";
        interactionText[8] = "Annehmend: 'Ja, ok, aber nur eins.'";
        // If Option 8: Finished - Deduction of Points
        // Fourth answer - Ablehnend
        interactionText[9] = "Ablehnend: 'Ich sagte, ich will nichts. Und dabei bleibt es.'";
        interactionText[10] = "Annehmend: 'Na gut.'";
        // If option 10: Finished - Deduction of Points
        // Fifth answer - Ablehnend
        interactionText[11] = "[Gespräch beenden.]";
        interactionText[12] = "Annehmend: 'Aber nur ein Drink, klar?'";
        // If option 12: Finished - Deduction of Points
    }

    private void Update()
    {
        if (interactionFlow.Count == 0 && active == false && ui.enabled)
        {
            active = true;
            playAudioSource(interactionAudio1);
            StartCoroutine(waitForResponse(0, 1, 2));
        }
    }

    // OnClick set in Editor
    public void selectedOption(int option)
    {
        interactionFlow.Add(option);

        // First Button pressed
        if (option == 0)
        {
            if (interactionFlow.Count == 1) // clicked on text 0
            {
                pointsystem.add50Points();
                playAudioSource(interactionAudio2);
                StartCoroutine(waitForResponse(3, 4, 5));
            }
            else if (interactionFlow.Count == 2) // text 3
            {
                pointsystem.add50Points();
                playAudioSource(interactionAudio3);
                StartCoroutine(waitForResponse(6, 7, 8));
            }
            else if (interactionFlow.Count == 3) // text 6
            {
                pointsystem.add50Points();
                playAudioSource(interactionAudio4);
                StartCoroutine(waitForResponse(9, 10, -1));
            }
            else if (interactionFlow.Count == 4) // text 9
            {
                pointsystem.add50Points();
                playAudioSource(interactionAudio5);
                StartCoroutine(waitForResponse(11, 12, -1));
            }
            else if (interactionFlow.Count == 5) // text 11 - no deduction of points
            {
                pointsystem.add100Points();
                interactionManager.sequenceFinished(1);
                animator.SetBool("Talking", false);
            }
        }
        // Second Button pressed
        else if (option == 1)
        {
            if (interactionFlow.Count == 1) // text 1
            {
                pointsystem.add50Points();
                // Play AudioSource
                playAudioSource(interactionAudio2);
                StartCoroutine(waitForResponse(3, 4, 5));
            }
            else if (interactionFlow.Count == 2) // text 4
            {
                pointsystem.add50Points();
                playAudioSource(interactionAudio3);
                StartCoroutine(waitForResponse(6, 7, 8));
            }
            else if (interactionFlow.Count == 3) // text 7
            {
                pointsystem.add50Points();
                playAudioSource(interactionAudio4);
                StartCoroutine(waitForResponse(9, 10, -1));
            }
            else if (interactionFlow.Count == 4) // text 10
            {
                pointsystem.deduct50Points();
                interactionManager.sequenceFinished(1);
                animator.SetBool("Talking", false);
            }
            else if (interactionFlow.Count == 5) // text 12
            {
                pointsystem.deduct50Points();
                interactionManager.sequenceFinished(1);
                animator.SetBool("Talking", false);
            }
        }
        else if (option == 2)
        {
            if (interactionFlow.Count == 1) // text 2
            {
                pointsystem.add50Points();
                playAudioSource(interactionAudio2);
                StartCoroutine(waitForResponse(3, 4, 5));
            }
            else if (interactionFlow.Count == 2) // text 5 - sequence finish
            {
                pointsystem.deduct50Points();
                animator.SetBool("Talking", false);
                interactionManager.sequenceFinished(1);
            }
            else if (interactionFlow.Count == 3) // text 8 - sequence finish
            {
                pointsystem.deduct50Points();
                interactionManager.sequenceFinished(1);
                animator.SetBool("Talking", false);
            }
        }
    }

    private void playAudioSource(AudioClip clip)
    {
        ui.enabled = false;
        animator.SetBool("Talking", true);
        audioSource.clip = clip;
        audioSource.Play();
    }

    IEnumerator waitForResponse(int text1, int text2, int text3)
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        ui.enabled = true;
        animator.SetBool("Talking", false);
        if (text3 != -1)
        {
            interactionManager.setText(interactionText[text1], interactionText[text2], interactionText[text3]);
        }
        else
        {
            interactionManager.setText(interactionText[text1], interactionText[text2], "");
        }
    }
}
