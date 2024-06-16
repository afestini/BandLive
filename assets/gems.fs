#version 430

in vec4 color;
in vec4 normal;
in vec4 light_1;
out vec4 out_color;


void main() {
	float light = dot(normal, light_1);
	out_color = vec4(light * color.rgb, color.a);
}
