using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class MDv2_Door : MonoBehaviour
{
    [Tooltip("The object that acts as a joint for the opening animation.\nShould be an empty GameObject that contains the door mesh as a child GameObject.")]
    public GameObject joint;
    private AudioSource audioSource;

    [Tooltip("Opening door sound effect.")]
    public AudioClip acOpenDoor;
    [Tooltip("Closing door sound effect.")]
    public AudioClip acCloseDoor;

    public enum DoorType { Swing, Slide, Trap };
    [Tooltip("Swing - Swinging door, pivots around Y axis -90 degrees.\nSlide - Sliding door, moves to TargetPosition.\nTrap - Swings open on X-axis instead.")]
    public DoorType doorType = DoorType.Swing;
    [Tooltip("Whether the door should open once and then ignore interaction.")]
    public bool stayOpen = false;
    [Tooltip("Whether the door should open automatically when in range.")]
    public bool isAutomatic = false;
    [Tooltip("The time it takes for the door to animate.")]
    [Range(0.1f, 10f)]
    public float animTime = 1f;

    private Quaternion sourceRotation;
    private Vector3 sourcePosition;
    [Header("ReverseRotation is only relevant to Swing and Trap door type.")]
    [Tooltip("Whether to reverse the direction of the rotation.")]
    public bool reverseRotation = false;
    [Header("TargetPosition is only relevant to Slide door type.")]
    [Tooltip("Position to interpolate to when sliding open. Relative position.")]
    public Vector3 targetPosition = new Vector3();

    private bool isInRange = false;
    private bool isDoorOpen = false;
    private bool animating = false;

    private void Start()
    {
        if (joint == null)
            Debug.LogError("Door joint object not set!", this);

        if (doorType == DoorType.Swing || doorType == DoorType.Trap)
            sourceRotation = joint.transform.rotation;
        else if (doorType == DoorType.Slide)
            sourcePosition = joint.transform.localPosition;

        audioSource = joint.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1f;
        audioSource.minDistance = 5f;
        audioSource.maxDistance = 50f;
    }

    /// <summary>
    /// Calls the DoorInteract coroutine. Use to access from other scripts.
    /// </summary>
    public void doorInteract()
    {
        StartCoroutine(DoorInteract());
    }

    public IEnumerator DoorInteract()
    {
        if (isAutomatic)
        {
            yield return new WaitWhile(() => animating == true);

            if (isInRange && isDoorOpen || isInRange && !isDoorOpen || !isInRange && isDoorOpen)
                yield return null;
            else if (!isInRange && !isDoorOpen)
                yield break;
        }

        if (animating)
        {
            yield break;
        }
        else
        {
            animating = true;
        }

        float timer = 0;
        float timerEnd = timer + animTime;

        if (isDoorOpen)
            audioSource.clip = acCloseDoor;
        else
            audioSource.clip = acOpenDoor;
        audioSource.Play();

        if (doorType == DoorType.Swing)
        {
            Vector3 targetEuler = sourceRotation.eulerAngles;
            if (reverseRotation)
                targetEuler.y += 90f;
            else
                targetEuler.y -= 90f;
            Quaternion targetRotation = Quaternion.Euler(targetEuler);

            while (timer < timerEnd)
            {
                if (isDoorOpen)
                    joint.transform.rotation = Quaternion.Lerp(targetRotation, sourceRotation, (timer / timerEnd));
                else
                    joint.transform.rotation = Quaternion.Lerp(sourceRotation, targetRotation, (timer / timerEnd));
                timer += Time.deltaTime;
                yield return null;
            }

            if (isDoorOpen)
                joint.transform.rotation = sourceRotation;
            else
                joint.transform.rotation = targetRotation;
        }
        else if (doorType == DoorType.Slide)
        {
            Vector3 tp = targetPosition + sourcePosition;

            while (timer < timerEnd)
            {
                if (isDoorOpen)
                    joint.transform.localPosition = Vector3.Lerp(tp, sourcePosition, (timer / timerEnd));
                else
                    joint.transform.localPosition = Vector3.Lerp(sourcePosition, tp, (timer / timerEnd));
                timer += Time.deltaTime;
                yield return null;
            }

            if (isDoorOpen)
                joint.transform.localPosition = sourcePosition;
            else
                joint.transform.localPosition = tp;
        }
        else if (doorType == DoorType.Trap)
        {
            Vector3 targetEuler = sourceRotation.eulerAngles;
            if (reverseRotation)
                targetEuler.x += 90f;
            else
                targetEuler.x -= 90f;
            Quaternion targetRotation = Quaternion.Euler(targetEuler);

            while (timer < timerEnd)
            {
                if (isDoorOpen)
                    joint.transform.rotation = Quaternion.Lerp(targetRotation, sourceRotation, (timer / timerEnd));
                else
                    joint.transform.rotation = Quaternion.Lerp(sourceRotation, targetRotation, (timer / timerEnd));
                timer += Time.deltaTime;
                yield return null;
            }

            if (isDoorOpen)
                joint.transform.rotation = sourceRotation;
            else
                joint.transform.rotation = targetRotation;
        }

        if (!stayOpen)
        {
            isDoorOpen = !isDoorOpen;
            animating = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
            if (isAutomatic)
                StartCoroutine(DoorInteract());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = false;
            if (isAutomatic)
                StartCoroutine(DoorInteract());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isInRange && !isAutomatic)
        {
            StartCoroutine(DoorInteract());
        }
    }
}