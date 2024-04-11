using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

// requires particles for showing power
[RequireComponent(typeof(ParticleSystem))]
public class ConduitPowerableEndpoint : PseudoPowerable
{

    public string id;
    private Dictionary<string, bool> TXs;
    public List<PseudoPowerable> permanentConnections;
    public UnityEvent justPowered;
    private ParticleSystem particles;

    void Awake() {
        this.TXs = new Dictionary<string, bool>();
        this.isRecvFromPermanentConnections = false;
        this.particles = GetComponent<ParticleSystem>();
        this.particles.Stop();
    }

    void Update() {
        this.RX();
    }

    public void OnTriggerEnter(Collider other) {
        ConduitPowerableEndpoint otherConduit = other.GetComponentInChildren<ConduitPowerableEndpoint>();
        print("Enter " + otherConduit?.id);
        if (other.GetComponent<ConduitPowerableEndpoint>() != null && otherConduit?.id != "") {
            this.TXs.Add(otherConduit?.id, otherConduit.isPowered());
        }
    }

    public void OnTriggerExit(Collider other) {
        ConduitPowerableEndpoint otherConduit = other.GetComponentInChildren<ConduitPowerableEndpoint>();
        print("Exit " + otherConduit?.id);
        if (other.GetComponent<ConduitPowerableEndpoint>() != null && this.TXs.ContainsKey(otherConduit?.id)) {
            this.TXs.Remove(otherConduit?.id);
        }
        string keyList = "";
        foreach (string s in this.TXs.Keys.ToList<String>()) {
            keyList += s + " ";
        }
        print("Remaining keys: " + keyList);
    }

    public void RX() {
        PoweredState result = PoweredState.UNPOWERED;
        PoweredState oldState = this.powered;
        foreach (KeyValuePair<string, bool> KVP in this.TXs)
        {
            if (KVP.Value) {
                result = PoweredState.POWERED;
            }
        }
        if (this.permanentConnections != null) {
            foreach (PseudoPowerable endpoint in this.permanentConnections) {
                if (endpoint.isPowered() && !endpoint.isRecvFromPermanentConnections) {
                    result = PoweredState.POWERED;
                    if (this.permanentConnections.Count > 0) {
                        this.isRecvFromPermanentConnections = true;
                    }
                }
            }
        }
        // check if newly powered from unpowered state
        if (oldState == PoweredState.UNPOWERED && result == PoweredState.POWERED) {
            print("JustPowered " + this.id + " with " + this.TXs.ToString());
            justPowered.Invoke();
            this.particles.Play();
        }
        // check if newly unpowered from unpowered state
        if (oldState == PoweredState.POWERED && result == PoweredState.UNPOWERED) {
            print("JustUNPowered " + this.id + " with " + this.TXs.ToString());
            this.particles.Stop();
        }
        if (result == PoweredState.UNPOWERED) {
            this.isRecvFromPermanentConnections = false;
        }
        this.powered = result;
    }
    
}

