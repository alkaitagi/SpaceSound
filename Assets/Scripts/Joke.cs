using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Joke : MonoBehaviour
{
    private void Start() =>
        GetComponent<Text>().text +=
            $"{StatsManager.Log["initialPoll"]["citizenship"]} counts on you! Good luck, {StatsManager.Log["initialPoll"]["name"]}!";
}
