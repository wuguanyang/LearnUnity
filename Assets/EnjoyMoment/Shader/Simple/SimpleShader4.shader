// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
//纯色
Shader "ShaderLearning/Simple/SimpleShader4"
{

    Properties{
        _Color("Color",Color)=(1.0,1.0,1.0,1.0)
    }

    SubShader
    {
        pass{
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag 

            fixed4 _Color;

            float4 vert(float4 v:POSITION):SV_POSITION{
                return UnityObjectToClipPos(v);
            }

            fixed4 frag():SV_TARGET{
                return _Color;
            }

            ENDCG
        }
    }
}
