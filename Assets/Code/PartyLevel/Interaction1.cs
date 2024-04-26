using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction1 : MonoBehaviour
{
    [SerializeField] private Dictionary<int, AudioSource> interactionAudio;
    [SerializeField] private Dictionary<int, string> interactionText;
    private List<int> interactionFlow;
    private float path;
    private InteractionSelection interactionSelection;

    void Start()
    {
        interactionFlow = new List<int>();
        interactionText[1] = "Ausweichend: 'Ne, jemand sollte hier nüchtern bleiben.'";
        interactionText[2] = "Direkt: 'Ich enthalte mich für meine Gesundheit.'";
        interactionText[3] = "Ausweichend: 'Nein, im Ernst. Ich trage hier die Verantwortung.'";
        interactionText[4] = "Direkt: 'Nein, danke, ich will nichts.'";
        interactionText[5] = "Ausweichend: 'Glaub mir, ein einziger Drink kann sehr schaden.'";
        interactionText[6] = "Direkt: 'Nein, heute nicht.'";
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionFlow.Count == 0)
        {
            interactionSelection.setText(interactionText[1], interactionText[2], "");
        }
        if (interactionFlow.Count > 0)
        {
            if (interactionFlow[0] == 1)
            {
                interactionSelection.setText(interactionText[3], interactionText[4], "");
            }
            else if (interactionFlow[0] == 2)
            {
                interactionSelection.setText(interactionText[5], interactionText[6], "");
            }
            else
            {
                Debug.LogError("Error Interaction1");
            }
        }
        
    }

    public void selectedOption(int option)
    {
        interactionFlow.Add(option);
        if (option == 1)
        {
            // Play AudioSource
        } else if (option == 2)
        {
            // Play AudioSource
        }
    }

    public void playAudioSource(int audio)
    {

    }
}
