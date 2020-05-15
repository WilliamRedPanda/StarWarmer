// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:1,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:False,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:1,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:6,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:1,qpre:4,rntp:5,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33140,y:32979,varname:node_2865,prsc:2|emission-4676-OUT,alpha-6841-OUT;n:type:ShaderForge.SFN_TexCoord,id:4219,x:31938,y:33237,cmnt:Default coordinates,varname:node_4219,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Relay,id:8397,x:32163,y:33237,cmnt:Refract here,varname:node_8397,prsc:2|IN-4219-UVOUT;n:type:ShaderForge.SFN_Relay,id:4676,x:32797,y:33378,cmnt:Modify color here,varname:node_4676,prsc:2|IN-7060-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4430,x:31938,y:33424,ptovrint:False,ptlb:MainTex,ptin:_MainTex,cmnt:MainTex contains the color of the scene,varname:node_9933,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cc8f9dfc24e41e949bcc3dad3e2945e1,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7542,x:32322,y:33299,varname:node_1672,prsc:2,tex:cc8f9dfc24e41e949bcc3dad3e2945e1,ntxv:0,isnm:False|UVIN-8397-OUT,TEX-4430-TEX;n:type:ShaderForge.SFN_Distance,id:6530,x:32322,y:33120,varname:node_6530,prsc:2|A-9642-OUT,B-8397-OUT;n:type:ShaderForge.SFN_Vector2,id:9642,x:32133,y:33066,varname:node_9642,prsc:2,v1:0.5,v2:0.5;n:type:ShaderForge.SFN_Power,id:2329,x:32514,y:33048,varname:node_2329,prsc:2|VAL-6530-OUT,EXP-42-OUT;n:type:ShaderForge.SFN_ValueProperty,id:42,x:32322,y:33028,ptovrint:False,ptlb:Power,ptin:_Power,varname:node_42,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:4707,x:32514,y:32871,varname:node_4707,prsc:2|A-3-OUT,B-8410-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8410,x:32322,y:32931,ptovrint:False,ptlb:Scaler,ptin:_Scaler,varname:node_8410,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_Slider,id:3,x:32165,y:32817,ptovrint:False,ptlb:Slider,ptin:_Slider,varname:node_3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:5957,x:32732,y:33027,varname:node_5957,prsc:2|A-4707-OUT,B-2329-OUT,C-8601-A;n:type:ShaderForge.SFN_Clamp01,id:6841,x:32900,y:33027,varname:node_6841,prsc:2|IN-5957-OUT;n:type:ShaderForge.SFN_Color,id:8601,x:32322,y:33460,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_8601,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7060,x:32600,y:33378,varname:node_7060,prsc:2|A-7542-RGB,B-8601-RGB;proporder:4430-42-8410-3-8601;pass:END;sub:END;*/

Shader "Shader Forge/ScreenShade" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _Power ("Power", Float ) = 2
        _Scaler ("Scaler", Float ) = 10
        _Slider ("Slider", Range(0, 1)) = 0
        _Color ("Color", Color) = (1,1,1,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Overlay+1"
            "RenderType"="Overlay"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZTest Always
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Power)
                UNITY_DEFINE_INSTANCED_PROP( float, _Scaler)
                UNITY_DEFINE_INSTANCED_PROP( float, _Slider)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
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
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
////// Lighting:
////// Emissive:
                float2 node_8397 = i.uv0; // Refract here
                float4 node_1672 = tex2D(_MainTex,TRANSFORM_TEX(node_8397, _MainTex));
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float3 emissive = (node_1672.rgb*_Color_var.rgb);
                float3 finalColor = emissive;
                float _Slider_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Slider );
                float _Scaler_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Scaler );
                float _Power_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Power );
                return fixed4(finalColor,saturate(((_Slider_var*_Scaler_var)*pow(distance(float2(0.5,0.5),node_8397),_Power_var)*_Color_var.a)));
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
