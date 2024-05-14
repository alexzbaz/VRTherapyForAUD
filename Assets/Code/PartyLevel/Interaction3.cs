using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction3 : MonoBehaviour
{
    private Dictionary<int, AudioSource> interactionAudio;
    private Dictionary<int, string> interactionText;
    private List<int> interactionFlow;
    [SerializeField] private InteractionManager interactionManager;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        interactionFlow = new List<int>();
        interactionText = new Dictionary<int, string>();
        // First answer
        interactionText[0] = "Ignorierend: 'Ja, das ist meine Party.'";
        interactionText[1] = "Erklärend: 'Ich hab aufgehört zu trinken, will aber trotzdem unter Leute.'";
        //Second answer
        interactionText[2] = "Ausweichend: 'Der Abend ist noch jung, vielleicht trinke ich später etwas.'";
        interactionText[2] = "";
        interactionText[2] = "";
        // Third answer - Ausweichend
        interactionText[2] = "";
        interactionText[2] = "";
        // Fourth answer - Ausweichend
        interactionText[2] = "";
        interactionText[2] = "";
        interactionText[2] = "";
        // Fifth answer - Ausweichend
        interactionText[2] = "";
        interactionText[2] = "";
        

        // Third answer - Zurückhaltend
        interactionText[2] = "";
        interactionText[2] = "";
        // Fourth answer - Zurückhaltend
        interactionText[2] = "";
        interactionText[2] = "";

        // Fifth answer - Zurückhaltend & Zustimmend
        interactionText[2] = "";
        interactionText[2] = "";
        // Sixth answer - Zurückhaltend & Zustimmend
        interactionText[2] = "";
        interactionText[2] = "";

        // Fifth answer - Zurückhaltend & Ablehnend
        interactionText[2] = "";
        interactionText[2] = "";
        // Sixth answer - Zurückhaltend & Ablehnend
        interactionText[2] = "";
        interactionText[2] = "";


        // Third answer - Direkt
        interactionText[2] = "";
        interactionText[2] = "";
    }

    public void setFirstInteraction()
    {
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
