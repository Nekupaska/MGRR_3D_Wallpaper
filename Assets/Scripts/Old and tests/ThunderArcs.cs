using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderArcs : MonoBehaviour
{
    void StopParticle(ParticleSystem.Particle p)
    {
        p.velocity = Vector3.zero;
        p.position = endPos.position;
        //p.color = Color.black;
    }

    public ParticleSystem ps;
    public Transform endPos;

    // particles
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    //List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

    void OnParticleTrigger()
    {


        // get
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        //int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

        // iterate
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            //p.startColor = new Color32(255, 0, 0, 255);
            //enter[i] = p;
            StopParticle(p);


        }
        //print(enter.Count);

        //for (int i = 0; i < numExit; i++)
        //{
        //    ParticleSystem.Particle p = exit[i];
        //    //p.startColor = new Color32(0, 255, 0, 255);
        //    exit[i] = p;
        //}

        // set
        //ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        //ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    }

    /*public ParticleSystem ps;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    void OnParticleTrigger()
    {

        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        if (numEnter > 0)
        {
            print("A particle entered the trigger");
        }

    }*/

}
