using Godot;
using System;

public partial class LaserDetect : Node2D
{
	[Export] public float LaserLength = 500f;
	[Export] public Color LaserColorNormal = Colors.Green;
	[Export] public Color LaserColorAlert = Colors.Red;
	[Export] public NodePath PlayerPath;
		
	private RayCast2D _rayCast;
	private Line2D _laserBeam;
	private Node2D _player;
	private bool _isAlarmActive = false;
	private Timer _alarmTimer;
		
	public override void _Ready()
	{
		SetupRaycast();
		SetupVisuals();
		// TODO: Get player reference
		if(PlayerPath != null && !PlayerPath.IsEmpty)
		{
			_player = GetNodeOrNull<Node2D>(PlayerPath);
		}
		if(_player == null)
		{
			var players = GetTree().GetNodesInGroup("player");
			if(players.Count > 0 && players[0] is Node2D p)
			{
				_player = p;
			}
		}
		// TODO: Setup alarm timer
		_alarmTimer = new Timer
		{
			OneShot = true,
			WaitTime = 1.0
		};
		_alarmTimer.Timeout += ResetAlarm;
		AddChild(_alarmTimer);
	}
		
	private void SetupRaycast()
	{
		// TODO: Create and configure RayCast2D
		// TODO: Set target position
		// TODO: Set collision mask to detect player
		// Hint: _rayCast = new RayCast2D();
		_rayCast = new RayCast2D
		{
			Enabled = true,
			CollideWithBodies = true,
			CollideWithAreas = true
		};
		_rayCast.TargetPosition = new Vector2(LaserLength, 0);
		AddChild(_rayCast);
	}
		
	private void SetupVisuals()
	{
		// TODO: Create Line2D for laser visualization
		_laserBeam = new Line2D
		{
			// TODO: Set width and color
			Width = 2f,
			DefaultColor = LaserColorNormal,
			// TODO: Add points for the line
			Points = new Vector2[] {Vector2.Zero, new Vector2(LaserLength, 0)},
			Antialiased = true
		};
		AddChild(_laserBeam);
	}
		
	public override void _PhysicsProcess(double delta)
	{
		// TODO: Force raycast update
		// TODO: Check if raycast is colliding
		// TODO: Get collision point
		// TODO: Update laser beam visualization
		// TODO: Check if hit object is player
		// TODO: Trigger alarm if player detected
		_rayCast.TargetPosition = new Vector2(LaserLength, 0);
		_rayCast.ForceRaycastUpdate();
		UpdateLaserBeam();
			
		if(_rayCast.IsColliding())
		{
			var hit =_rayCast.GetCollider();
			if(hit != null && _player != null && hit == _player)
			{
				TriggerAlarm();
			}	
		}
	}
		
	private void UpdateLaserBeam()
	{
		// TODO: Update Line2D points based on raycast
		// Show full length if no collision
		// Show up to collision point if hitting something
		if(!_rayCast.IsColliding())
		{
			_laserBeam.SetPointPosition(0, Vector2.Zero);
			_laserBeam.SetPointPosition(1, new Vector2(LaserLength, 0));
		}
			
		Vector2 localHit = ToLocal(_rayCast.GetCollisionPoint());
		_laserBeam.SetPointPosition(0, Vector2.Zero);
		_laserBeam.SetPointPosition(1, localHit);
	}
		
	private void TriggerAlarm()
	{
		// TODO: Change laser color
		// TODO: Emit signal or call alarm function
		// TODO: Add visual feedback (flashing, particles, etc.)
		// TODO: Add audio feedback (optional)
		if(_isAlarmActive)
		{
			return;
		}
		_isAlarmActive = true;
		_laserBeam.DefaultColor = LaserColorAlert;
		GD.Print("ALARM! Player detected!");
	}
	private void ResetAlarm()
	{
		// TODO: Reset laser to normal color
		// TODO: Reset alarm state
		_isAlarmActive = false;
		_laserBeam.DefaultColor = LaserColorNormal;
	}
}
