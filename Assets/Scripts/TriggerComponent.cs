using UnityEngine;
using UnityEngine.Events;

public class TriggerComponent : MonoBehaviour
{
    [SerializeField] private string tag;
    [SerializeField] private UnityEvent onTriggerEnterEvent;
    [SerializeField] private UnityEvent onTriggerExitEvent;
    [SerializeField] private UnityEvent onTriggerStayEvent;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            onTriggerEnterEvent?.Invoke();
        }
    } 
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tag))
        {
            onTriggerExitEvent?.Invoke();
        }
    } 
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(tag))
        {
            onTriggerStayEvent?.Invoke();
        }
    }
}
