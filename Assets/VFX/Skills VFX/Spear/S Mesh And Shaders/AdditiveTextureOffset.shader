// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:6449,x:33044,y:32688,varname:node_6449,prsc:2|emission-2420-OUT,alpha-6026-OUT;n:type:ShaderForge.SFN_Color,id:4719,x:32466,y:32731,ptovrint:False,ptlb:TextureColo,ptin:_TextureColo,varname:node_4719,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:6381,x:32699,y:32848,varname:node_6381,prsc:2|A-4719-RGB,B-1040-RGB;n:type:ShaderForge.SFN_VertexColor,id:4155,x:32640,y:32680,varname:node_4155,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2420,x:32833,y:32774,varname:node_2420,prsc:2|A-4155-RGB,B-6381-OUT;n:type:ShaderForge.SFN_Multiply,id:6026,x:32833,y:32944,varname:node_6026,prsc:2|A-4155-A,B-1040-A;n:type:ShaderForge.SFN_TexCoord,id:8867,x:32107,y:32842,varname:node_8867,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:8741,x:31946,y:33032,varname:node_8741,prsc:2;n:type:ShaderForge.SFN_Panner,id:2934,x:32286,y:32909,varname:node_2934,prsc:2,spu:0,spv:1|UVIN-8867-UVOUT,DIST-2475-OUT;n:type:ShaderForge.SFN_Tex2d,id:1040,x:32466,y:32902,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_1040,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4f0afc42af2e17440911d3185218df90,ntxv:0,isnm:False|UVIN-2934-UVOUT;n:type:ShaderForge.SFN_RemapRange,id:6212,x:32019,y:33273,varname:node_6212,prsc:2,frmn:0,frmx:100,tomn:1,tomx:100|IN-4455-OUT;n:type:ShaderForge.SFN_Divide,id:70,x:32251,y:33118,varname:node_70,prsc:2|A-8741-T,B-6212-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4455,x:31868,y:33229,ptovrint:False,ptlb:Texture Speed,ptin:_TextureSpeed,varname:node_4455,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:2475,x:32231,y:33262,varname:node_2475,prsc:2|A-8741-T,B-4455-OUT;proporder:4719-1040-4455;pass:END;sub:END;*/

Shader "Unlit/AdditiveTextureOffset" {
    Properties {
        _TextureColo ("TextureColo", Color) = (1,1,1,1)
        _Texture ("Texture", 2D) = "white" {}
        _TextureSpeed ("Texture Speed", Float ) = 0
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
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _TextureColo)
                UNITY_DEFINE_INSTANCED_PROP( float, _TextureSpeed)
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
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
////// Lighting:
////// Emissive:
                float4 _TextureColo_var = UNITY_ACCESS_INSTANCED_PROP( Props, _TextureColo );
                float4 node_8741 = _Time;
                float _TextureSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _TextureSpeed );
                float2 node_2934 = (i.uv0+(node_8741.g*_TextureSpeed_var)*float2(0,1));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_2934, _Texture));
                float3 emissive = (i.vertexColor.rgb*(_TextureColo_var.rgb*_Texture_var.rgb));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(i.vertexColor.a*_Texture_var.a));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
