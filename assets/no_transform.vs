#version 420

layout(location = 0) in vec3 in_position;
layout(location = 1) in vec2 in_texcoord;
layout(location = 2) in vec4 in_color;

out vec2 texcoords;
out vec4 color;

void main() {
	color = in_color;
	texcoords = in_texcoord;
	gl_Position = vec4(in_position, 1.0);
}
