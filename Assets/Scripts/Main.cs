using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject instance;

    public Simulation simulation;

    public GameObject serverDisplayPlayer;

    public Toggle errorCorrectionToggle;
    public Toggle correctionSmoothingToggle;
    public Toggle redundantInputToggle;
    public Toggle serverPlayerToggle;
    public Text packetLossLabel;
    public Slider packetLossSlider;
    public Text latencyLabel;
    public Slider latencySlider;
    public Text snapshotRateLabel;
    public Slider snapshotRateSlider;

    public void Start()
    {
        this.errorCorrectionToggle.isOn = true;
        this.correctionSmoothingToggle.isOn = true;
        this.redundantInputToggle.isOn = true;
        this.serverPlayerToggle.isOn = false;
        this.packetLossSlider.value = this.simulation.packetLoss;
        this.latencySlider.value = this.simulation.latency;
        this.snapshotRateSlider.value = Mathf.Log(this.simulation.snapshotRate, 2.0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            this.instance.SetActive(!this.instance.activeSelf);
        }
    }

    public void OnErrorCorrectionToggled(bool value)
    {
        this.simulation.errorCorrection = value;
        this.correctionSmoothingToggle.interactable = value;

    }

    public void OnCorrectionSmoothingToggled(bool value)
    {
        this.simulation.correctionSmoothing = value;
    }

    public void OnRedundantInputToggled(bool value)
    {
        this.simulation.redundantInput = value;
    }

    public void OnServerPlayerToggled(bool value)
    {
        this.serverDisplayPlayer.SetActive(value);
    }

    public void OnPacketLossChanged(float value)
    {
        this.packetLossLabel.text = string.Format("Packet Loss - {0:F1}%", value * 100.0f);
        this.simulation.packetLoss = value;
    }

    public void OnLatencyChanged(float value)
    {
        this.latencyLabel.text = string.Format("Latency - {0}ms", (int)(value * 1000.0f));
        this.simulation.latency = value;
    }

    public void OnSnapshotRateChanged(float value)
    {
        uint rate = (uint)Mathf.Pow(2, value);
        this.snapshotRateLabel.text = string.Format("Snapshot Rate - {0}hz", 64 / rate);
        this.simulation.snapshotRate = rate;
    }
}
