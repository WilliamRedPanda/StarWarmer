// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:6026,x:32670,y:32567,varname:node_6026,prsc:2|emission-8466-OUT,alpha-5562-OUT;n:type:ShaderForge.SFN_Multiply,id:8466,x:32382,y:32624,varname:node_8466,prsc:2|A-8209-RGB,B-5159-OUT;n:type:ShaderForge.SFN_VertexColor,id:8209,x:32189,y:32530,varname:node_8209,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5159,x:32248,y:32698,varname:node_5159,prsc:2|A-6698-RGB,B-2560-RGB;n:type:ShaderForge.SFN_Multiply,id:5562,x:32382,y:32794,varname:node_5562,prsc:2|A-8209-A,B-2560-A;n:type:ShaderForge.SFN_Tex2d,id:2560,x:32015,y:32752,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_1040,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4f0afc42af2e17440911d3185218df90,ntxv:0,isnm:False|UVIN-4282-UVOUT;n:type:ShaderForge.SFN_Color,id:6698,x:32015,y:32581,ptovrint:False,ptlb:TextureColo,ptin:_TextureColo,varname:node_4719,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Panner,id:4282,x:31835,y:32759,varname:node_4282,prsc:2,spu:1,spv:0|UVIN-2149-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2149,x:31656,y:32692,varname:node_2149,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Divide,id:9281,x:31800,y:32968,varname:node_9281,prsc:2|A-9152-T,B-829-OUT;n:type:ShaderForge.SFN_Multiply,id:6889,x:31780,y:33112,varname:node_6889,prsc:2|A-9152-T,B-1498-OUT;n:type:ShaderForge.SFN_RemapRange,id:829,x:31568,y:33123,varname:node_829,prsc:2,frmn:0,frmx:100,tomn:1,tomx:100|IN-1498-OUT;n:type:ShaderForge.SFN_Time,id:9152,x:31495,y:32882,varname:node_9152,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:1498,x:31417,y:33079,ptovrint:False,ptlb:Texture Speed,ptin:_TextureSpeed,varname:node_4455,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:2560-6698;pass:END;sub:END;*/

Shader "Unlit/CraterShader" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        _TextureColo ("TextureColo", Color) = (1,1,1,1)
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
                float4 node_9093 = _Time;
                float2 node_4282 = (i.uv0+node_9093.g*float2(1,0));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_4282, _Texture));
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
