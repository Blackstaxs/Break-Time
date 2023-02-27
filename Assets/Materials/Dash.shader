Shader "Unlit/Dash"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        [HDR] _Color("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            fixed4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.uv = v.uv;
                o.uv = o.uv * 2 - 1;
                o.uv.x = sin(length(o.uv.xy) * 10 - _Time.y);
                float3 vert = v.vertex;
                vert.z = o.uv.x * 10;
                o.uv.x = o.uv.x * 0.5 + 0.5;
                //vert.y = o.uv.x;
                o.vertex = UnityObjectToClipPos(vert);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return fixed4(i.uv.x, 1, 0, 1);
            }
            ENDCG
        }
    }
}
