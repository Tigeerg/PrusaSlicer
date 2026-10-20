#version 140

uniform vec4 uniform_color;
uniform float emission_factor;
// Set to true by the thumbnail render path only (GLCanvas3D::_render_thumbnail_internal).
uniform bool studio_light;

// x = tainted, y = specular;
in vec2 intensity;
// Camera space normal, used by the thumbnail-only studio lighting.
in vec3 thumb_normal;

out vec4 out_color;

void main()
{
    if (studio_light) {
        // Studio lighting for the generated thumbnails: a key light from the upper left plus a
        // soft frontal fill, instead of the two directional lights used by the editor.
        vec3 n = normalize(thumb_normal);
        float key  = clamp(dot(n, normalize(vec3(-0.42, 0.62, 0.66))), 0.0, 1.0);
        float fill = clamp(dot(n, normalize(vec3(0.10, -0.15, 0.98))), 0.0, 1.0);
        vec3 diffuse = uniform_color.rgb * (0.28 + 0.60 * key + 0.16 * fill);
        float specular = pow(clamp(dot(n, normalize(vec3(-0.35, 0.70, 0.62))), 0.0, 1.0), 30.0);
        out_color = vec4(diffuse + vec3(0.18 * specular), uniform_color.a);
    } else
        out_color = vec4(vec3(intensity.y) + uniform_color.rgb * (intensity.x + emission_factor), uniform_color.a);
}
