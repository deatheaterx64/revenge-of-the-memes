using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public float energy = 100f;
    public float pushForce = 25f;

    public GameObject AttackArea;

    public int sampleWindow = 128;
    private AudioClip microphoneClip;
    public float loudnessThreshold = 0.2f;
    public float loudnessSensibility = 100f;


    private void Start()
    {
        MicrophoneToAudioClip();        
    }

void Update()
    {
        float loudness = GetLoudnessFromMicrophone(Microphone.GetPosition(Microphone.devices[0]), microphoneClip) * loudnessSensibility;
        print(loudness>loudnessThreshold);
        if(Input.GetMouseButtonDown(0))
            StartCoroutine(nameof(Attack));
        if (loudness > loudnessThreshold)
        {
            StartCoroutine(nameof(Attack));
        }
    }

    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        foreach (string item in Microphone.devices)
        {
        print(item);

        }
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
        if(microphoneClip != null)
        print("meh");
    }

    public float GetLoudnessFromMicrophone(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if(startPosition < 0)
            return 0;

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0f;

        for (int i = 0; i < sampleWindow; i++)
            totalLoudness += Mathf.Abs(waveData[i]);
        return totalLoudness / sampleWindow;
    }

    IEnumerator Attack()
    {
        AttackArea.SetActive(true);
        
        //start audio cue

        yield return new WaitForSeconds(0.05f);
        AttackAreaOfEffect attackAreaOfEffect = AttackArea.GetComponent<AttackAreaOfEffect>();
        List<GameObject> enemies = attackAreaOfEffect.GetEnemiesAffected();
        AttackArea.SetActive(false);
        //foreach(GameObject enemy in enemies)
        //print(enemy.name);
        Shout(enemies);
        attackAreaOfEffect.ResetList();
    }

    void Shout(List<GameObject> enemies)
    {
        foreach(GameObject enemy in enemies)
        {
            CharacterRagdoll ragdoll = enemy.GetComponent<CharacterRagdoll>();
            if (ragdoll != null)
                ragdoll.EnableRagdoll(true);
            GameManager.enemiesKilled++;
            foreach(Rigidbody rb in ragdoll.ragdollRigidBodies)
                rb.AddExplosionForce(pushForce, transform.position, 20, 0.5f, ForceMode.Impulse);
        }
    }

    //get attacked

    public void OnAttacked(float damage)
    {
        health -= damage;
        print("lost "+ damage +" health");
        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().OnDeath();
            Cursor.lockState = CursorLockMode.None;
            GetComponent<FirstPersonController>().enabled = false;
            this.enabled = false;
        }

    }
}