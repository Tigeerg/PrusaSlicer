#version 100

precision highp float;

uniform vec4 uniform_color;
uniform float emission_factor;

#ifdef ENABLE_ENVIRONMENT_MAP
    uniform sampler2D environment_tex;
    uniform bool use_environment_tex;
#endif // ENABLE_ENVIRONMENT_MAP

// x = tainted, y = specular;
varying vec2 intensity;
varying vec3 env_normal;

void main()
{
#ifdef ENABLE_ENVIRONMENT_MAP
    if (use_environment_tex)
        gl_FragColor = vec4(0.45 * texture2D(environment_tex, normalize(env_normal).xy * 0.5 + 0.5).xyz + 0.8 * uniform_color.rgb * intensity.x, uniform_color.a);
    else
#endif // ENABLE_ENVIRONMENT_MAP
        gl_FragColor = vec4(vec3(intensity.y) + uniform_color.rgb * (intensity.x + emission_factor), uniform_color.a);
}
