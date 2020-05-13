// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,atwp:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33683,y:32800,varname:node_1873,prsc:2|emission-908-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32551,y:32729,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:e93e03c4af61f9e4f90239556d5f6d75,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32812,y:32818,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32551,y:32915,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32551,y:33079,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33126,y:32886,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT,C-7422-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32812,y:32992,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A,C-5376-A;n:type:ShaderForge.SFN_Add,id:908,x:33496,y:32611,varname:node_908,prsc:2|A-9042-OUT,B-1749-OUT;n:type:ShaderForge.SFN_OneMinus,id:7422,x:33126,y:32704,varname:node_7422,prsc:2|IN-9623-OUT;n:type:ShaderForge.SFN_Slider,id:9623,x:33048,y:32579,ptovrint:False,ptlb:StunValue,ptin:_StunValue,varname:node_9623,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:9042,x:33126,y:32406,varname:node_9042,prsc:2|A-5615-OUT,B-9623-OUT;n:type:ShaderForge.SFN_Tex2d,id:9135,x:32551,y:32495,ptovrint:False,ptlb:StunTex,ptin:_StunTex,varname:node_9135,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5e4c94c72dcec3742992660bfc3d9aca,ntxv:0,isnm:False|UVIN-6702-OUT;n:type:ShaderForge.SFN_TexCoord,id:2832,x:31998,y:32341,varname:node_2832,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:6558,x:32214,y:32407,varname:node_6558,prsc:2|A-2832-U,B-1769-OUT;n:type:ShaderForge.SFN_Add,id:9706,x:32214,y:32572,varname:node_9706,prsc:2|A-2832-V,B-7679-OUT;n:type:ShaderForge.SFN_Append,id:6702,x:32385,y:32495,varname:node_6702,prsc:2|A-6558-OUT,B-9706-OUT;n:type:ShaderForge.SFN_Slider,id:1769,x:31841,y:32601,ptovrint:False,ptlb:xUV_Offset,ptin:_xUV_Offset,varname:node_1769,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:4420,x:31841,y:32723,ptovrint:False,ptlb:yUV_Offset,ptin:_yUV_Offset,varname:node_4420,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Vector1,id:7152,x:31998,y:32840,varname:node_7152,prsc:2,v1:-1;n:type:ShaderForge.SFN_Add,id:7679,x:32214,y:32766,varname:node_7679,prsc:2|A-4420-OUT,B-7152-OUT;n:type:ShaderForge.SFN_Multiply,id:5615,x:32812,y:32627,varname:node_5615,prsc:2|A-9135-RGB,B-5983-RGB;proporder:4805-5983-9623-9135-1769-4420;pass:END;sub:END;*/

Shader "Shader Forge/EnemyShader" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _StunValue ("StunValue", Range(0, 1)) = 0
        _StunTex ("StunTex", 2D) = "white" {}
        _xUV_Offset ("xUV_Offset", Range(0, 1)) = 0
        _yUV_Offset ("yUV_Offset", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        _Stencil ("Stencil ID", Float) = 0
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilComp ("Stencil Comparison", Float) = 8
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilOpFail ("Stencil Fail Operation", Float) = 0
        _StencilOpZFail ("Stencil Z-Fail Operation", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            Stencil {
                Ref [_Stencil]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilOp]
                Fail [_StencilOpFail]
                ZFail [_StencilOpZFail]
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _StunTex; uniform float4 _StunTex_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _StunValue)
                UNITY_DEFINE_INSTANCED_PROP( float, _xUV_Offset)
                UNITY_DEFINE_INSTANCED_PROP( float, _yUV_Offset)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float _xUV_Offset_var = UNITY_ACCESS_INSTANCED_PROP( Props, _xUV_Offset );
                float _yUV_Offset_var = UNITY_ACCESS_INSTANCED_PROP( Props, _yUV_Offset );
                float2 node_6702 = float2((i.uv0.r+_xUV_Offset_var),(i.uv0.g+(_yUV_Offset_var+(-1.0))));
                float4 _StunTex_var = tex2D(_StunTex,TRANSFORM_TEX(node_6702, _StunTex));
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float _StunValue_var = UNITY_ACCESS_INSTANCED_PROP( Props, _StunValue );
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_603 = (_MainTex_var.a*_Color_var.a*i.vertexColor.a); // A
                float3 emissive = (((_StunTex_var.rgb*_Color_var.rgb)*_StunValue_var)+((_MainTex_var.rgb*_Color_var.rgb*i.vertexColor.rgb)*node_603*(1.0 - _StunValue_var)));
                float3 finalColor = emissive;
                return fixed4(finalColor,node_603);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
