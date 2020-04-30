// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4341,x:33344,y:33295,varname:node_4341,prsc:2|emission-9036-OUT;n:type:ShaderForge.SFN_Cubemap,id:6715,x:32286,y:32678,ptovrint:False,ptlb:Galaxy Cubemap,ptin:_GalaxyCubemap,varname:node_6715,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,cube:9402f648a2f05b149866a629bc8802ba,pvfc:0|DIR-9493-XYZ;n:type:ShaderForge.SFN_Multiply,id:9327,x:32494,y:32718,varname:node_9327,prsc:2|A-6715-RGB,B-5062-RGB;n:type:ShaderForge.SFN_Color,id:5062,x:32286,y:32875,ptovrint:False,ptlb:Galaxy Color,ptin:_GalaxyColor,varname:node_5062,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:10;n:type:ShaderForge.SFN_ViewVector,id:4502,x:31913,y:32652,varname:node_4502,prsc:2;n:type:ShaderForge.SFN_Transform,id:9493,x:32094,y:32652,varname:node_9493,prsc:2,tffrom:3,tfto:0|IN-4502-OUT;n:type:ShaderForge.SFN_Cubemap,id:5378,x:32287,y:33083,ptovrint:False,ptlb:Star Cubemap,ptin:_StarCubemap,varname:_node_6715_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,cube:9402f648a2f05b149866a629bc8802ba,pvfc:0|DIR-8303-XYZ;n:type:ShaderForge.SFN_Multiply,id:2812,x:32495,y:33123,varname:node_2812,prsc:2|A-5378-RGB,B-1776-RGB;n:type:ShaderForge.SFN_Color,id:1776,x:32287,y:33280,ptovrint:False,ptlb:Star Color,ptin:_StarColor,varname:_node_5062_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ViewVector,id:6350,x:31914,y:33057,varname:node_6350,prsc:2;n:type:ShaderForge.SFN_Transform,id:8303,x:32095,y:33057,varname:node_8303,prsc:2,tffrom:3,tfto:0|IN-6350-OUT;n:type:ShaderForge.SFN_Add,id:6497,x:32682,y:32964,varname:node_6497,prsc:2|A-9327-OUT,B-2812-OUT;n:type:ShaderForge.SFN_Fresnel,id:9830,x:32281,y:33476,varname:node_9830,prsc:2|EXP-4559-OUT;n:type:ShaderForge.SFN_Multiply,id:9213,x:32685,y:33302,varname:node_9213,prsc:2|A-6641-RGB,B-9830-OUT;n:type:ShaderForge.SFN_Color,id:6641,x:32495,y:33280,ptovrint:False,ptlb:Fresnel Color,ptin:_FresnelColor,varname:node_6641,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Add,id:9036,x:33195,y:33158,varname:node_9036,prsc:2|A-6497-OUT,B-2884-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4559,x:32092,y:33525,ptovrint:False,ptlb:Fresnel Power,ptin:_FresnelPower,varname:node_4559,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Time,id:301,x:32061,y:33812,varname:node_301,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:2049,x:32039,y:33672,ptovrint:False,ptlb:Noise Speed,ptin:_NoiseSpeed,varname:node_2049,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:476,x:32236,y:33756,varname:node_476,prsc:2|A-2049-OUT,B-301-TSL;n:type:ShaderForge.SFN_TexCoord,id:8292,x:32211,y:33594,varname:node_8292,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_Add,id:8246,x:32423,y:33633,varname:node_8246,prsc:2|A-8292-UVOUT,B-476-OUT;n:type:ShaderForge.SFN_Multiply,id:2884,x:33015,y:33294,varname:node_2884,prsc:2|A-9213-OUT,B-4532-OUT;n:type:ShaderForge.SFN_Tex2d,id:6522,x:32635,y:33529,ptovrint:False,ptlb:Noise Texture,ptin:_NoiseTexture,varname:node_6522,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-8246-OUT;n:type:ShaderForge.SFN_Power,id:4532,x:32860,y:33518,varname:node_4532,prsc:2|VAL-6522-RGB,EXP-295-OUT;n:type:ShaderForge.SFN_ValueProperty,id:295,x:32649,y:33746,ptovrint:False,ptlb:Noise POWER,ptin:_NoisePOWER,varname:node_295,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;proporder:6715-5062-5378-1776-6641-4559-2049-6522-295;pass:END;sub:END;*/

Shader "Unlit/GalaxyOMG" {
    Properties {
        _GalaxyCubemap ("Galaxy Cubemap", Cube) = "_Skybox" {}
        _GalaxyColor ("Galaxy Color", Color) = (0,0,0,10)
        _StarCubemap ("Star Cubemap", Cube) = "_Skybox" {}
        _StarColor ("Star Color", Color) = (1,1,1,1)
        _FresnelColor ("Fresnel Color", Color) = (1,1,1,1)
        _FresnelPower ("Fresnel Power", Float ) = 1
        _NoiseSpeed ("Noise Speed", Float ) = 0
        _NoiseTexture ("Noise Texture", 2D) = "white" {}
        _NoisePOWER ("Noise POWER", Float ) = 2
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 100
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform samplerCUBE _GalaxyCubemap;
            uniform samplerCUBE _StarCubemap;
            uniform sampler2D _NoiseTexture; uniform float4 _NoiseTexture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _GalaxyColor)
                UNITY_DEFINE_INSTANCED_PROP( float4, _StarColor)
                UNITY_DEFINE_INSTANCED_PROP( float4, _FresnelColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _FresnelPower)
                UNITY_DEFINE_INSTANCED_PROP( float, _NoiseSpeed)
                UNITY_DEFINE_INSTANCED_PROP( float, _NoisePOWER)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 _GalaxyColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _GalaxyColor );
                float4 _StarColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _StarColor );
                float4 _FresnelColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FresnelColor );
                float _FresnelPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FresnelPower );
                float _NoiseSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _NoiseSpeed );
                float4 node_301 = _Time;
                float2 node_8246 = (i.uv0+(_NoiseSpeed_var*node_301.r));
                float4 _NoiseTexture_var = tex2D(_NoiseTexture,TRANSFORM_TEX(node_8246, _NoiseTexture));
                float _NoisePOWER_var = UNITY_ACCESS_INSTANCED_PROP( Props, _NoisePOWER );
                float3 emissive = (((texCUBE(_GalaxyCubemap,mul( float4(viewDirection,0), UNITY_MATRIX_V ).xyz.rgb).rgb*_GalaxyColor_var.rgb)+(texCUBE(_StarCubemap,mul( float4(viewDirection,0), UNITY_MATRIX_V ).xyz.rgb).rgb*_StarColor_var.rgb))+((_FresnelColor_var.rgb*pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelPower_var))*pow(_NoiseTexture_var.rgb,_NoisePOWER_var)));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
