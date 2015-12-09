// Shader created with Shader Forge v1.25 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.25;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-7255-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32086,y:33091,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7988,x:32023,y:32682,ptovrint:False,ptlb:Filing,ptin:_Filing,varname:node_7988,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ae971255daa7aa34f877ab41d1bbe1d0,ntxv:0,isnm:False|UVIN-4288-OUT;n:type:ShaderForge.SFN_TexCoord,id:1444,x:31131,y:32622,varname:node_1444,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector1,id:992,x:31425,y:32667,varname:node_992,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:7007,x:31640,y:32588,varname:node_7007,prsc:2|A-1444-UVOUT,B-992-OUT;n:type:ShaderForge.SFN_Add,id:4288,x:31942,y:32940,varname:node_4288,prsc:2|A-7007-OUT,B-5006-OUT;n:type:ShaderForge.SFN_Multiply,id:5063,x:32309,y:32939,varname:node_5063,prsc:2|A-7988-RGB,B-7241-RGB;n:type:ShaderForge.SFN_Tex2d,id:5481,x:31657,y:33204,ptovrint:False,ptlb:Particles,ptin:_Particles,varname:node_5481,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3a5a96df060a5cf4a9cc0c59e13486b7,ntxv:0,isnm:False|UVIN-102-UVOUT;n:type:ShaderForge.SFN_Panner,id:102,x:31480,y:33134,varname:node_102,prsc:2,spu:-0.25,spv:0|UVIN-5131-OUT;n:type:ShaderForge.SFN_Add,id:7255,x:32318,y:33245,varname:node_7255,prsc:2|A-5063-OUT,B-9361-OUT;n:type:ShaderForge.SFN_If,id:9361,x:32133,y:33258,varname:node_9361,prsc:2|A-7988-RGB,B-632-OUT,GT-9457-OUT,EQ-5481-RGB,LT-9457-OUT;n:type:ShaderForge.SFN_Vector1,id:632,x:31893,y:33189,varname:node_632,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:9457,x:31860,y:33319,varname:node_9457,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:5131,x:31219,y:33170,varname:node_5131,prsc:2|A-1444-UVOUT,B-6529-OUT;n:type:ShaderForge.SFN_Vector1,id:6529,x:31050,y:33247,varname:node_6529,prsc:2,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:5006,x:31675,y:32960,ptovrint:False,ptlb:FilingValue,ptin:_FilingValue,varname:node_5006,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:7241-7988-5481-5006;pass:END;sub:END;*/

Shader "Shader Forge/ResourceBarShader" {
    Properties {
        _Color ("Color", Color) = (0,1,0,1)
        _Filing ("Filing", 2D) = "white" {}
        _Particles ("Particles", 2D) = "white" {}
        _FilingValue ("FilingValue", Float ) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform sampler2D _Filing; uniform float4 _Filing_ST;
            uniform sampler2D _Particles; uniform float4 _Particles_ST;
            uniform float _FilingValue;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float2 node_4288 = ((i.uv0*0.5)+_FilingValue);
                float4 _Filing_var = tex2D(_Filing,TRANSFORM_TEX(node_4288, _Filing));
                float node_9361_if_leA = step(_Filing_var.rgb,1.0);
                float node_9361_if_leB = step(1.0,_Filing_var.rgb);
                float node_9457 = 0.0;
                float4 node_1480 = _Time + _TimeEditor;
                float2 node_102 = ((i.uv0*0.5)+node_1480.g*float2(-0.25,0));
                float4 _Particles_var = tex2D(_Particles,TRANSFORM_TEX(node_102, _Particles));
                float3 emissive = ((_Filing_var.rgb*_Color.rgb)+lerp((node_9361_if_leA*node_9457)+(node_9361_if_leB*node_9457),_Particles_var.rgb,node_9361_if_leA*node_9361_if_leB));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
