using UnityEngine;

public class GenericParticule
{
    public GameObject ParticuleGO;

    public float LifeTime { get; set; } = 10.0f;
    public float Force { get; protected set; } = 1.1f;

    public GenericPlayer player { get; set; }

    public GenericParticule(GameObject ParticulePrefab, GenericPlayer player)
    {
        this.player = player;
        if (ParticuleGO == null)
        {
            Vector3 partSpawnPosition;
            if (player.Particules.Count == 0)
                partSpawnPosition = player.ParticuleSpawn.position + ((Vector3)Random.insideUnitCircle.normalized);
            else
                partSpawnPosition = player.ParticuleSpawn.position + ((Vector3)Random.insideUnitCircle.normalized);

            ParticuleGO = GameObject.Instantiate(ParticulePrefab, partSpawnPosition, Quaternion.identity, player.ParticuleSpawn);
        }
    }
}
