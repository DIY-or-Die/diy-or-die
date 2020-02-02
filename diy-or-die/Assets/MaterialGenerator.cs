using UnityEngine;

public class MaterialGenerator : MonoBehaviour
{
    public Droppable[] DroppablePrefabs;
    public float DropPeriod;
    public Car Car;
    public bool SpeedsUp;

    private float Timer;

    private void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer < 0)
        {
            DropMaterial();
            Timer += DropPeriod;
        }

        if (SpeedsUp)
        {
            if (Car.Traction < 1 || Car.Temperature < 1 || Car.Visibility < 1)
            {
                DropPeriod = 1;
            }
            else
            {
                DropPeriod = 3;
            }
        }
    }

    public void DropMaterial()
    {
        Droppable pref = DroppablePrefabs[Random.Range(0, DroppablePrefabs.Length)];
        Droppable mat = Instantiate(pref);
        mat.transform.SetPositionAndRotation(new Vector3(transform.position.x + (Random.value - .5f) * 10, transform.position.y + (Random.value - .5f) * 3), Quaternion.identity);
    }
}
