using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used for the text and the audio of the interaction.
public class Interaction1 : MonoBehaviour
{
    private Dictionary<int, string> interactionText;
    private List<int> interactionFlow;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    private bool active;
    public Canvas ui;

    [SerializeField] private InteractionManager interactionManager;
    [SerializeField] private Pointsystem pointsystem;

    [SerializeField] private AudioClip interactionAudio1;
    [SerializeField] private AudioClip interactionAudio2;
    [SerializeField] private AudioClip interactionAudio3;
    [SerializeField] private AudioClip interactionAudio4;
    [SerializeField] private AudioClip interactionAudio5;

    void Start() 
    {
        active = false;
        animator = GetComponent<Animator>();
        interactionFlow = new List<int>();
        interactionText = new Dictionary<int, string>();
        // First answer
        interactionText[0] = "Ausweichend: 'Ne, jemand sollte hier nüchtern bleiben.'";
        interactionText[1] = "Direkt: 'Ich enthalte mich für meine Gesundheit.'";
        // Second answer
        interactionText[2] = "Ausweichend: 'Nein, im Ernst. Ich trage hier die Verantwortung.'";
        interactionText[3] = "Direkt: 'Nein, danke, ich will nichts.'";
        // Third answer
        interactionText[4] = "Ausweichend: 'Glaub mir, ein einziger Drink kann sehr schaden.'";
        interactionText[5] = "Direkt: 'Nein, heute nicht.'";
    }

    private void Update()
    {
        if (interactionFlow.Count == 0 && active == false && ui.enabled)
        {
            active = true;
            playAudioSource(interactionAudio1);
            StartCoroutine(waitForResponse(0, 1));
        }
    }

    // OnClick set in Editor
    public void selectedOption(int option)
    {
        interactionFlow.Add(option);

        // First Button pressed
        if (option == 0)
        {
            if (interactionFlow.Count == 1)
            {
                pointsystem.add50Points();
                // Play AudioSource
                playAudioSource(interactionAudio2);
                StartCoroutine(waitForResponse(2, 3));
            }
            if (interactionFlow.Count == 2)
            {
                pointsystem.add50Points();
                playAudioSource(interactionAudio3);
                animator.SetBool("Talking", false);
                interactionManager.sequenceFinished(0);
            }
        }
        // Second Button pressed
        else if (option == 1)
        {
            if (interactionFlow.Count == 1)
            {
                pointsystem.add50Points();
                // Play AudioSource
                playAudioSource(interactionAudio4);
                StartCoroutine(waitForResponse(4, 5));
            }
            if (interactionFlow.Count == 2)
            {
                pointsystem.add50Points();
                playAudioSource(interactionAudio5);
                animator.SetBool("Talking", false);
                interactionManager.sequenceFinished(0);
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

    IEnumerator waitForResponse(int text1, int text2)
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        ui.enabled = true;
        animator.SetBool("Talking", false);
        interactionManager.setText(interactionText[text1], interactionText[text2], "");
    }
}
