using Godot;
using System;

public partial class ParticleController : GpuParticles2D
{
	private ShaderMaterial _shaderMaterial;
	
	public override void _Ready()
	{
		// TODO: Load and apply custom shader
		var shader = ResourceLoader.Load<Shader>("res://custom_particle.gdshader");
		_shaderMaterial = new ShaderMaterial { Shader = shader };
		Material = _shaderMaterial;
		// TODO: Configure particle properties (Amount, Lifetime, Speed, etc.)
		// TODO: Set process material properties
		// Hint: Use a new ShaderMaterial with your custom shader
	}
	public override void _Process(double delta)
	{
		// TODO: Update shader parameters over time
		// Hint: Use shader parameters to create animated effects
		
		if(_shaderMaterial != null)
		{
			float t = (float)Time.GetTicksMsec() / 1000.0f;
			float pulse = 0.25f + 0.15f * Mathf.Sin(t * 2.0f);
			
			_shaderMaterial.SetShaderParameter("wave_intensity", pulse);
			
		} 
	}
}
