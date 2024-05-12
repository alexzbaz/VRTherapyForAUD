using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction2 : MonoBehaviour
{
    [SerializeField] private Dictionary<int, AudioSource> interactionAudio;
    [SerializeField] private Dictionary<int, string> interactionText;
    private List<int> interactionFlow;
    [SerializeField] private InteractionManager interactionManager;
    [SerializeField] private GameObject interaction2;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        interactionFlow = new List<int>();
        interactionText = new Dictionary<int, string>();
        interactionText[0] = "Ausweichend: 'Ne, jemand sollte hier nüchtern bleiben.'";
        interactionText[1] = "Direkt: 'Ich enthalte mich für meine Gesundheit.'";
        interactionText[2] = "Ausweichend: 'Nein, im Ernst. Ich trage hier die Verantwortung.'";
        interactionText[3] = "Direkt: 'Nein, danke, ich will nichts.'";
        interactionText[4] = "Ausweichend: 'Glaub mir, ein einziger Drink kann sehr schaden.'";
        interactionText[5] = "Direkt: 'Nein, heute nicht.'";
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
            interaction2.SetActive(true);
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
