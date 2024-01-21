#version 150 core

in vec3 pass_Color;
in vec2 pass_Texture;

out vec4 out_Color;

uniform sampler2D ourTexture;

void main(void) {
	out_Color = texture(ourTexture, pass_Texture);
}