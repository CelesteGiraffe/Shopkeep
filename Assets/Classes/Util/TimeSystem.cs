using TMPro;
using UnityEngine;

public class TimeSystem : MonoBehaviour {

    public GameObject clockUIDay;
    public GameObject clockUIClock;

    public static int second, minute, hour, day, month, year;

    private string clockText;
    private string dayText;

    [SerializeField]
    private int MaxSeconds, MaxMinutes, MaxHours, MaxDays, MaxMonths;

    [SerializeField]
    private int[] currentTime = new int[] { 0, 0, 0, 0, 0, 0 };

    [SerializeField]
    private int L_TimeScale = 30;

    private float SecondCount = 1f;

    public void Start() {  
        SetTime(currentTime);
        UpdateUI();
    }

    public void Update() {
        SecondCount -= Time.deltaTime;
        CalculateTime();
    }

    public int[] GetTime() {
        return new int[] { second, minute, hour, day, month, year };
    }

    public void SetTime(int[] time) {
        second = time[0];
        minute = time[1];
        hour = time[2];
        day = time[3];
        month = time[4];
        year = time[5];
    }

    private void CalculateTime() {
        if (SecondCount <= 0) {
            second += L_TimeScale;

            if (second >= MaxSeconds) {
                minute++;
                second = 0;
                UpdateUI();
            }
            if (minute >= MaxMinutes) {
                hour++;
                minute = 0;
                Debug.Log($"{currentTime[2]} : {currentTime[1]} : {currentTime[0]}");
                UpdateUI();
            }
            if (hour >= MaxHours) {
                day++;
                hour = 0;
                UpdateUI();
            }
            if (day > MaxDays) {
                month++;
                day = 1;
                UpdateUI();
            }
            if (month > MaxMonths) {
                month = 1;
                year++;
            }
            SecondCount = 1f;
        }
    }

    private void UpdateUI() {
        Debug.Log("Updating UI");
        dayText = "Day: " + day.ToString();
        if (minute < 10) {
            clockText = "Time: \n" + hour.ToString() + ":0" + minute.ToString();
        }
        else {
            clockText = "Time: \n" + hour.ToString() + ":" + minute.ToString();
        }
        
        // find the respective textmeshpro component of the clockUI object and set the text to dayText
        clockUIDay.GetComponent<TextMeshProUGUI>().text = dayText;
        clockUIClock.GetComponent<TextMeshProUGUI>().text = clockText;
    }
}