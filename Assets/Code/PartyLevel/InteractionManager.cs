using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public TMP_Text interaction1Option1;
    public TMP_Text interaction1Option2;
    public TMP_Text interaction2Option1;
    public TMP_Text interaction2Option2;
    public TMP_Text interaction2Option3;
    public TMP_Text interaction3Option1;
    public TMP_Text interaction3Option2;
    public TMP_Text interaction3Option3;

    public Button interaction1Button1;
    public Button interaction1Button2;
    public Button interaction2Button1;
    public Button interaction2Button2;
    public Button interaction2Button3;
    public Button interaction3Button1;
    public Button interaction3Button2;
    public Button interaction3Button3;

    [SerializeField] private Interaction1 interaction1;
    [SerializeField] private Interaction2 interaction2;
    [SerializeField] private Interaction3 interaction3;

    public int currentInteraction;

    private List<Canvas> interactionCanvasList;
    [SerializeField] private Canvas interactionCanvas1;
    [SerializeField] private Canvas interactionCanvas2;
    [SerializeField] private Canvas interactionCanvas3;

    private List<GameObject> interactionAnchorsList;
    [SerializeField] private GameObject interactionAnchor1;
    [SerializeField] private GameObject interactionAnchor2;
    [SerializeField] private GameObject interactionAnchor3;

    // Start is called before the first frame update
    void Start()
    {
        currentInteraction = 0;

        interactionAnchorsList = new List<GameObject>();
        interactionAnchorsList.Add(interactionAnchor1);
        interactionAnchorsList.Add(interactionAnchor2);
        interactionAnchorsList.Add(interactionAnchor3);

        interactionCanvasList = new List<Canvas>();
        interactionCanvasList.Add(interactionCanvas1);
        interactionCanvasList.Add(interactionCanvas2);
        interactionCanvasList.Add(interactionCanvas3);

        interactionCanvas1.enabled = false;
        interactionCanvas2.enabled = false;
        interactionCanvas3.enabled = false;
    }

    public void setText(string interaction1, string interaction2, string interaction3)
    {
        Debug.Log("Set Text: " + currentInteraction);
        if (currentInteraction == 0)
        {
            Debug.Log("First if");
            interaction1Option1.text = interaction1;
            interaction1Option2.text = interaction2;
        }
        else if (currentInteraction == 1)
        {
            interaction2Option1.text = interaction1;
            interaction2Option2.text = interaction2;
            interaction2Option3.text = interaction3;
        }
        else if (currentInteraction == 2)
        {
            interaction3Option1.text = interaction1;
            interaction3Option2.text = interaction2;
            interaction3Option3.text = interaction3;
        }
    }

    // Connect this function to the buttons
    public void selectOption(Button button)
    {
        if (currentInteraction == 0)
        {
            if (button == interaction1Button1)
            {
                Debug.Log("interaction1Button1");
                interaction1.selectedOption(0);
            }
            else if (button == interaction1Button2)
            {
                Debug.Log("interaction1Button2");
                interaction1.selectedOption(1);
            }
        }
        else if (currentInteraction == 1)
        {
            if (button == interaction2Button1)
            {
                interaction2.selectedOption(0);
            }
            else if (button == interaction2Button2)
            {
                interaction2.selectedOption(1);
            }
            else if (button == interaction2Button3)
            {
                interaction2.selectedOption(2);
            }
        }
        else if (currentInteraction == 2)
        {
            if (button == interaction3Button1)
            {
                interaction3.selectedOption(0);
            }
            else if (button == interaction3Button2)
            {
                interaction3.selectedOption(1);
            }
            else if (button == interaction3Button3)
            {
                interaction3.selectedOption(2);
            }
        }
        else
        {
            Debug.LogError("Error Wrong Button");
        }
    }

    // set logic for finish (last sequence done)
    // get new buttons and options
    public void sequenceFinished(int sequenceNumber)
    {
        interactionAnchorsList[sequenceNumber].SetActive(false);
        interactionCanvasList[sequenceNumber].enabled = false;
        if (sequenceNumber <= interactionAnchorsList.Count)
        {
            currentInteraction += 1;
            interactionAnchorsList[sequenceNumber + 1].SetActive(true);
            if (currentInteraction == 1)
            {
                interaction2.setFirstInteraction();
            }
            if (currentInteraction == 2)
            {
                interaction3.setFirstInteraction();
            }
        }
    }

}
