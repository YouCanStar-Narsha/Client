using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public int score;
    [SerializeField] private float generationCycle = 1;
    [SerializeField] private int generationSize = 3;
	[SerializeField] private List<GameObject> foodPrefabs = new List<GameObject>();
	[SerializeField] private List<GameObject> foods = new List<GameObject>();


    private void Start()
    {
        StartCoroutine("MakeFood");
    }

    private IEnumerator MakeFood()
    {
        while (true)
        {
            for (int num = 0; num < generationSize; num++)
            {
                bool isMake = false;
                if (foods.Count > 0)
                {
                    for (int i = 0; i < foods.Count; i++)
                    {
                        if (foods[i].active == false && !isMake)
                        {
                            //print("num = " + i);
                            foods[i].SetActive(true);
                            foods[i].GetComponent<Food>().Respawn();
                            isMake = true;
                        }
                    }
                }
                if (!isMake)
                {
                    foods.Add(Instantiate(foodPrefabs[Random.Range(0, foodPrefabs.Count)], new Vector3(0, -1, 0), Quaternion.identity));
                    foods[foods.Count - 1].GetComponent<Food>().Respawn();
                    //print("make = " + foods.Count);
                }
            }
            yield return new WaitForSeconds(generationCycle);
		}
    }
}
