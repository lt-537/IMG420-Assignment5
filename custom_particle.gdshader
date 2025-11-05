shader_type canvas_item;

//TODO: Add uniform variables for:
// -Time based animation
// - Color gradient (hint: use multiple color uniforms)
// -Wave intensity

uniform float wave_intensity = 0.1;
uniform vec4 color_start : source_color = vec4(1.0, 0.5, 0.0, 1.0);
uniform vec4 color_end : source_color = vec4(1.0, 0.0, 0.5, 1.0);


void vertex() {
	// Called for every vertex the material is visible on.
}

void fragment() {
	// Called for every pixel the material is visible on.
	
	// TODO: Implement wave distortion using UV and TIME
	// TODO: Create color gradient based on UV.y
	// TODO: Apply final color with alpha
	// Starter hint:
	// vec2 uv = UV;
	// uv.x += sin(uv.y * 10.0 + TIME) * wave_intensity;
	vec2 uv = UV;
	uv.x += sin(uv.y * 10.0 + TIME *2.0) * wave_intensity;
	
	float g = clamp(uv.y, 0.0, 1.0);
	vec4 color = mix(color_start, color_end, g);
	COLOR = color;
}

//void light() {
//	// Called for every pixel for every light affecting the CanvasItem.
//	// Uncomment to replace the default light processing function with this one.
//}
