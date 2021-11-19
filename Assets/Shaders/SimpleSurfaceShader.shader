Shader "Custom/SimpleSurfaceShader"
{
    Properties
    {
        // Basic color
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        // Object material

        // default white color
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    
        // surface smoothness
        _Glossiness ("Smoothness", Range(0,1)) = 0.5

        // surface metal effect
        _Metallic ("Metallic", Range(0,1)) = 0.0

        // highlight on the edge
        _RimColor ("Rim Color", Color) = (1.0, 1.0, 1.0, 0.0)

        // deepth of highlight on the edge
        _RimPower ("Rim Power", Range(0.5, 8.0)) = 2.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            // pixel position
            float2 uv_MainTex;

            // camera view direction
            float3 viewDir;
        };

        half _Glossiness;
        half _Metallic;

        fixed4 _Color;

        float4 _RimColor;

        float _RimPower;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;

            // calc edge light intensity
            half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));

            // calc edge light color
            o.Emission = _RimColor.rgb * pow(rim, _RimPower);
        }
        ENDCG
    }

    // if shader model 3.0 can not run, replace to diffuse
    FallBack "Diffuse"
}
