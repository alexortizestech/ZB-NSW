using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

namespace EasyUI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextDecoder : MonoBehaviour
    {
        [Tooltip("The text to reveal")] public string textToShow;

        [Tooltip("Reveal letters in order or at random")]
        public bool sequential = false;

        [Range(1, 20)] public int sequenceDelay = 10;

        [Tooltip("The time between character change")]
        public float randomizeDelay = 0.05f;

        [Tooltip("The time until the text begins to reveal")]
        public float textShowDelay = 3f;

        [Tooltip("Elapsed time until the text will force show (Counts after ShowDelay)")]
        public float forceTime = 2;

        [Tooltip("Whether or not to include letters for the randomization")]
        public bool includeLetters = true;

        [Tooltip("Whether or not to include numbers for the randomization")]
        public bool includeNumbers = false;

        [Tooltip("Whether or not to include numbers for the randomization")]
        public bool includeUnique = false;

        [Tooltip("If includeUnique is enabled then list unique characters such as accented letters")]
        public List<char> uniqueChars = new List<char>();

        private TextMeshProUGUI textBox;

        private bool reveal = false;
        private string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string numbers = "1234567890";
        private List<char> charactersToUse = new List<char>();
        private string randomText = "";

        private void Awake()
        {
            textBox = GetComponent<TextMeshProUGUI>();

            if (includeLetters) charactersToUse.AddRange(letters);
            if (includeNumbers) charactersToUse.AddRange(numbers);
            if (includeUnique) charactersToUse.AddRange(uniqueChars);

            if (charactersToUse.Count == 0) Debug.LogError("TEXTDECODER: No character range selected");
        }

        private void Start()
        {
            StartCoroutine(ITextDecoder());
        }


        // Call this coroutine to begin text decoder
        private IEnumerator ITextDecoder()
        {
            PopulateRandomText(); // Populates the random letter string with same length as text to write
            InvokeRepeating("RandomizeLetters", 0f, randomizeDelay); // Start randomizing text

            // Start revealing letters after elapsed time
            yield return new WaitForSeconds(textShowDelay);
            reveal = true; // Reveal 

            // Force Text to show after specified seconds (Counts after show delay)
            if (!sequential && textBox.text != textToShow)
            {
                yield return new WaitForSeconds(forceTime);
                CancelInvoke();
                textBox.text = textToShow;
            }

            yield return null;
        }


// Counts when to reveal next sequential letter
        private int currentLetter = 0;
        private int loopCount = 0;

        public void RandomizeLetters()
        {
            if (textBox.text == textToShow)
            {
                CancelInvoke();
                return;
            }

            loopCount++;
            // Loops through each char in the text to write
            for (int i = currentLetter; i < textToShow.Length; i++)
            {
                // If reveal is true then start to skip letters (resulting in the full string being shown)
                if (reveal == true)
                {
                    // Set next correct letter
                    if (sequential)
                    {
                        if (i == currentLetter && loopCount >= sequenceDelay)
                        {
                            string currentLetterChar = textToShow[currentLetter].ToString();
                            randomText = randomText.Remove(i, 1);
                            randomText = randomText.Insert(i, currentLetterChar);
                            textBox.text = randomText;

                            currentLetter++;
                            loopCount = 0;

                            continue;
                        }
                    }
                    else
                    {
                        if (textToShow[i].ToString() == " ")
                        {
                            randomText = randomText.Remove(i, 1);
                            randomText = randomText.Insert(i, " ");
                            continue;
                        }

                        if (randomText[i].ToString() == textToShow[i].ToString().ToUpper())
                        {
                            continue;
                        }
                    }
                }

                int randomLetterGen = Random.Range(0, charactersToUse.Count); // Picks random character in the generator

                randomText = randomText.Remove(i, 1); // Remove character from position
                randomText =
                    randomText.Insert(i, charactersToUse[randomLetterGen].ToString()); // Insert new random char

                textBox.text = randomText; // Set text
            }
        }

// Fills the random string with same char count as the text to write
        private void PopulateRandomText()
        {
            for (int i = 0; i < textToShow.Length; i++)
            {
                // Return if the count length is the same (And chat count is more than 0)
                if (i > 0 && randomText.Length == textToShow.Length)
                {
                    return;
                }

                // Populate string
                randomText = randomText.Insert(i, " ");
            }
        }
    }
}