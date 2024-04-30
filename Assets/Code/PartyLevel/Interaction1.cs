using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction1 : MonoBehaviour
{
    [SerializeField] private Dictionary<int, AudioSource> interactionAudio;
    [SerializeField] private Dictionary<int, string> interactionText;
    private List<int> interactionFlow;
    private InteractionSelection interactionSelection;
    [SerializeField] private GameObject interactionCanvas;
    [SerializeField] private GameObject interaction2;
    public bool active;

    void Start() 
    {
        active = true;
        interactionFlow = new List<int>();
        interactionText[1] = "Ausweichend: 'Ne, jemand sollte hier nüchtern bleiben.'";
        interactionText[2] = "Direkt: 'Ich enthalte mich für meine Gesundheit.'";
        interactionText[3] = "Ausweichend: 'Nein, im Ernst. Ich trage hier die Verantwortung.'";
        interactionText[4] = "Direkt: 'Nein, danke, ich will nichts.'";
        interactionText[5] = "Ausweichend: 'Glaub mir, ein einziger Drink kann sehr schaden.'";
        interactionText[6] = "Direkt: 'Nein, heute nicht.'";
        interactionCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionFlow.Count == 0)
        {
            interactionSelection.setText(interactionText[1], interactionText[2], "");
        }

        if (interactionFlow.Count == 2) // && interaction1 finished
        {
            interaction2.SetActive(true);
            active = false;
        }
    }

    public void selectedOption(int option)
    {
        interactionFlow.Add(option);
        if (option == 1)
        {
            // Play AudioSource
            playAudioSource(1);
            // After playing AudioSource
            interactionSelection.setText(interactionText[3], interactionText[4], "");
        }
        else if (option == 2)
        {
            // Play AudioSource
            playAudioSource(2);
            // After playing AudioSource
            interactionSelection.setText(interactionText[5], interactionText[6], "");
        }
    }

    public void playAudioSource(int audio)
    {

        
    }
}
