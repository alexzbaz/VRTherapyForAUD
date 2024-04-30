using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionSelection : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        setNumberOfOptions();
        // Logic to get number of options in interactions
    }

    private void setNumberOfOptions()
    {
        if (interaction1.active)
        {
            interactionNumber = 2;
            option3.enabled = false;
        }
        else
        {
            interactionNumber = 3;
            option3.enabled = true;
        }
    }

    public void setText(string interaction1, string interaction2, string interaction3)
    {
        
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

}
