// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
/*
漫反射：
材质颜色    _Diffuse
光源的颜色  _LightColor0
光源的强度  _LightColor0
光源的方向  _WorldSpaceLightPos0
*/
//逐顶点漫反射光照
Shader "ShaderLearning/DiffuseVertexLevel"
{
    
    Properties{
        _Diffuse("Diffuse", Color) = (1,1,1,1)
    }
    
    SubShader{
        pass{
            //设置正确的光照模型才能得到unity内置的光照变量 
            //UNITY_LIGHTMODEL_AMBIENT
            Tags{"LightMode" = "ForwardBase"}
            
            CGPROGRAM
            #pragma vertex vert 
            #pragma fragment frag 
            //引用了内置文件 需要用到内置变量_LightColor0
            #include "Lighting.cginc"

            fixed4 _Diffuse; 

            struct a2v{
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f{
                float4 pos : SV_POSITION;
                fixed3 color :COLOR;
            };

            void  vert(in a2v v,out v2f o){
                
                o.pos = UnityObjectToClipPos(v.vertex);

                //环境光
                fixed3 ambient =UNITY_LIGHTMODEL_AMBIENT.xyz;
                //世界空间中的法线和光源方向

                //mul的参数位置的不同
                
                
                //向量（行矩阵）左乘矩阵（原来的矩阵需要转置）
                //fixed3 worldNormal =normalize(mul(v.normal,(float3x3)unity_WorldToObject));
                //fixed3 worldNormal =normalize(mul(v.normal,(float3x3)transpose(unity_ObjectToWorld)));
                
                //一般是下面这种写法
                //矩阵在左边
                //向量右乘矩阵（列矩阵） ,一般把向量放在右边。
                fixed3 worldNormal =normalize(mul((float3x3)unity_ObjectToWorld,v.normal));

                fixed3 worldLight = normalize(_WorldSpaceLightPos0.xyz);

                fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * saturate(dot(worldNormal,worldLight));
                //环境光和漫反射部分相加，得到最终的光照结果
                o.color = ambient + diffuse;
                
                
            }
            //由于所有的计算在顶点着色器中都已完成了，因此片元着色器的代码很简单，我们只需要直接把顶点颜色输出即可
            fixed4 frag(v2f i):SV_TARGET{
                return fixed4(i.color,1.0);
            }


            ENDCG


        }
    }
    
}

