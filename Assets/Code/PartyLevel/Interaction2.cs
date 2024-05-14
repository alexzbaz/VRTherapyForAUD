using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction2 : MonoBehaviour
{
    private Dictionary<int, AudioSource> interactionAudio;
    private Dictionary<int, string> interactionText;
    private List<int> interactionFlow;
    [SerializeField] private InteractionManager interactionManager;

    // Start is called before the first frame update
    void Start()
    {
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

        if (interactionFlow.Count == 0 && interactionManager.currentInteraction == 1)
        {
            Debug.Log("interactionFlow.Count == 0" + interactionFlow.Count);
            interactionManager.setText(interactionText[0], interactionText[1], interactionText[2]);
        }
    }

    // OnClick set in Editor
    public void selectedOption(int option)
    {
        interactionFlow.Add(option);
        // Finish Sequence
        if (interactionFlow.Count == 2)
        {
            interactionManager.sequenceFinished(0);
        }


        // First Button pressed
        if (option == 0)
        {
            if (interactionFlow.Count == 1) // text 0
            {
                // Play AudioSource
                playAudioSource(1);
                interactionManager.setText(interactionText[3], interactionText[4], interactionText[5]);
            }
            else if (interactionFlow.Count == 2) // text 3
            {
                playAudioSource(1);
                interactionManager.setText(interactionText[6], interactionText[7], interactionText[8]);
            }
            else if (interactionFlow.Count == 3) // text 6
            {
                playAudioSource(1);
                interactionManager.setText(interactionText[9], interactionText[10], "");
            }
            else if (interactionFlow.Count == 4) // text 9
            {
                playAudioSource(1);
                interactionManager.setText(interactionText[11], interactionText[12], "");
            }
            else if (interactionFlow.Count == 5) // text 11 - no deduction of points
            {
                interactionManager.sequenceFinished(1);
            }
        }
        // Second Button pressed
        else if (option == 1)
        {
            if (interactionFlow.Count == 1) // text 1
            {
                // Play AudioSource
                playAudioSource(1);
                interactionManager.setText(interactionText[3], interactionText[4], interactionText[5]);
            }
            else if (interactionFlow.Count == 2) // text 4
            {
                playAudioSource(1);
                interactionManager.setText(interactionText[6], interactionText[7], interactionText[8]);
            }
            else if (interactionFlow.Count == 3) // text 7
            {
                playAudioSource(1);
                interactionManager.setText(interactionText[9], interactionText[10], "");
            }
            else if (interactionFlow.Count == 4) // text 10
            {
                playAudioSource(1);
                interactionManager.sequenceFinished(1);
            }
            else if (interactionFlow.Count == 5) // text 11
            {
                interactionManager.sequenceFinished(1);
            }
        }
        else if (option == 2)
        {
            if (interactionFlow.Count == 1) // text 2
            {
                playAudioSource(1);
                interactionManager.setText(interactionText[3], interactionText[4], interactionText[5]);
            }
            else if (interactionFlow.Count == 2) // text 5
            {
                playAudioSource(1);
                interactionManager.sequenceFinished(1);
            }
            else if (interactionFlow.Count == 3) // text 8
            {
                interactionManager.sequenceFinished(1);
            }
        }
    }

    public void playAudioSource(int audio)
    {


    }
}
