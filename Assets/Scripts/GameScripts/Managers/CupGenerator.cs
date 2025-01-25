using UnityEngine;

public class CupGenerator : MonoBehaviour
{
    [SerializeField] public DraggableBobaTea cupPrefab;  // Assign the DraggableBobaTea prefab in the Inspector
    [SerializeField] private float spawnOffsetY = 1.0f;  // Offset above parent object
    [SerializeField] private float delayBetweenCups = 1.75f;  // Delay between cup spawns
    private float lastSpawnTime = 0.0f;
    private DraggableBobaTea currentCup;

    void Update()
    {
        CheckAndSpawnCup();
    }

    private void CheckAndSpawnCup()
    {
        // Check if the current cup still exists
        if (currentCup == null)
        {
            SpawnCup();

            lastSpawnTime += Time.deltaTime;
        }
    }

    private void SpawnCup()
    {
        if (cupPrefab != null && lastSpawnTime >= delayBetweenCups)
        {
            // Calculate spawn position (right above the parent's transform)
            Vector3 localSpawnPosition = transform.localPosition + new Vector3(0, spawnOffsetY, 0);

            // Instantiate the cup and set it as the current cup
            DraggableBobaTea newCup = Instantiate(cupPrefab, localSpawnPosition, Quaternion.identity);
            newCup.transform.parent = transform;  // Optional: Keep cup under the generator

            currentCup = newCup.GetComponent<DraggableBobaTea>();

            print("Cup spawned!");

            if (currentCup == null)
            {
                Debug.LogError("The spawned cup does not contain a DraggableBobaTea component.");
            }
        }
        else
        {
            Debug.LogError("Cup prefab is not assigned in the CupGenerator script.");
        }
    }
}
