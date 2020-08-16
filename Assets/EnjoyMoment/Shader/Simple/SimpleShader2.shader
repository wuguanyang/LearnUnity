// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//顶点着色器和片元着色器的通信

Shader "ShaderLearning/Simple/SimpleShader2"
{
    SubShader
    {
        pass{
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag 

            //顶点空间的各种数据
            struct  a2v{
                float4 vertex:POSITION;
                float3 normal:NORMAL;
                float4 texcoord:TEXCOORD;
            };
            //顶点输出到片元
            struct v2f{
                float4 pos:SV_POSITION;
                fixed3 color:COLOR0;
            };

            v2f vert(a2v v){
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.color = v.normal *0.5+fixed3(0.5,0.5,0.5);
                return o;
            }

            fixed4 frag(v2f v):SV_TARGET{
                return fixed4(v.color,1.0);
            }

            ENDCG
        }
    }
}
