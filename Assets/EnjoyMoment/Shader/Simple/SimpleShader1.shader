// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'



Shader "ShaderLearning/Simple/SimpleShader1"
{
    SubShader
    {
        pass{
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag 

            //更复杂的输入
            struct  a2v{
                float4 vertex:POSITION;
                float3 normal:NORMAL;
                float4 texcoord:TEXCOORD;
            };

            float4 vert(a2v v):SV_POSITION{
                return UnityObjectToClipPos(v.vertex);
            }

            fixed4 frag():SV_TARGET{
                return fixed4(1.0,1.0,1.0,1.0);
            }

            ENDCG
        }
    }
}
