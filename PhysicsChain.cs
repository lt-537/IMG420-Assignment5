using Godot;
using System.Collections.Generic;

public partial class PhysicsChain : Node2D
{
	[Export] public int ChainSegments = 5;
	[Export] public float SegmentDistance = 30f;
	[Export] public PackedScene SegmentScene;
	private List<RigidBody2D> _segments = new List<RigidBody2D>();
	private List<Joint2D> _joints = new List<Joint2D>();
	
	public override void _Ready()
	{
		CreateChain();
	}
	
	private void CreateChain()
	{
		Vector2 startPos = new Vector2(400, 100);
		
		var anchor = new StaticBody2D();
		anchor.Position = startPos;

		AddChild(anchor);
		Node2D prev = anchor;

		for (int i = 0; i < ChainSegments; i++)
		{
			var link = new RigidBody2D
			{
				Position = startPos + new Vector2(0, SegmentDistance * (i + 1)),
				Mass = 0.5f,
				GravityScale = 1.8f,
				LinearDamp = 2.5f,
				AngularDamp = 5.0f
			};


			var collision = new CollisionShape2D();
			var shape = new CapsuleShape2D();
			shape.Radius = 5;
			shape.Height = SegmentDistance * 0.9f;
			collision.Shape = shape;
			link.AddChild(collision);

			var sprite = new Sprite2D();
			sprite.Texture = GD.Load<Texture2D>("res://images/Loop.png");
			sprite.Centered = true;
			link.AddChild(sprite);
			
			link.SetCollisionLayerValue(1, false);
			link.SetCollisionLayerValue(2, true);
			link.SetCollisionMaskValue(1, true);
			link.SetCollisionMaskValue(2, false);

			AddChild(link);
			_segments.Add(link);

			var joint = new PinJoint2D();
			var mid = (prev.GlobalPosition + link.GlobalPosition) / 2f;
			joint.GlobalPosition = mid;
			joint.NodeA = prev.GetPath();
			joint.NodeB = link.GetPath();

			AddChild(joint);
			_joints.Add(joint);

			prev = link;
		}
   }
	public void ApplyForceToSegment(int segmentIndex, Vector2 force)
	{
		if (segmentIndex < 0 || segmentIndex >= _segments.Count)
			return;

		_segments[segmentIndex].ApplyImpulse(force);
	}
}
