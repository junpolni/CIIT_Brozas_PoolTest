using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillCount : MonoBehaviour
{
    public static int killCount = 0;
    [SerializeField] TextMeshProUGUI countText;

    // Start is called before the first frame update
    private void Start()
    {
        countText = GetComponent<TextMeshProUGUI>();
        killCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = $"Kill Count: {killCount}";
    }

    
}
