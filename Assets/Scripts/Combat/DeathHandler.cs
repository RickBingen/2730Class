using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    void OnEnable()
    {
        Health.OnDeath += SpawnDeathSplatterPrefab;
        Health.OnDeath += SpawnDeathVFX;
    }

    void OnDisable()
    {
        Health.OnDeath -= SpawnDeathSplatterPrefab;
        Health.OnDeath -= SpawnDeathVFX;
    }


    void SpawnDeathSplatterPrefab(Health sender)
    {
        GameObject newSplatterPrefab = Instantiate(sender.SplatterPrefab, sender.transform.position, sender.transform.rotation);
        SpriteRenderer deathSplatterRenderer = newSplatterPrefab.GetComponent<SpriteRenderer>();
        ColorChanger colorChanger = sender.GetComponent<ColorChanger>();
        Color currentColor = colorChanger.DefaultColor;
        deathSplatterRenderer.color = currentColor;
        newSplatterPrefab.transform.SetParent(this.transform);
    }

    void SpawnDeathVFX(Health sender)
    {
        GameObject deathVFX = Instantiate(sender.DeathVFX, sender.transform.position, sender.transform.rotation);
        ParticleSystem.MainModule ps = deathVFX.GetComponent<ParticleSystem>().main;
        ColorChanger colorChanger = sender.GetComponent<ColorChanger>();
        Color currentColor = colorChanger.DefaultColor;
        ps.startColor = currentColor;
        deathVFX.transform.SetParent(this.transform);
    }
}
