using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStruct : MonoBehaviour
{
    public enum GameTag
    {
        Player,
        Block,
        DeadZone
    }

    public enum GameLayer
    {
        Player,
        Block,
        Dead
    }

    public enum ChacAnim
    {
        Idle,
        Jump,
        Land,
        Dead
    }

    public enum GamePref
    {
        BestScore,
        LevelUnlocked,
        CurLevelId,
        IsMusicOn,
        IsSoundOn
    }

    public enum GameScene
    {
        MainMenu,
        GamePlay
    }

    public enum MoveDirection
    {
        Left,
        Right
    }

    public enum GameState
    {
        Starting,
        Playing,
        Gameover
    }
}
