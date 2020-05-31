using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats
{
    // Stats physiques
    public int force;
    public int defense;
    public int adresse;
    public int agilite;
    public int vitesse;

    // Stats socials
    public int seduction;
    public int intimidation;
    public int rhetorique;
    public int premiereImpression;
    public int dressage;

    // Stats mentals
    public int magie;
    public int erudition;
    public int perception;
    public int resistanceMentale;
    public int sangFroid;

    public Stats()
    {

    }

    public Stats(Stats toCopy)
    {
        force = toCopy.force;
        defense = toCopy.defense;
        adresse = toCopy.adresse;
        agilite = toCopy.agilite;
        vitesse = toCopy.vitesse;

        seduction = toCopy.seduction;
        intimidation = toCopy.intimidation;
        rhetorique = toCopy.rhetorique;
        premiereImpression = toCopy.premiereImpression;
        dressage = toCopy.dressage;

        magie = toCopy.magie;
        erudition = toCopy.erudition;
        perception = toCopy.perception;
        resistanceMentale = toCopy.resistanceMentale;
        sangFroid = toCopy.sangFroid;
    }
}
