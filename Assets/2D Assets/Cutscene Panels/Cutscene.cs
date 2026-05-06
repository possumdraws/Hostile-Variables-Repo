using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class Cutscene : MonoBehaviour
{
    [Header("Slideshow Settings")]
    public Image displayImage;// UI Image to show slides
    public Sprite[] slides;//array of slide images
    public float slideDuration = 3f;// time each slide is shown (if autoAdvance is true)
    public float fadeDuration = 1f;//fade in/out time
    public bool autoAdvance = true;// automatically go to next slide
    public KeyCode nextKey = KeyCode.Space; //key to advance manually

    [Header("Text Settings")]
    public TextMeshProUGUI displayText;// TMP text for each slide
    public string[] slideTexts;// text for each slide

    [Header("Events")]
    public UnityEvent onSlideshowEnd; //event triggered when slideshow finishes

    private int currentSlideIndex = 0;
    private bool isPlaying = false;

    public void Start()
    {
        if (displayImage == null || slides.Length == 0)
        {
            Debug.LogError("SlideshowCutscene: Missing displayImage or slides.");
            return;
        }

        if (displayText != null && slideTexts.Length != slides.Length)
        {
            Debug.LogWarning("Slide texts count does not match slides count.");
        }

        StartCoroutine(PlaySlideshow());
    }

    private IEnumerator PlaySlideshow()
    {
        isPlaying = true;

        displayImage.color = new Color(1, 1, 1, 0); // Start transparent

        if (displayText != null)
            displayText.alpha = 0f; // Start text transparent

        while (currentSlideIndex < slides.Length)
        {
            displayImage.sprite = slides[currentSlideIndex];

            if (displayText != null && currentSlideIndex < slideTexts.Length)
                displayText.text = slideTexts[currentSlideIndex];

            //fade in
            yield return StartCoroutine(FadeVisuals(0f, 1f));

            //wait for duration or key press
            if (autoAdvance)
            {
                float timer = 0f;

                while (timer < slideDuration)
                {
                    if (Input.GetKeyDown(nextKey))
                        break;

                    timer += Time.deltaTime;
                    yield return null;
                }
            }
            else
            {
                yield return new WaitUntil(() => Input.GetKeyDown(nextKey));
            }

            //fade out
            yield return StartCoroutine(FadeVisuals(1f, 0f));

            currentSlideIndex++;
        }

        isPlaying = false;

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0); // fallback to main menu
        }

        onSlideshowEnd?.Invoke();
    }

    private IEnumerator FadeVisuals(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;

        Color imageColor = displayImage.color;

        float textStartAlpha = displayText != null ? displayText.alpha : 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / fadeDuration);

            // Image fade
            imageColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            displayImage.color = imageColor;

            // Text fade
            if (displayText != null)
            {
                displayText.alpha = Mathf.Lerp(startAlpha, endAlpha, t);
            }

            yield return null;
        }
    }
}