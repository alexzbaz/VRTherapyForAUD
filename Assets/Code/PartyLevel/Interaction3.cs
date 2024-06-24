using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction3 : MonoBehaviour
{
    private Dictionary<int, string> interactionText;
    private List<int> interactionFlow; // Keys of the selected interactions
    private int interactionLevel;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    public Canvas ui;
    private bool active;

    [SerializeField] private InteractionManager interactionManager;
    [SerializeField] private Pointsystem pointsystem;

    [SerializeField] private AudioClip interactionAudioTest;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        animator = GetComponent<Animator>();
        interactionLevel = 0;
        interactionFlow = new List<int>();
        interactionText = new Dictionary<int, string>();

        // First answer
        interactionText[0] = "Ignorierend: 'Ja, das ist meine Party.'";
        interactionText[1] = "Erklärend: 'Ich hab aufgehört zu trinken, will aber trotzdem unter Leute.'";
        //Second answer
        interactionText[2] = "Ausweichend: 'Der Abend ist noch jung, vielleicht trinke ich später etwas.'";
        interactionText[3] = "Zurückhaltend: 'Ich genieß Alkohol nicht so sehr.'";
        interactionText[4] = "Direkt: 'Habe Probleme mit Alkohol und möchte abstinent bleiben.'";
        // Third answer - Ausweichend
        interactionText[5] = "[Nachgeben]: 'Hast recht, lass uns was holen.'";
        interactionText[6] = "Ausweichend: 'Vielleicht später.";
        // If option 5: Finished - Deduction of Points

        // Fourth answer - Ausweichend
        interactionText[7] = "[Nachgeben]: 'Hast recht, lass uns was holen.'";
        interactionText[8] = "Ausweichend: 'Wie schon gesagt, später vielleicht.'";
        interactionText[9] = "Direkt: 'Nein, jetzt erstmal nicht.'";
        // If option 7: Finished - Deduction of Points

        // Fifth answer - Ausweichend
        interactionText[10] = "[Nachgeben]: 'Na gut, wir besorgen mir was.'";
        interactionText[11] = "Erklärend: 'Hör mal. Ich hatte früher Probleme mit Alkohol und möchte davon loskommen.'";
        // If option 10: Finished - Deduction of Points


        // Third answer - Zurückhaltend
        interactionText[12] = "Neugierig: 'Was meinst du?'";
        interactionText[13] = "Verwirrt: 'Welches Gefühl?'";
        // Fourth answer - Zurückhaltend
        interactionText[14] = "Zustimmend: 'Ich weiß, was du meinst.'";
        interactionText[15] = "Ablehnend: 'Ja, aber was ist mit dem Morgen danach. Das ist kein schönes Gefühl.'";

        // Fifth answer - Zurückhaltend & Zustimmend
        interactionText[16] = "Erklärend: 'War ne lange Woche, da wird das Wochenende mir helfen.'";
        interactionText[17] = "Zustimmend: 'Hast ja recht, ich könnte einen Drink vertragen.'";
        // Sixth answer - Zurückhaltend & Zustimmend
        interactionText[18] = "Zustimmend: 'Auf gehts.'";
        interactionText[19] = "Ablehnend: 'Ich nehm aber doch nichts, danke.'";
        // If option 18: Finished - Deduction of Points

        // Fifth answer - Zurückhaltend & Ablehnend
        interactionText[20] = "Ablehnend: 'Der Preis ist mir zu hoch.'";
        interactionText[21] = "Zustimmend: 'Da hast du recht.'";
        // Sixth answer - Zurückhaltend
        interactionText[22] = "Zustimmend: 'Auf gehts.'";
        interactionText[23] = "Ablehnend: 'Nein, danke.'";
        // If option 22: Finished - Deduction of Points


        // Third answer - Direkt
        interactionText[24] = "Direkt: 'Nein.'";
        interactionText[25] = "Ausweichend: 'Mal schauen, wie der Abend noch läuft.'";
    }

    private void Update()
    {
        if (interactionFlow.Count == 0 && active == false && ui.enabled)
        {
            active = true;
            playAudioSource(interactionAudioTest);
            StartCoroutine(waitForResponse(0, 1, -1));
        }
    }

    // OnClick set in Editor
    public void selectedOption(int option)
    { 
        // First Button pressed
        if (option == 0)
        {
            if (interactionLevel == 0) // clicked on text 0
            {
                interactionFlow.Add(0);
                pointsystem.add50Points();
                // Play AudioSource
                playAudioSource(interactionAudioTest);
                StartCoroutine(waitForResponse(2, 3, 4));
            }
            else if (interactionLevel == 1) // clicked on text 2
            {
                pointsystem.add50Points();
                interactionFlow.Add(2);
                playAudioSource(interactionAudioTest);
                StartCoroutine(waitForResponse(5, 6, -1));
            }
            else if (interactionLevel == 2) // clicked on text 5 || text 12 || text 24
            {
                if (interactionFlow[1] == 2) // text 5
                {
                    pointsystem.deduct50Points();
                    interactionFlow.Add(5);
                    playAudioSource(interactionAudioTest);
                    animator.SetBool("Talking", false);
                    interactionManager.sequenceFinished(2);
                }
                else if (interactionFlow[1] == 3) // text 12
                {
                    pointsystem.add50Points();
                    interactionFlow.Add(12);
                    playAudioSource(interactionAudioTest);
                    StartCoroutine(waitForResponse(14, 15, -1));
                }
                else if (interactionFlow[1] == 4) // text 24
                {
                    pointsystem.add200Points();
                    interactionFlow.Add(24);
                    playAudioSource(interactionAudioTest);
                    animator.SetBool("Talking", false);
                    interactionManager.sequenceFinished(2);
                }
            }
            else if (interactionLevel == 3) // clicked on text 7 || text 14
            {
                if (interactionFlow[2] == 6) // text 7
                {
                    pointsystem.deduct50Points();
                    interactionFlow.Add(7);
                    playAudioSource(interactionAudioTest);
                    animator.SetBool("Talking", false);
                    interactionManager.sequenceFinished(2);
                }
                else if (interactionFlow[1] == 3) // text 14
                {
                    interactionFlow.Add(14);
                    playAudioSource(interactionAudioTest);
                    StartCoroutine(waitForResponse(16, 17, -1));
                }
                
            }
            else if (interactionLevel == 4) // clicked on text 10
            {
                if (interactionFlow[3] == 8) // text 10
                {
                    pointsystem.deduct50Points(); 
                    interactionFlow.Add(10);
                    playAudioSource(interactionAudioTest);
                    animator.SetBool("Talking", false);
                    interactionManager.sequenceFinished(2);
                }
                else if (interactionFlow[3] == 14) // text 16
                {
                    pointsystem.add50Points();
                    interactionFlow.Add(16);
                    playAudioSource(interactionAudioTest);
                    StartCoroutine(waitForResponse(18, 19, -1));
                }
                else if (interactionFlow[3] == 15) // text 20
                {
                    interactionFlow.Add(20);
                    playAudioSource(interactionAudioTest);
                    StartCoroutine(waitForResponse(22, 23, -1));
                }
            }
            else if (interactionLevel == 5)
            {
                if (interactionFlow[4] == 16 || interactionFlow[4] == 17) // text 18
                {
                    pointsystem.deduct50Points();
                    interactionFlow.Add(18);
                    playAudioSource(interactionAudioTest);
                    animator.SetBool("Talking", false);
                    interactionManager.sequenceFinished(2);
                }
                if (interactionFlow[4] == 20 || interactionFlow[4] == 21) // text 22
                {
                    pointsystem.deduct50Points();
                    interactionFlow.Add(22);
                    playAudioSource(interactionAudioTest);
                    animator.SetBool("Talking", false);
                    interactionManager.sequenceFinished(2);
                }
            }
        }

        // Second Button pressed
        else if (option == 1)
        {
            if (interactionLevel == 0) // clicked on text 1
            {
                interactionFlow.Add(1);
                pointsystem.add50Points();
                // Play AudioSource
                playAudioSource(interactionAudioTest);
                StartCoroutine(waitForResponse(2, 3, 4));
            }
            else if (interactionLevel == 1) // clicked on text 3
            {
                pointsystem.add50Points();
                interactionFlow.Add(3);
                playAudioSource(interactionAudioTest);
                StartCoroutine(waitForResponse(12, 13, -1));
            }
            else if (interactionLevel == 2) // clicked on text 6 || text 13
            {
                if (interactionFlow[1] == 2)
                {
                    pointsystem.add50Points();
                    interactionFlow.Add(6);
                    playAudioSource(interactionAudioTest);
                    StartCoroutine(waitForResponse(7, 8, 9));
                }
                else if (interactionFlow[1] == 3)
                {
                    pointsystem.add50Points();
                    interactionFlow.Add(13);
                    playAudioSource(interactionAudioTest);
                    StartCoroutine(waitForResponse(14, 15, -1));
                }
                else if (interactionFlow[1] == 4)
                {
                    pointsystem.add200Points();
                    interactionFlow.Add(25);
                    playAudioSource(interactionAudioTest);
                    animator.SetBool("Talking", false);
                    interactionManager.sequenceFinished(2);
                }
            }
            else if (interactionLevel == 3) // clicked on text 15
            {
                if (interactionFlow[2] == 6) // text 8
                {
                    pointsystem.add50Points();
                    interactionFlow.Add(8);
                    playAudioSource(interactionAudioTest);
                    StartCoroutine(waitForResponse(10, 11, -1));
                }
                else if (interactionFlow[2] == 12 || interactionFlow[2] == 13)
                {
                    pointsystem.add50Points();
                    interactionFlow.Add(15);
                    playAudioSource(interactionAudioTest);
                    StartCoroutine(waitForResponse(20, 21, -1));
                }
            }
            else if (interactionLevel == 4) // clicked on text 11 || 17 || 21
            {
                if (interactionFlow[3] == 8) // text 11
                {
                    pointsystem.deduct50Points();
                    interactionFlow.Add(11);
                    interactionManager.sequenceFinished(2);
                }
                if (interactionFlow[3] == 14) // 17
                {
                    pointsystem.add50Points();
                    interactionFlow.Add(17);
                    playAudioSource(interactionAudioTest);
                    StartCoroutine(waitForResponse(18, 19, -1));
                }
                else if (interactionFlow[3] == 15) // 21
                {
                    pointsystem.add50Points();
                    interactionFlow.Add(21);
                    playAudioSource(interactionAudioTest);
                    StartCoroutine(waitForResponse(22, 23, -1));
                }
            }
            else if (interactionLevel == 5) // clicked on text 19
            {
                if (interactionFlow[4] == 16 || interactionFlow[4] == 17)
                {
                    pointsystem.add50Points(); // text 19
                    interactionFlow.Add(19);
                    playAudioSource(interactionAudioTest);
                    animator.SetBool("Talking", false);
                    interactionManager.sequenceFinished(2);
                }
                else if (interactionFlow[4] == 20 || interactionFlow[4] == 21)
                {
                    pointsystem.add50Points();
                    interactionFlow.Add(18);
                    playAudioSource(interactionAudioTest);
                    animator.SetBool("Talking", false);
                    interactionManager.sequenceFinished(2);
                }
            }
            else if (interactionLevel == 6)
            {
                interactionFlow.Add(23);
                playAudioSource(interactionAudioTest);
                animator.SetBool("Talking", false);
                interactionManager.sequenceFinished(2);
            }
        }
        else if (option == 2)
        {
            if (interactionLevel == 1) // clicked on text 4
            {
                interactionFlow.Add(4);
                pointsystem.add100Points();
                playAudioSource(interactionAudioTest);
                StartCoroutine(waitForResponse(24, 25, -1));
            }
            else if (interactionLevel == 3) // clicked on text 9
            {
                interactionFlow.Add(9);
                playAudioSource(interactionAudioTest);
                animator.SetBool("Talking", false);
                interactionManager.sequenceFinished(2);
            }
        }

        interactionLevel += 1;
    }

    private void playAudioSource(AudioClip clip)
    {
        ui.enabled = false;
        animator.SetBool("Talking", true);
        audioSource.clip = clip;
        audioSource.Play();
    }

    IEnumerator waitForResponse(int text1, int text2, int text3)
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        ui.enabled = true;
        animator.SetBool("Talking", false);
        if (text3 != -1)
        {
            interactionManager.setText(interactionText[text1], interactionText[text2], interactionText[text3]);
        }
        else
        {
            interactionManager.setText(interactionText[text1], interactionText[text2], "");
        }
    }
}
