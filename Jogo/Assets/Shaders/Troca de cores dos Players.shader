Shader "Custom/ExactColorSwap"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _OriginalColor("Original Color", Color) = (1,1,1,1)
        _TargetColor("Target Color", Color) = (1,1,1,1)
        _OriginalColor1("Original Color1", Color) = (1,1,1,1)
        _TargetColor1("Target Color1", Color) = (1,1,1,1)
        _OriginalColor2("Original Color2", Color) = (1,1,1,1)
        _TargetColor2("Target Color2", Color) = (1,1,1,1)
        _OriginalColor3("Original Color3", Color) = (1,1,1,1)
        _TargetColor3("Target Color3", Color) = (1,1,1,1)
        _OriginalColor4("Original Color4", Color) = (1,1,1,1)
        _TargetColor4("Target Color4", Color) = (1,1,1,1)
        _Tolerance("Tolerance", Range(0, 0.01)) = 0.001
    }
 
    SubShader
    {
        Tags { "RenderType" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
 
        Cull Off
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
 
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
 
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _OriginalColor;
            float4 _TargetColor;
            float4 _OriginalColor1;
            float4 _TargetColor1;
            float4 _OriginalColor2;
            float4 _TargetColor2;
            float4 _OriginalColor3;
            float4 _TargetColor3;
            float4 _OriginalColor4;
            float4 _TargetColor4;
            float _Tolerance;
 
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
 
            half4 frag(v2f i) : SV_Target
            {
                half4 col = tex2D(_MainTex, i.uv);
 
                if (col.a == 0)
                {
                    return half4(0, 0, 0, 0);
                }
 
                if (length(col - _OriginalColor) < _Tolerance)
                {
                    return half4(_TargetColor.rgb, col.a);
                }
                if (length(col - _OriginalColor1) < _Tolerance)
                {
                    return half4(_TargetColor1.rgb, col.a);
                }
                if (length(col - _OriginalColor2) < _Tolerance)
                {
                    return half4(_TargetColor2.rgb, col.a);
                }
                if (length(col - _OriginalColor3) < _Tolerance)
                {
                    return half4(_TargetColor3.rgb, col.a);
                }
                if (length(col - _OriginalColor4) < _Tolerance)
                {
                    return half4(_TargetColor4.rgb, col.a);
                }
 
                return col;
            }
 
            ENDCG
        }
 
 
    }
}