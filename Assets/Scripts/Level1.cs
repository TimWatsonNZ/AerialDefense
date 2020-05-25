using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level
{
    protected override void FillSpawners()
    {
        base.FillSpawners();

        //spawnManager.AddTransport(0,
        //    new Vector2(-Utility.GetScreenWidth() - 2, Utility.GetScreenHeight() - 1),
        //    new Vector3(1, 0, 0)
        //);

        spawnManager.AddSpitfire(0,
            new Vector2(-Utility.GetScreenWidth() - 2, Utility.GetScreenHeight() - 2),
            new Vector3(1, 0, 0)
        );

        spawnManager.AddSpitfire(0,
            new Vector2(Utility.GetScreenWidth() + 2, Utility.GetScreenHeight() - 2),
            new Vector3(-1, 0, 0)
        );

        spawnManager.AddSpitfire(4,
            new Vector2(-Utility.GetScreenWidth() - 2, Utility.GetScreenHeight() - 4),
            new Vector3(1, 0, 0)
        );

        spawnManager.AddSpitfire(4,
            new Vector2(Utility.GetScreenWidth() + 2, Utility.GetScreenHeight() - 4),
            new Vector3(-1, 0, 0)
        );

        //spawnManager.AddBomber(0,
        //    new Vector2(-Utility.GetScreenWidth() - 2, Utility.GetScreenHeight() - 3),
        //    new Vector3(1, 0, 0)
        //);
    }
}
