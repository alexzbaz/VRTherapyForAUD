using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public TMP_Text interactionOption1;
    public TMP_Text interactionOption2;
    public TMP_Text interactionOption3;
    public Button option1;
    public Button option2;
    public Button option3;
    private int interactionNumber;
    private Interaction1 interaction1;
    private Interaction2 interaction2;
    //private Interaction3 interaction3;

    private List<Canvas> uis;
    [SerializeField] private Canvas ui1;
    [SerializeField] private Canvas ui2;
    [SerializeField] private Canvas ui3;

    private List<GameObject> interactionAnchors;
    [SerializeField] private GameObject interactionAnchor1;
    [SerializeField] private GameObject interactionAnchor2;
    [SerializeField] private GameObject interactionAnchor3;



    // Start is called before the first frame update
    void Start()
    {
        interactionAnchors = new List<GameObject>();
        interactionAnchors[0] = interactionAnchor1;
        interactionAnchors[1] = interactionAnchor2;
        interactionAnchors[2] = interactionAnchor3;

        uis = new List<Canvas>();
        uis[0] = ui1;
        uis[1] = ui2;
        uis[2] = ui3;
    }

    public void setText(string interaction1, string interaction2, string interaction3)
    {
        Debug.Log("Call Set Text in interactionSelection");
        interactionOption1.text = interaction1;
        interactionOption2.text = interaction2;
        if (interactionNumber == 3)
        {
            interactionOption3.text = interaction3;
        }
    }

    // Connect this function to the buttons
    public void selectOption(Button button)
    {
        if (button == option1)
        {
            interaction1.selectedOption(1);
        }
        else if (button == option2)
        {
            interaction1.selectedOption(2);
        }
        else if (button == option3)
        {
            interaction1.selectedOption(3);
        }
        else
        {
            Debug.LogError("Error Wrong Button");
        }
    }

    public void sequenceFinished(int sequenceNumber)
    {
        interactionAnchors[sequenceNumber].SetActive(false);
        uis[sequenceNumber].enabled = false;
        if (sequenceNumber <= interactionAnchors.Count)
        {
            interactionAnchors[sequenceNumber + 1].SetActive(true);
        }
    }



}
