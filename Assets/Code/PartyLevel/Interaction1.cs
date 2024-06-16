using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used for the text and the audio of the interaction.
public class Interaction1 : MonoBehaviour
{
    private Dictionary<int, AudioSource> interactionAudio;
    private Dictionary<int, string> interactionText;
    private List<int> interactionFlow;
    private Animator animator;
    public AudioSource source;
    private bool active;
    public Canvas ui;

    [SerializeField] private InteractionManager interactionManager;
    [SerializeField] private Pointsystem pointsystem;

    void Start() 
    {
        active = false;
        source = GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
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
            animator.SetBool("Talking", true);
            playAudioSource(1, 0, 1);
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
                playAudioSource(1, 2, 3);                
            }
            if (interactionFlow.Count == 2)
            {
                pointsystem.add50Points();
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
                playAudioSource(1, 4, 5);
            }
            if (interactionFlow.Count == 2)
            {
                pointsystem.add50Points();
                interactionManager.sequenceFinished(0);
            }
        }
    }

    public void playAudioSource(int audio, int text1, int text2)
    {
        
        Debug.Log("Play Audio Source - Animator get Bool: " + animator.GetBool("Talking"));
        ui.enabled = false;
        source.Play();
        StartCoroutine(waitForResponse(text1, text2));
        animator.SetBool("Talking", false);
    }

    IEnumerator waitForResponse(int text1, int text2)
    {
        Debug.Log("1: Wait For Response: Ui Enabled true: " + ui.enabled);
        while (source.isPlaying)
        {
            yield return null;
        }
        Debug.Log("3: Wait For Response: Ui Enabled true: " + ui.enabled);
        ui.enabled = true;
        interactionManager.setText(interactionText[text1], interactionText[text2], "");
    }
}
