// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,atwp:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33378,y:32532,varname:node_1873,prsc:2|emission-1749-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32796,y:32349,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:33013,y:32534,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-3767-OUT,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32296,y:32933,ptovrint:False,ptlb:Color1,ptin:_Color1,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32788,y:32719,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33191,y:32606,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:33017,y:32830,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5376-A,C-49-OUT;n:type:ShaderForge.SFN_TexCoord,id:7846,x:32109,y:32758,varname:node_7846,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Color,id:8843,x:32296,y:32416,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:node_8843,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:5838,x:32616,y:32596,varname:node_5838,prsc:2|A-9034-OUT,B-5983-RGB;n:type:ShaderForge.SFN_SwitchProperty,id:9034,x:32296,y:32758,ptovrint:False,ptlb:Horizontal,ptin:_Horizontal,varname:node_9034,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-7846-V,B-7846-U;n:type:ShaderForge.SFN_OneMinus,id:4909,x:32296,y:32587,varname:node_4909,prsc:2|IN-9034-OUT;n:type:ShaderForge.SFN_Multiply,id:7690,x:32616,y:32426,varname:node_7690,prsc:2|A-8843-RGB,B-4909-OUT;n:type:ShaderForge.SFN_Add,id:3767,x:32796,y:32534,varname:node_3767,prsc:2|A-7690-OUT,B-5838-OUT;n:type:ShaderForge.SFN_Multiply,id:2896,x:32605,y:32990,varname:node_2896,prsc:2|A-9034-OUT,B-5983-A;n:type:ShaderForge.SFN_Multiply,id:7554,x:32605,y:32848,varname:node_7554,prsc:2|A-8843-A,B-4909-OUT;n:type:ShaderForge.SFN_Add,id:49,x:32788,y:32913,varname:node_49,prsc:2|A-7554-OUT,B-2896-OUT;proporder:4805-5983-9034-8843;pass:END;sub:END;*/

Shader "Shader Forge/GradientShader" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color1 ("Color1", Color) = (0,0,1,1)
        [MaterialToggle] _Horizontal ("Horizontal", Float ) = 0
        _Color2 ("Color2", Color) = (1,0,0,1)
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
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color1)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color2)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _Horizontal)
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
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _Color2_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color2 );
                float _Horizontal_var = lerp( i.uv0.g, i.uv0.r, UNITY_ACCESS_INSTANCED_PROP( Props, _Horizontal ) );
                float node_4909 = (1.0 - _Horizontal_var);
                float4 _Color1_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color1 );
                float node_603 = (_MainTex_var.a*i.vertexColor.a*((_Color2_var.a*node_4909)+(_Horizontal_var*_Color1_var.a))); // A
                float3 emissive = ((_MainTex_var.rgb*((_Color2_var.rgb*node_4909)+(_Horizontal_var*_Color1_var.rgb))*i.vertexColor.rgb)*node_603);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_603);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
