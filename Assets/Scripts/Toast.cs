using UnityEngine;
using TMPro;

public class Toast : MonoBehaviour
{
    public GameObject toast;

    // Start is called before the first frame update
    void Start()
    {
        toast.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowToast()
    {
        toast.SetActive(true);
        Invoke(nameof(HideToast), 1f);
    }

    public void HideToast()
    {
        toast.SetActive(false);
    }
}
