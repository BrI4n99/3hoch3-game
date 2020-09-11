Shader "VertexColorFarmAnimals/VertexColorUnlit" {
    Properties{
        _MainTex("Texture", 2D) = "white" {}
      _Color("Main Color", Color) = (1,1,1,1)
       
    }

        Category{
            Tags { "Queue" = "Geometry" }
            Lighting Off
            BindChannels {
                Bind "Color", color
                Bind "Vertex", vertex

            }

            SubShader {
                Pass
                {
                            
                    SetTexture[_MainTex] {
                        combine primary
                    }


                     
                }
            }
        }

}



/*

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            SetTexture [_MainTex] {
            combine primary
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 normal: NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float3 worldNormal : TEXCOORD1;
                float3 worldPosition : TEXCOORD2;
                float4 originalVertex: TEXCOORD3;
                float4 vertex : SV_POSITION;
                UNITY_FOG_COORDS(1)

            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.world = UnityObjectToWorldNormal(v.normal);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.originalVertex = v.vertex;
                o.worldPosition = UnityObjectToViewPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
*/