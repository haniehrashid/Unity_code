using UnityEngine;
using UnityEngine.Audio;

public class PivotController : MonoBehaviour
{
    float speedThreshold = 1e-30f; // Minimum rotation angle to trigger the sound
    //public float rotationSpeedMultiplier = 0.1f; // Multiplier for adjusting the low-pass filter based on rotation speed

    //bool hasTriggered; // Flag to track if the sound has already been triggered
    Quaternion previousRotation; // Initial rotation of the game object
    AudioSource audioSource; // Reference to the AudioSource component
    public double rotationSpeed = 0;

    private void Start()
    {
        // Store the initial rotation
        previousRotation = transform.rotation;
        audioSource = GetComponent<AudioSource>();
        // audioSource.Play();
    }



private void Update()
    {
        // Calculate the current rotation angle difference
        Quaternion rot = transform.rotation;
        float rotationAngle = Quaternion.Angle(previousRotation, rot);
        //if (rotationAngle > 0.0000001f)
        //{
        //    Debug.Log("rotationAngle: " + rotationAngle);
        //}

        // Calculate the rotation speed based on the difference between previous and current rotations
        double instantRotationSpeed = rotationAngle / Time.deltaTime;
        rotationSpeed += (instantRotationSpeed - rotationSpeed) * 0.9f;

        // Check if the rotation angle exceeds the threshold and the sound hasn't been triggered yet
        if (rotationSpeed > speedThreshold && !audioSource.isPlaying)
        {
            // Play the sound
            audioSource.Play();
            Debug.Log("Played sound!");
        }

        if (audioSource.isPlaying)
        {
            //Debug.Log(rotationSpeed);
            // Adjust the low-pass filter based on the rotation speed
            float volume = Mathf.InverseLerp(0, 30, (float)rotationSpeed);
            audioSource.volume = volume;
        }

        // Check if the rotation angle is below the threshold and the sound has been triggered
        if (rotationSpeed < speedThreshold && audioSource.isPlaying)
        {
            audioSource.Pause();

            // Reset the flag to false
            Debug.Log("Stopped sound");
        }

        previousRotation = rot;
    }

    //private void UpdateOLD()
    //{
    //    // Calculate the current rotation angle difference
    //    float rotationAngle = Quaternion.Angle(initialRotation, transform.rotation);

    //    // Calculate the rotation speed based on the difference between previous and current rotations
    //    float rotationSpeed = rotationAngle / Time.deltaTime;
        
    //    // Check if the rotation angle exceeds the threshold and the sound hasn't been triggered yet
    //    if (rotationAngle > rotationThreshold && !hasTriggered)
    //    {
    //        // Play the sound
    //        audioSource.Play();

    //        // Adjust the low-pass filter based on the rotation speed
    //        float cutoffFrequency = rotationSpeed * rotationSpeedMultiplier;
    //        lowPassFilter.cutoffFrequency = Mathf.Clamp(cutoffFrequency, 10f, 1000f);
    //        Debug.Log("Played sound!");
            
    //        // Set the flag to true
    //        hasTriggered = true;

    //        initialRotation = transform.rotation;
    //    }

    //    // Check if the rotation angle is below the threshold and the sound has been triggered
    //    if (rotationAngle < rotationThreshold && hasTriggered)
    //    {
    //        // Reset the low-pass filter cutoff frequency to its initial value
    //        lowPassFilter.cutoffFrequency = 1000f;

    //        // Reset the flag to false
    //        hasTriggered = false;
    //        Debug.Log("Reset");
    //    }
    //}
    
}