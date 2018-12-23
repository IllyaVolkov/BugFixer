using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ErrorManager : MonoBehaviour
{
    public static int errorsCount = 0;
    public GameObject error;
    public Transform[] errorPoints;
    public float errorSpeed;

    private GameObject[] instances;
    private const int maxErrorsCount = 10;

    void Start()
    {
        instances = new GameObject[maxErrorsCount];
        for (int i = 0; i < errorsCount; i++)
        {
            Respawn(i);
        }
    }

    void Update()
    {
        for (int i = 0; i < errorsCount; i++)
        {
            if (instances[i] != null)
            {
                float step = errorSpeed * Time.deltaTime;
                instances[i].transform.position = Vector3.MoveTowards(instances[i].transform.position, errorPoints[i].position, step);
            }
        }
    }

    public void Spawn(Transform initialPoint)
    {
        if (errorsCount < maxErrorsCount)
        {
            instances[errorsCount] = Instantiate(error, initialPoint.position, initialPoint.rotation);
            errorsCount++;
        }
        if (errorsCount == maxErrorsCount)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void Spawn()
    {
        if (errorsCount < maxErrorsCount)
        {
            Transform endPoint = errorPoints[errorsCount];
            instances[errorsCount] = Instantiate(error, endPoint.position, endPoint.rotation);
            errorsCount++;
        }
        if (errorsCount == maxErrorsCount)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void Respawn(int index)
    {
        Transform endPoint = errorPoints[index];
        instances[index] = Instantiate(error, endPoint.position, endPoint.rotation);
    }
}
