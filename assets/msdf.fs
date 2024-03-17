#version 420

in vec2 texcoords;
in vec4 color;

out vec4 out_color;

uniform sampler2D msdf;


float median(float r, float g, float b) {
	return max(min(r, g), min(max(r, g), b));
}


float screenPxRange() {
	float px_range = 2;
	vec2 unit_range = vec2(px_range) / vec2(textureSize(msdf, 0));
	vec2 screen_tex_size = vec2(1.0) / fwidth(texcoords);
	return max(0.5 * dot(unit_range, screen_tex_size), 1.0);
}


void main() {
	float thickness = .15;

	vec4 msdf_sample = texture(msdf, texcoords.xy).rgba;
	float dist = median(msdf_sample.r, msdf_sample.g, msdf_sample.b) - 0.5;
	if (dist <= -0.4999) discard;

	float px_range = screenPxRange();

	float sig_dist = px_range * (dist + thickness);
	float opacity = smoothstep(0.0, 1.0, sig_dist + 0.5);
	out_color = vec4(color.rgb, opacity * color.a);

/*
	float dist_outline = -abs(dist);
	float sig_outline_dist = px_range * (dist_outline + thickness);
	float opacity_outline = smoothstep(0.0, 1.0, sig_outline_dist + 0.5);
	out_color = vec4(1,0,0, opacity_outline * color.a);
*/
}
