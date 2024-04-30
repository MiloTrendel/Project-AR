using UnityEngine;

public class GenericParticule
{
    public GameObject ParticuleGO;

    public float LifeTime { get; set; } = 10.0f;
    public float Force { get; protected set; } = 1.1f;

    public GenericParticule(GameObject ParticulePrefab)
    {
        if (ParticuleGO == null)
        {
            GenericPlayer player = GameStateContext.Player1;
            Vector3 partSpawnPosition;
            if (player.Particules.Count == 0)
                partSpawnPosition = player.ParticuleSpawn.position + ((Vector3)Random.insideUnitCircle.normalized) * 100;
            else
                partSpawnPosition = player.ParticuleSpawn.position + ((Vector3)Random.insideUnitCircle.normalized) * 100;
            //partSpawnPosition = new(player.Particules.Last().ParticuleGO.transform.position.x + (100), player.ParticuleSpawn.position.y, player.ParticuleSpawn.position.z);

            ParticuleGO = GameObject.Instantiate(ParticulePrefab, partSpawnPosition, Quaternion.identity, player.ParticuleSpawn);
        }
    }
}
