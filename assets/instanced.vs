#version 440

layout(location = 0) in vec3 in_vertex;
layout(location = 1) in vec3 in_normal;
layout(location = 2) in vec2 in_texcoord;
layout(location = 3) in vec4 in_color;
layout(location = 4) in vec4 in_tangent;

layout(location = 0) uniform uint config;
layout(location = 1) uniform mat4 viewproj_mat;
layout(location = 2) uniform mat4 model_mat;

layout(std140, binding = 1) uniform InstanceData {
	vec4 inst_positions[512];
	vec4 inst_colors[512];
};

out vec4 position;
out vec4 color;
out vec3 light_dir;
out vec3 normal;
out vec2 texcoord;
out mat3 tbn;


void main() {
	if ((config & 1) != 0) {
		position = model_mat * vec4(in_vertex + inst_positions[gl_InstanceID].xyz, 1.0);
		gl_Position = viewproj_mat * position;
	}
	if ((config & 2) != 0) {
		normal = normalize(model_mat * vec4(in_normal, 0)).xyz;
	}
	if ((config & 4) != 0) {
		texcoord = in_texcoord;
	}
	color = inst_colors[gl_InstanceID];
	if ((config & 8) != 0) {
		color *= in_color;
	}

	light_dir = normalize(vec3(1, .35, 1));

	if ((config & 16) != 0) {
		vec3 tangent = normalize((model_mat * vec4(in_tangent.xyz, 0)).xyz);
		tangent = normalize(tangent - dot(tangent, normal) * normal);
		vec3 bitangent = cross(normal, tangent.xyz) * in_tangent.w;
		tbn = mat3(tangent, bitangent, normal);
	}
}
