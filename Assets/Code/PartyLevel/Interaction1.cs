using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used for the text and the audio of the interaction.
public class Interaction1 : MonoBehaviour
{
    private Dictionary<int, AudioSource> interactionAudio;
    private Dictionary<int, string> interactionText;
    private List<int> interactionFlow;

    [SerializeField] private InteractionManager interactionManager;
    [SerializeField] private Pointsystem pointsystem;

    void Start() 
    {
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

        if (interactionFlow.Count == 0)
        {
            interactionManager.setText(interactionText[0], interactionText[1], "");
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
                playAudioSource(1);
                interactionManager.setText(interactionText[2], interactionText[3], "");
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
                playAudioSource(1);
                interactionManager.setText(interactionText[4], interactionText[5], "");
            }
            if (interactionFlow.Count == 2)
            {
                pointsystem.add50Points();
                interactionManager.sequenceFinished(0);
            }
        }
    }

    public void playAudioSource(int audio)
    {

        
    }
}
