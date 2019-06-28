using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField]
    private Range speed;

    private void Awake() => speed.Evaluate();

    private void Update() =>
         transform.eulerAngles += speed.Value * Vector3.forward * Time.smoothDeltaTime;
}
