Shader "RedFlashShader"
{
    Properties
    {
        _Color ("Color", COLOR) = (1,0,0,1)
        _Intensity ("Intensity", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent+1000"}
        LOD 100
        Cull Off
        ZWrite Off
        ZTest Always
        Blend SrcAlpha One
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
		    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"

            float4 _Color;
            float _Intensity;

            void vert (uint vertexID : SV_VertexID, out float4 vertex : SV_POSITION, out float2 uv : TEXCOORD0)
            {
                vertex = GetFullScreenTriangleVertexPosition(vertexID);
                uv = vertex.xy;
            }

            real4 frag (float4 vertex : SV_POSITION, float2 uv: TEXCOORD0) : SV_Target
            {
                return _Color * dot(uv, uv) * _Intensity;
            }
            ENDCG
        }
    }
}
