using UnityEngine;

public class GenericParticule
{
    public GameObject ParticuleGO;

    public GenericParticule(GameObject ParticulePrefab)
    {
        if (ParticuleGO == null)
        {
            GenericPlayer player = GameStateContext.Player1;
            Vector3 partSpawnPosition = new(player.ParticuleSpawn.position.x + (100 * player.Particules.Count), player.ParticuleSpawn.position.y, player.ParticuleSpawn.position.z);

            ParticuleGO = GameObject.Instantiate(ParticulePrefab, partSpawnPosition, Quaternion.identity, player.ParticuleSpawn);
        }
    }
}
