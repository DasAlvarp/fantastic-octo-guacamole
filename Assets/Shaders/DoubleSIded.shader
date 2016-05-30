Shader "Custom/DoubleSided" {
	//basically ripped from http://answers.unity3d.com/questions/272749/how-to-write-unlit-surface-shader.html with some changes.
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
	_cliprect("Clip Rectangle", Vector) = (-1,-1,-1,-1)

	}
		SubShader{
		Lighting Off
		AlphaTest Greater 0.5
		Tags{ "RenderType" = "Opaque" }
		LOD 200
		Cull Off


		CGPROGRAM
#pragma surface surf NoLighting
#include "UnityCG.cginc" 

		half4 LightingUnlit(SurfaceOutput s, half3 lightDir, half atten) {
		half4 c;
		c.rgb = 256;
		c.a = s.Alpha;
		return c;
	}

	fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
	{
		fixed4 c;
		c.rgb = 256;
		c.a = s.Alpha;
		return c;
	}

	sampler2D _MainTex;
	float4 _cliprect;


	struct Input {
		float2 uv_MainTex;
		float4 screenPos;
	};

	void surf(Input IN, inout SurfaceOutput o) {

		float2 screenPosition = IN.screenPos.xy / IN.screenPos.w;
		screenPosition.y = 1.0 - screenPosition.y;
		screenPosition.xy = screenPosition.xy * _ScreenParams.xy;

		if ((screenPosition.x >= _cliprect[0]) &&
			(screenPosition.x <= _cliprect[2]) &&
			(screenPosition.y >= _cliprect[1]) &&
			(screenPosition.y <= _cliprect[3]))
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = 0;
			o.Alpha = 0;
		}
		else {
			o.Albedo = float3(0,0,0);
			o.Alpha = 0;
		}

	}
	ENDCG



	}
		FallBack "Diffuse"
}