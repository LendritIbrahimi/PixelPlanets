/*Please do support www.bitshiftprogrammer.com by joining the facebook page : fb.com/BitshiftProgrammer
Legal Stuff:
This code is free to use no restrictions but attribution would be appreciated.
Any damage caused either partly or completly due to usage of this stuff is not my responsibility*/
Shader "Custom/Pixelation"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Cull Off ZWrite Off ZTest Always

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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			int _PixelDensity;
			float2 _AspectRatioMultiplier;

			fixed4 frag (v2f i) : SV_Target
			{
				float2 pixelScaling = _PixelDensity * _AspectRatioMultiplier;
				i.uv = round(i.uv * pixelScaling)/ pixelScaling;
				return tex2D(_MainTex, i.uv);
			}
			ENDCG
		}
	}
}