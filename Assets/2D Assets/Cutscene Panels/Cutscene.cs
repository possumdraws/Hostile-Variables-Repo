using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    [Header("Slideshow Settings")]
    public Image displayImage;        // UI Image to show slides
    public Sprite[] slides;           //array of slide images
    public float slideDuration = 3f;  // time each slide is shown (if autoAdvance is true)
    public float fadeDuration = 1f;   //fade in/out time
    public bool autoAdvance = true;   // automatically go to next slide
    public KeyCode nextKey = KeyCode.Space; //key to advance manually

    [Header("Events")]
    public UnityEvent onSlideshowEnd; //event triggered when slideshow finishes

    private int currentSlideIndex = 0;
    private bool isPlaying = false;

    void Start()
    {
        if (displayImage == null || slides.Length == 0)
        {
            Debug.LogError("SlideshowCutscene: Missing displayImage or slides.");
            return;
        }
        StartCoroutine(PlaySlideshow());
    }

    private IEnumerator PlaySlideshow()
    {
        isPlaying = true;
        displayImage.color = new Color(1, 1, 1, 0); // Start transparent

        while (currentSlideIndex < slides.Length)
        {
            displayImage.sprite = slides[currentSlideIndex];

            //fade in
            yield return StartCoroutine(FadeImage(0f, 1f));

            //wait for duration or key press
            if (autoAdvance)
            {
                yield return new WaitForSeconds(slideDuration);
            }
            else
            {
                yield return new WaitUntil(() => Input.GetKeyDown(nextKey));
            }

            //fade out
            yield return StartCoroutine(FadeImage(1f, 0f));

            currentSlideIndex++;
        }

        isPlaying = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator FadeImage(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;
        Color c = displayImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / fadeDuration);
            c.a = Mathf.Lerp(startAlpha, endAlpha, t);
            displayImage.color = c;
            yield return null;
        }
    }
}
