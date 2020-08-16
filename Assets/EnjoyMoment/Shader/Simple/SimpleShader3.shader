// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//顶点着色器和片元着色器的通信

Shader "ShaderLearning/Simple/SimpleShader3"
{
    Properties{
        _Color("Color Tint",Color) =(1.0,1.0,1.0,1.0)
    }


    SubShader
    {
        pass{
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag 

            //要定义跟属性名相同类型相同的变量才可以使用属性
            fixed4 _Color;

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
                fixed3 c = v.color;
                c *= _Color.rgb;
                return fixed4(c,1.0);
            }

            ENDCG
        }
    }
}
