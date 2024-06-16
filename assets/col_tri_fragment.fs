#version 420

in vec4 color;
in vec2 texcoords;

out vec4 out_color;

uniform sampler2D tex_sampler;


void main() {
	out_color = color * texture(tex_sampler, texcoords.xy).rgba;
}
