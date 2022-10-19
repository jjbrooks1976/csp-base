using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject instance;
    public Simulation simulation;

    public Toggle errorCorrectionToggle;
    public Toggle correctionSmoothingToggle;
    public Toggle redundantInputToggle;
    public Toggle serverPlayerToggle;
    public Text packetLossLabel;
    public Slider packetLossSlider;
    public Text serverLatencyLabel;
    public Slider serverLatencySlider;
    public Text snapshotRateLabel;
    public Slider snapshotRateSlider;

    public void Start()
    {
        this.errorCorrectionToggle.isOn = true;
        this.correctionSmoothingToggle.isOn = true;
        this.redundantInputToggle.isOn = true;
        this.serverPlayerToggle.isOn = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            this.instance.SetActive(!this.instance.activeSelf);
        }
    }

    public void OnErrorCorrectionToggled(bool value)
    {
    }

    public void OnCorrectionSmoothingToggled(bool value)
    {
    }

    public void OnRedundantInputToggled(bool value)
    {
    }

    public void OnServerPlayerToggled(bool value)
    {
    }

    public void OnPacketLossChanged(float value)
    {
        this.packetLossLabel.text = string.Format("Packet Loss - {0:F1}%", value * 100.0f);
    }

    public void OnServerLatencyChanged(float value)
    {
        this.serverLatencyLabel.text = string.Format("Server Latency - {0}ms", (int)(value * 1000.0f));
    }

    public void OnSnapshotRateChanged(float value)
    {
        uint rate = (uint)Mathf.Pow(2, value);
        this.snapshotRateLabel.text = string.Format("Snapshot Rate - {0}hz", 64 / rate);
    }
}
