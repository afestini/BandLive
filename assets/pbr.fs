#version 430

in vec4 position;
in vec4 color;
in vec3 light_dir;
in vec3 normal;
in vec2 texcoord;
in mat3 tbn;

out vec4 out_color;

layout(location = 0) uniform uint config;
layout(location = 3) uniform vec4 base_color_factors;
layout(location = 4) uniform vec3 emissive_factors;
layout(location = 5) uniform vec2 metallic_factors;

layout (binding = 0) uniform sampler2D base_color_sampler;
layout (binding = 1) uniform sampler2D metallic_roughness_sampler;
layout (binding = 2) uniform sampler2D normal_sampler;
layout (binding = 3) uniform sampler2D occlusion_sampler;
layout (binding = 4) uniform sampler2D emissive_sampler;


const float PI = 3.14159265359;


float DistributionGGX(vec3 N, vec3 H, float roughness) {
	float a = roughness * roughness;
	float a_sq = a * a;
	float NH = max(dot(N, H), 0);

	float d = (NH * NH) * (a_sq - 1) + 1;
	return a_sq / max(PI * d * d, 0.00001);
}

float GeometrySchlickGGX(vec3 N, vec3 d, float k) {
	float Nd = max(dot(N, d), 0);
	float denominator = Nd * (1 - k) + k;
	return Nd / denominator;
}

float GeometrySmith(vec3 N, vec3 H, vec3 L, vec3 V, float roughness) {
	float k = ((roughness + 1) * (roughness + 1)) / 8.0;
	return GeometrySchlickGGX(N, V, k) * GeometrySchlickGGX(N, L, k);
}

vec3 Fresnel(vec3 F0, float HdotV) {
	return F0 + (1 - F0) * pow(1 - HdotV, 5);
}


mat3 cotangent_frame(vec3 N, vec3 p, vec2 uv) {
	// get edge vectors of the pixel triangle
	vec3 dp1 = dFdx(p);
	vec3 dp2 = dFdy(p);
	vec2 duv1 = dFdx(uv);
	vec2 duv2 = dFdy(uv);
	// solve the linear system
	vec3 dp2perp = cross(dp2, N);
	vec3 dp1perp = cross(N, dp1);
	vec3 T = dp2perp * duv1.x + dp1perp * duv2.x;
	vec3 B = dp2perp * duv1.y + dp1perp * duv2.y;
	// construct a scale-invariant frame
	float invmax = inversesqrt(max(dot(T,T), dot(B,B)));
	return mat3(T * invmax, B * invmax, N);
}


void main() {
	float metalness = metallic_factors.x;
	float roughness = metallic_factors.y;

	vec3 metallic_roughness = texture(metallic_roughness_sampler, texcoord).rgb;
	roughness *= metallic_roughness.g;
	metalness *= metallic_roughness.b;

	vec3 N = normal.xyz;
	if ((config & (1<<18)) != 0) {
		mat3 tbn_mat = tbn;
		if ((config & 16) == 0) {
			tbn_mat = cotangent_frame(normal.xyz, position.xyz, texcoord);
		}
		N = normalize(tbn_mat * (texture(normal_sampler, texcoord).rgb * 2.0 - 1.0));
	}

	vec4 albedo = base_color_factors * color;
	albedo *= texture(base_color_sampler, texcoord);

	vec3 ambient = vec3(.03) * albedo.rgb;

	float occlusion = texture(occlusion_sampler, texcoord).r;
	ambient *= vec3(occlusion);

	vec3 emission = emissive_factors;
	emission *= texture(emissive_sampler, texcoord).rgb;

	// PBR
	vec3 V = normalize(-position.xyz);
	vec3 L = light_dir;
	vec3 H = normalize(light_dir + V);

	float NdotV = max(dot(N, V), 0);
	float NdotL = max(dot(N, L), 0);
	float NdotH = max(dot(N, H), 0.00001);
	float HdotV = max(dot(H, V), 0.00001);

	vec3 base_reflect = mix(vec3(0.04), albedo.rgb, metalness);

	float D = DistributionGGX(N, H, roughness);
	float G = GeometrySmith(N, H, L, V, roughness);
	vec3 F = Fresnel(base_reflect, HdotV);

	vec3 specular = (D * G * F) / max(4 * NdotL * NdotV, 0.00001);
	vec3 diffuse = (vec3(1.0) - F) * (1.0 - metalness);

	vec3 Lo = (diffuse * albedo.rgb / PI + specular) * NdotL;
	Lo += emission;


	vec3 col_out = ambient + Lo + emission;
	col_out *= 2;
	//col_out /= col_out + vec3(1.0);
	col_out = pow(col_out, vec3(1.0 / 2.2));

	out_color = vec4(col_out, albedo.a);
}
