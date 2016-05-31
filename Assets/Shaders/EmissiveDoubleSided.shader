Shader "Unlit/EmissiveDoubleSided"
{
	//		_Emission("Emission (Lightmapper)", Float) = 1.0

	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	_EmissionLM("Emission (Lightmapper)", Float) = 1
		_Illumi("Illumi Color", Color) = (1,1,1,1)
	}
		SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "False" "RenderType" = "Transparent" }
		LOD 100
		Cull Off
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		Lighting On

		Pass
	{
		Material{
		Emission[_Illumi]
	}

		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma multi_compile_fog

		#include "UnityCG.cginc"

		fixed4 _Illumi;

	struct Input {
		float4 color : COLOR;
	};
	struct v2f
	{
		float2 uv : TEXCOORD0;
		UNITY_FOG_COORDS(1)
			float4 vertex : SV_POSITION;
	};


		struct appdata
	{
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
	};



	sampler2D _MainTex;
	float4 _MainTex_ST;

	v2f vert(appdata v)
	{
		v2f o;
		o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv = TRANSFORM_TEX(v.uv, _MainTex);
		UNITY_TRANSFER_FOG(o,o.vertex);
		return o;
	}

	fixed4 frag(v2f i) : SV_Target
	{
		// sample the texture
		fixed4 col = tex2D(_MainTex, i.uv);
	// apply fog
	UNITY_APPLY_FOG(i.fogCoord, col);
	return col;
	}
		ENDCG
	}
	}
}
