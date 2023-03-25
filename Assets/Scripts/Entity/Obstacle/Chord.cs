using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chord : Entity
{
    public Vector2 startVelocity;

    public Vector2 velocity;

    public Rigidbody2D rb;

    public List<ChordPart> chordParts = new List<ChordPart>();

    private int chordSize;

    private List<GuitarString> currentStrings = new List<GuitarString>();
    private void OnEnable()
    {
        CreateChord();
    }

    private void Start()
    {
        velocity = startVelocity;
    }

    public void CreateChord()
    {
        DisableAllChordParts();

        SetChordSize();

        SetCurrentStrings();

        PositionChordParts();

        EnableChordParts();
    }

    public void SetChordSize()
    {
        chordSize = Random.Range(2, 4);
    }

    public void DisableAllChordParts()
    {
        for (int i = 0; i < chordParts.Count; i++)
        {
            chordParts[i].gameObject.SetActive(false);
        }
    }

    public void EnableChordParts()
    {
        for (int i = 0; i < chordSize; i++)
        {
            chordParts[i].gameObject.SetActive(true);
        }
    }

    public void PositionChordParts()
    {
        for (int i = 0; i < chordSize; i++)
        {
            chordParts[i].transform.position = new Vector2(chordParts[i].transform.position.x, currentStrings[i].spawnCenter.position.y);
        }
    }

    public void SetCurrentStrings()
    {
        currentStrings.Clear();

        for (int i = 0; i < chordSize; i++)
        {
            currentStrings.Add(GetAvailableGuitarString());
        }
    }

    public GuitarString GetAvailableGuitarString()
    {
        GuitarString guitarString = GuitarStrings.instance.strings[Random.Range(0, 6)];

        if (!currentStrings.Contains(guitarString))
        {
            return guitarString;
        }
        else
        {
            return GetAvailableGuitarString();
        }
    }

    public override void MakeAvailable()
    {
        velocity = startVelocity;

        gameObject.SetActive(false);

        MakeChordPartsAvailable();

        isAvailable = true;
    }
    public void MakeChordPartsAvailable()
    {
        foreach(ChordPart cp in chordParts)
        {
            cp.MakeAvailable();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity * Time.fixedDeltaTime;
    }
}
