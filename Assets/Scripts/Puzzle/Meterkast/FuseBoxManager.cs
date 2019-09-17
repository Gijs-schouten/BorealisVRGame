using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxManager : MonoBehaviour
{
    [Header("Special Fuses")]
    [SerializeField] private FuseScript StartingFuse;
    [SerializeField] private FuseScript EndingFuse;
    [Space]
    [SerializeField] private int RequiredGoal;
    [SerializeField] private int ActivatedRequired;
    
    [Header("Fuses")]
    [SerializeField] private List<FuseScript> RequiredFuses = new List<FuseScript>();
    [Space]
    [SerializeField] private List<FuseScript> TotalFuses = new List<FuseScript>();

    private bool PuzzleSolved;

    void Start()
    {
        ResetGame();
    }


    void Update()
    {
        if (EndingFuse.IsActivated && !PuzzleSolved)
        {
            for (int i = 0; i < RequiredFuses.Count; i++)
            {
                if (RequiredFuses[i].IsActivated)
                    ActivatedRequired += 1;

                Debug.Log(ActivatedRequired);

                if(i == RequiredFuses.Count - 1)
                {
                    if (ActivatedRequired >= RequiredGoal)
                    {
                        //EndGame
                        Debug.Log("Puzzel opgelost!");
                        LockFuses();

                        PuzzleSolved = true;
                        break;
                    }
                    else
                    {
                        Debug.Log("Puzzel gefaald...");
                        ResetGame();
                    }
                }
            }
        }
    }

    private void ResetGame()
    {
        RequiredGoal = RequiredFuses.Count;

        for (int i = 0; i < TotalFuses.Count; i++)
        {
            TotalFuses[i].ResetFuse();
        }

        StartingFuse.Activate();
        EndingFuse.EnableEnding();

        ActivatedRequired = 0;
    }

    private void LockFuses()
    {
        foreach (FuseScript _fuse in TotalFuses)
        {
            _fuse.Turnable = false;
        }
    }
}
