using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPresentFall : MonoBehaviour
{
    public float delayBetweenEachPresent;
    public float fallingSpeed;
    private float _currentDelay;
    public float xMin, xMax;
    public float yMax;
    public List<GameObject> possiblePresents = new List<GameObject>();
    private List<GameObject> _availablePresents = new List<GameObject>();

    private void Start()
    {
        _currentDelay = 0;

        foreach (var present in possiblePresents)
        {
            present.SetActive(false);
        }

        _availablePresents.AddRange(possiblePresents);
    }

    private void Update()
    {
        _currentDelay -= fallingSpeed * Time.deltaTime;

        if (_currentDelay <= 0 && _availablePresents.Count > 0)
        {
            var randomPresent = _availablePresents[Random.Range(0, _availablePresents.Count - 1)];
            var randomX = Random.Range(this.transform.position.x + xMin, this.transform.position.x + xMax);

            randomPresent.SetActive(true);
            randomPresent.transform.position = new Vector3(randomX, this.transform.position.y, this.transform.position.z);
            randomPresent.transform.rotation = Random.rotation;

            _currentDelay = delayBetweenEachPresent;
            _availablePresents.Remove(randomPresent);
        }

        foreach (var present in possiblePresents)
        {
            if (present.activeSelf)
            {
                var newPos = present.transform.position;
                newPos.y -= Time.deltaTime;
                present.transform.position = newPos;

                if (present.transform.position.y <= yMax)
                {
                    present.SetActive(false);
                    _availablePresents.Add(present);
                }
            }
        }
    }
}
