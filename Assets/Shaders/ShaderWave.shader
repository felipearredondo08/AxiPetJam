Shader "Custom/WaveDual"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _AmplitudeX ("Horizontal Amplitude", Float) = 0.05
        _AmplitudeY ("Vertical Amplitude", Float) = 0.05
        _WaveLength ("Wave Length", Float) = 2.0
        _Speed ("Speed", Float) = 1.0
        _OffsetScale ("Offset Scale", Float) = 1.0
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        Lighting Off
        ZWrite Off

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
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _AmplitudeX;
            float _AmplitudeY;
            float _WaveLength;
            float _Speed;
            float _OffsetScale;

            v2f vert (appdata v)
            {
                v2f o;

                // Posición del objeto en el mundo
                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;

                // Offset pseudoaleatorio por objeto
                float offset = frac(sin(dot(worldPos.xy, float2(12.9898, 78.233))) * 43758.5453) * _OffsetScale;

                // Cálculo de la onda con desfase único
                float wave = sin((v.vertex.y * _WaveLength) + (_Time.y * _Speed) + offset);

                // Aplicar desplazamiento horizontal y vertical con control individual
                v.vertex.x += wave * _AmplitudeX;
                v.vertex.y += wave * _AmplitudeY;

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) * i.color;
                return col;
            }
            ENDCG
        }
    }
}
