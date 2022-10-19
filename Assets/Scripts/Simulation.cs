using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Simulation : MonoBehaviour
{
    private struct Inputs
    {
        public bool up;
        public bool down;
        public bool left;
        public bool right;
        public bool jump;
    }

    private struct Command
    {
        public float deliveryTime;
        public uint startTickNumber;
        public List<Inputs> inputs;
    }

    private struct ClientState
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    private struct ServerState
    {
        public float deliveryTime;
        public uint tickNumber;
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 velocity;
        public Vector3 angularVelocity;
    }

    // common stuff
    public GameObject clientPlayer;
    public GameObject smoothedClientPlayer;
    public GameObject serverPlayer;
    public GameObject serverDisplayPlayer;
    public float latency = 0.1f;
    public float packetLoss = 0.05f;

    // client specific
    public bool errorCorrection = true;
    public bool correctionSmoothing = true;
    public bool redundantInput = true;

    // server specific
    public uint snapshotRate;

    void Start()
    {
    }

    void Update()
    {
    }
}
