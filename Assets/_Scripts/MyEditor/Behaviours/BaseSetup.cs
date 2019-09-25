using UnityEngine;

public class BaseSetup : MonoBehaviour
{

	// G L O B A L   S T A T I C
	// ~~~~~~~~~~~~~~~~~~~~~~~~~
	protected static bool debug_AttackDisabled;
	protected static bool debug_MovementDisabled;
	protected static bool debug_TileMapDisabled;


	// C O N S T A N T S
	// ~~~~~~~~~~~~~~~~~
	// global difficulty levels
	protected const int NORMAL 								= 1;
	protected const int HARD 								= 2;
	protected const int EPIC 								= 3;

	// global measurements
	protected const float ONE_PIXEL 						= .03125f;
	protected const float ONE_COLLIDER_PIXEL 				= .625f;
	protected const float ONE_SPRITE_HUD_PIXEL 				= 14.0625f;

	// global default culling distance
	protected const float CULL_DISTANCE 					= 20f;

	// gameObject names
	protected const string _DATA 							= "_Data";
	protected const string PLAYER 							= "Player";
	protected const string TILE_MAP 						= "TileMap";
	protected const string GAME_MANAGER 					= "GameManager";
	protected const string PICKUPS 							= "Pickups";

	// layer names
	protected const int PLAYER_DEFAULT_LAYER 				= 8;
	protected const int PLAYER_PHYSICS_LAYER 				= 8;
	protected const int PLAYER_BODY_COLLIDER 				= 10;
	protected const int PLAYER_WEAPON_COLLIDER 				= 9;
	protected const int ENEMY_BODY_COLLIDER 				= 14;
	protected const int ENEMY_WEAPON_COLLIDER 				= 17;
	protected const int BREAKABLES 							= 18;
	protected const int EDGE_BLOCKER 						= 24;
	protected const int PICKUP_LAYER 						= 15;
	protected const int PICKUP_PHYSICS_LAYER 				= 16;
	protected const int PLATFORM_LAYER 						= 21;
	protected const int NO_COLLISION_LAYER 					= 30;

	// z order
	protected const float PLAYER_Z 							= -.3f;
	protected const float IN_FRONT_OF_PLAYER_Z 				= -.31f;
	protected const float BEHIND_PLAYER_Z 					= -.29f;
}