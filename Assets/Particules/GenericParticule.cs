using UnityEngine;

public class GenericParticule
{
    public GameObject ParticuleGO;

    public float LifeTime { get; protected set; } = 2.0f;
    public float Force { get; protected set; } = 1.1f;

    public GenericParticule(GameObject ParticulePrefab)
    {
        if (ParticuleGO == null)
        {
            GenericPlayer player = GameStateContext.Player1;
            Vector3 partSpawnPosition;
            if (player.Particules.Count == 0)
                partSpawnPosition = new(player.ParticuleSpawn.position.x, player.ParticuleSpawn.position.y, player.ParticuleSpawn.position.z);
            else
                partSpawnPosition = new(player.Particules[-1].ParticuleGO.transform.position.x + (100), player.ParticuleSpawn.position.y, player.ParticuleSpawn.position.z);

            ParticuleGO = GameObject.Instantiate(ParticulePrefab, partSpawnPosition, Quaternion.identity, player.ParticuleSpawn);
        }
    }
}
