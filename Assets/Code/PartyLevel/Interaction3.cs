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
        interactionText[0] = "Interaction3-1";
        interactionText[1] = "Interaction3-2";
        interactionText[2] = "Interaction3-3";
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionFlow.Count == 0)
        {
            interactionManager.setText(interactionText[0], interactionText[1], "");
        }

        if (interactionFlow.Count == 2 && active) // && interaction1 finished
        {
            active = false;
            interactionManager.sequenceFinished(0);
        }
    }
    // OnClick set in Editor
    public void selectedOption(int option)
    {
        Debug.Log("SELECTED OPTION: " + option);
        interactionFlow.Add(option);
        if (option == 0)
        {
            // Play AudioSource
            playAudioSource(1);
            // After playing AudioSource
            interactionManager.setText(interactionText[2], interactionText[3], "");
        }
        else if (option == 1)
        {
            // Play AudioSource
            playAudioSource(2);
            // After playing AudioSource
            interactionManager.setText(interactionText[4], interactionText[5], "");
        }
    }

    public void playAudioSource(int audio)
    {


    }
}
