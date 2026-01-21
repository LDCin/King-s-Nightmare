using UnityEngine;

public class GameConfig
{
    // SCENE
    public static string MENU_SCENE = "Menu Scene";
    public static string MAP_1_SCENE = "Map 1";
    // ANIMATION
    // I. Player, Enemy
    public static string ATTACK_TRIGGER = "Attack";
    public static string JUMP_TRIGGER = "Jump";
    public static string HIT_TRIGGER = "Hit";
    public static string RUN_BOOL = "IsRunning";
    public static string DEAD_BOOL = "IsDead";
    public static string IDLE_BOOL = "IsIdle";
    public static string CLIMB_IDLE_BOOL = "IsClimbIdle";
    public static string CLIMB_TRIGGER = "Climb";
    // II. Bomb
    public static string EXPLODE_TRIGGER = "Explode";
    // III. Gate
    public static string OPEN_GATE_BOOL = "Open";

    // TRIGGER
    public static string PLAYER_HITBOX = "Player Hitbox";

    // TAG
    public static string PLAYER_TAG = "Player";
    public static string ENEMY_TAG = "Enemy";
    public static string BOMB_TAG = "Bomb";
    public static string CANNON_BALL_TAG = "Cannon Ball";
    public static string WALL_TAG = "Wall";
    public static string GROUND_TAG = "Ground";
    public static string SPECIAL_BASE_TAG = "Special Base";
    public static string BASE_TAG = "Base";
    public static string ROPE_LADDER_TAG = "Rope Ladder";
    public static string TOP_STEP_TAG = "Top Step";
    public static string GATE_TAG = "Gate";

    // PANEL
    public static string PANEL_PATH = "UI/Panels/";
    public static string SETTING_PANEL = "Panel - Setting";
    public static string PAUSE_PANEL = "Panel - Pause";

    // SOUND
    public static int BGM_STATE => PlayerPrefs.GetInt("BGMState", 1);
    public static int SFX_STATE => PlayerPrefs.GetInt("SFXState", 1);

    // PLAYER PREFS
    public static string SCORE = "Score";
    public static string TARGET_SCORE = "Target Score";
}