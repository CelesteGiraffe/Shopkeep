using UnityEngine;
using UnityEngine.UI;

public class TimeSystem : MonoBehaviour {

    public Text clockText;
    public Text dayText;
    public Text monthText;
    public Text yearText;

    public static int second, minute, hour, day, month, year;

    [SerializeField]
    private int MaxSeconds, MaxMinutes, MaxHours, MaxDays, MaxMonths;

    [SerializeField]
    private int[] currentTime = new int[] { 0, 0, 0, 0, 0, 0 };

    [SerializeField]
    private const int l_TimeScale = 60;

    public void Start() {
        SetTime(currentTime);
    }

    public void Update() {
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
        second += (int)(Time.deltaTime * l_TimeScale);

        if (second >= MaxSeconds) {
            minute++;
            second = 0;
            UpdateUI();
        }
        else if (minute >= MaxMinutes) {
            hour++;
            minute = 0;
            UpdateUI();
        }
        else if (hour >= MaxHours) { 
            day++;
            hour = 0;
            UpdateUI();
        }
        else if (day >= MaxDays) {
            CalculateMonth();
        }
        else if (month >= MaxMonths) {
            month = 0;
            year++;
            UpdateUI();
        }
    }

    private void UpdateUI() {
        dayText.text = "Day: " + day.ToString();
        clockText.text = "Time: " + hour.ToString() + ":" + minute.ToString();
        monthText.text = "Month: " + month.ToString();
        yearText.text = "Year: " + year.ToString();
    }

    private void CalculateMonth() {
        if (day >= 14) {
            month++;
            day = 0;
            UpdateUI();
        }
        if (month >= 4) {
            month = 0;
            year++;
            UpdateUI();
        }
    }
}
