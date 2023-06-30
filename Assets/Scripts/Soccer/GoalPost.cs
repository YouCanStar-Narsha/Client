using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    public int Score = 0;
    
    public void Goal()
    {
        print("°ñ");
        particle.Play();
        Score++;
    }
}
