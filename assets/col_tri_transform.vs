#version 430

layout(location = 0) in vec4 in_vertex;
layout(location = 1) in vec4 in_color;
layout(location = 2) in vec2 in_texcoord;

layout(location = 0) uniform mat4 mvp_mat; 

out vec4 position;
out vec4 color;
out vec2 texcoords;


void main() {
	gl_Position = mvp_mat * in_vertex;
	color = in_color;
	texcoords = in_texcoord;
}
