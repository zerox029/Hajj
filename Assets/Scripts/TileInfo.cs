using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour {

    public bool replayTile;
    public bool questionTile;                                   

    public string getTileInfo()
    {
        if (replayTile)
            return "replay";
        else if (questionTile)
            return "question";
        else
            return null;
    }

}
