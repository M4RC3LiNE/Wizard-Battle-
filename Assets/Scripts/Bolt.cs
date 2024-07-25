using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Bolt : MonoBehaviour
{
    public SpellItem spell;
    [System.NonSerialized]public float rate;
    [System.NonSerialized]public float drag;
    [System.NonSerialized]public int segments;
    private int firedSegments = 0;
    public GameObject projectile;
    public GameObject player;
    private GameObject projectiles;
    public GameObject boltHolder;
    public GameObject currentBolt;
    

    public IEnumerator fireSegment(float n, Transform rot, Transform loc)
    {
        segments = spell.segments;
        while (firedSegments < segments)
        {
            projectiles = GameObject.Find("Projectiles");
            if (currentBolt)
            {
                var parent = currentBolt.transform;
                if (spell)
                {
                    projectile = spell.boltProjectile;
                    if (projectile)
                    {
                        var newSeg = Instantiate(projectile, this.transform.position, this.transform.rotation, parent);
                        if (newSeg)
                        {
                            newSeg.transform.Rotate(Spread(spell));
                            player.GetComponent<SpellCast>().UpdateSpellInfo(newSeg, spell);
                        }
                    }
                    
                }
                
            }
            
            yield return new WaitForSeconds(n * Time.deltaTime);
            firedSegments += 1;
            if (firedSegments > segments)
            {
                if (this)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        
    }
    Vector3 Spread (SpellItem spell)
    {
        var spread = new Vector3(Random.Range(-spell.boltSpread, spell.boltSpread),Random.Range(-spell.boltSpread, spell.boltSpread),Random.Range(-spell.boltSpread, spell.boltSpread));
        return spread;
    }

    

    void Update()
    {
        if (spell)
        {
            rate = spell.rate;
            segments = spell.segments;
            projectile = spell.boltProjectile;
            drag = spell.boltDrag;
        }
    }
    
}
