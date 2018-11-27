using UnityEngine;
using System.Collections.Generic;

public class BreakGlass : MonoBehaviour {
    public List<GameObject> BrokenGlassGO; // The broken glass GameObject
    GameObject BrokenGlassInstance;
    public bool BreakSound = true;
    public GameObject SoundEmitter; //An object that will emit sound
    public float SoundEmitterLifetime = 2.0f;
    public float ShardsLifetime = 3.0f; //Lifetime of shards in seconds (0 if you don't want shards to disappear)
    public float ShardMass = 0.5f; //Mass of each shard
    public Material ShardMaterial;

    public bool BreakByVelocity = true;
    public float BreakVelocity = 2.0f;

    public bool BreakByImpulse = false;
    public float BreakImpulse = 2.0f; // Impulse of rigidbody Impulse = Mass * Velocity.magnitude

    public bool BreakByClick = false;

    public float SlowdownCoefficient = 0.6f; // Percent of speed that hitting object has after the hit 



    /*
	/ If you want to break the glass call this function ( myGlass.SendMessage("BreakIt") )
	*/
    public void BreakIt() {
        BrokenGlassInstance = Instantiate(BrokenGlassGO[Random.Range(0, BrokenGlassGO.Count)], transform.position, transform.rotation) as GameObject;

        for (int i = BrokenGlassInstance.transform.childCount-1; i >= 0; i--) {
            Transform c = BrokenGlassInstance.transform.GetChild(i);

            c.GetComponent<Renderer>().material = ShardMaterial;
            c.GetComponent<Rigidbody>().mass = ShardMass;
            c.parent = null;
            if (ShardsLifetime > 0) Destroy(c.gameObject, ShardsLifetime);
        }


        if (BreakSound) Destroy(Instantiate(SoundEmitter, transform.position, transform.rotation) as GameObject, SoundEmitterLifetime);
        Destroy(gameObject);

    }

    void OnMouseDown() {
        if (BreakByClick) BreakIt();
    }
}
