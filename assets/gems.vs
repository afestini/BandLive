#version 430

layout(location = 0) in vec3 in_vertex;
layout(location = 1) in vec3 in_normal;
layout(location = 2) in vec3 in_position;
layout(location = 3) in vec4 in_color;

layout(location = 0) uniform mat4 mv;
layout(location = 1) uniform mat4 proj;

out vec4 color;
out vec4 light_1;
out vec4 normal;

void main() {
	gl_Position = proj * mv * vec4(in_position + in_vertex, 1.0);
	normal = mv * vec4(in_normal, 0);
	light_1 = mv * normalize(vec4(1, -1, 1, 0));
	color = in_color;
}
