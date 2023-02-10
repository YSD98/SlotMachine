using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    public Text[] slotNumbers;
    public float rollTime,timee;
    public bool roll;
    public Button rollBtn;
    public InputField userNumber;
    private void Start()
    {
        timee = rollTime;
        rollBtn.onClick.AddListener(RollButtonClick);
    }
    void Update()
    {
        if(roll)
        {
            timee -= Time.deltaTime;
            if(timee > 0)
            {
                RandomRoll();
            }
            rollBtn.gameObject.SetActive(true);
        }
        
        if (timee <= 0)
        {
            if (userNumber.text == slotNumbers[0].text)
                Debug.Log("WINN...!!");
            else
                Debug.Log("LOOSE");
            roll = false;
            timee = rollTime;
        } 
    }
    void RandomRoll()
    {
        foreach (Text slot in slotNumbers)
        {
            slot.text = Random.Range(0, 10).ToString();
        }
    }

    private void RollButtonClick()
    {
        roll = true;
        rollBtn.gameObject.SetActive(false);
    }
}
