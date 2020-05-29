// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3413,x:32780,y:32798,varname:node_3413,prsc:2|emission-7348-OUT,alpha-6604-OUT,clip-120-OUT;n:type:ShaderForge.SFN_Color,id:5273,x:31719,y:32565,ptovrint:False,ptlb:Fire Gradient 2,ptin:_FireGradient2,varname:node_5273,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:8320,x:31944,y:32993,ptovrint:False,ptlb:Fire Texture,ptin:_FireTexture,varname:node_8320,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ae0dba2eb08a40349ac34c3497e7b650,ntxv:0,isnm:False|UVIN-2216-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7348,x:32169,y:32746,varname:node_7348,prsc:2|A-6080-OUT,B-8320-RGB;n:type:ShaderForge.SFN_Slider,id:4906,x:32126,y:32957,ptovrint:False,ptlb:Erosion Amount,ptin:_ErosionAmount,varname:node_4906,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.206038,max:1;n:type:ShaderForge.SFN_OneMinus,id:6604,x:32476,y:32944,varname:node_6604,prsc:2|IN-4906-OUT;n:type:ShaderForge.SFN_Multiply,id:4172,x:32415,y:33100,varname:node_4172,prsc:2|A-8320-R,B-2901-OUT;n:type:ShaderForge.SFN_TexCoord,id:3418,x:31863,y:33176,varname:node_3418,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Power,id:2901,x:32259,y:33263,varname:node_2901,prsc:2|VAL-3418-V,EXP-8105-OUT;n:type:ShaderForge.SFN_Slider,id:8105,x:31908,y:33352,ptovrint:False,ptlb:node_8105,ptin:_node_8105,varname:node_8105,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7692308,max:3;n:type:ShaderForge.SFN_TexCoord,id:8027,x:31497,y:32993,varname:node_8027,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:2216,x:31719,y:32993,varname:node_2216,prsc:2,spu:0,spv:-1|UVIN-8027-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9602,x:31719,y:32814,varname:node_9602,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Lerp,id:6080,x:31968,y:32690,varname:node_6080,prsc:2|A-5273-RGB,B-5673-RGB,T-9602-V;n:type:ShaderForge.SFN_Color,id:5673,x:31572,y:32727,ptovrint:False,ptlb:Fire Gradient 1,ptin:_FireGradient1,varname:_FireColor_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0.9082565,c4:1;n:type:ShaderForge.SFN_OneMinus,id:120,x:32592,y:33100,varname:node_120,prsc:2|IN-4172-OUT;proporder:5273-8320-4906-8105-5673;pass:END;sub:END;*/

Shader "Unlit/FireShader" {
    Properties {
        _FireGradient2 ("Fire Gradient 2", Color) = (1,0,0,1)
        _FireTexture ("Fire Texture", 2D) = "white" {}
        _ErosionAmount ("Erosion Amount", Range(0, 1)) = 0.206038
        _node_8105 ("node_8105", Range(0, 3)) = 0.7692308
        _FireGradient1 ("Fire Gradient 1", Color) = (1,0,0.9082565,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 100
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _FireTexture; uniform float4 _FireTexture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _FireGradient2)
                UNITY_DEFINE_INSTANCED_PROP( float, _ErosionAmount)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8105)
                UNITY_DEFINE_INSTANCED_PROP( float4, _FireGradient1)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float4 node_4380 = _Time;
                float2 node_2216 = (i.uv0+node_4380.g*float2(0,-1));
                float4 _FireTexture_var = tex2D(_FireTexture,TRANSFORM_TEX(node_2216, _FireTexture));
                float _node_8105_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_8105 );
                float node_2901 = pow(i.uv0.g,_node_8105_var);
                float node_120 = (1.0 - (_FireTexture_var.r*node_2901));
                clip(node_120 - 0.5);
////// Lighting:
////// Emissive:
                float4 _FireGradient2_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FireGradient2 );
                float4 _FireGradient1_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FireGradient1 );
                float3 emissive = (lerp(_FireGradient2_var.rgb,_FireGradient1_var.rgb,i.uv0.g)*_FireTexture_var.rgb);
                float3 finalColor = emissive;
                float _ErosionAmount_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ErosionAmount );
                fixed4 finalRGBA = fixed4(finalColor,(1.0 - _ErosionAmount_var));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _FireTexture; uniform float4 _FireTexture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8105)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float4 node_5755 = _Time;
                float2 node_2216 = (i.uv0+node_5755.g*float2(0,-1));
                float4 _FireTexture_var = tex2D(_FireTexture,TRANSFORM_TEX(node_2216, _FireTexture));
                float _node_8105_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_8105 );
                float node_2901 = pow(i.uv0.g,_node_8105_var);
                float node_120 = (1.0 - (_FireTexture_var.r*node_2901));
                clip(node_120 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
