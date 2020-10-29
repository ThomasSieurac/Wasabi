Shader "Tutorial/022_stencil_buffer/read" {
	Properties {
		_Color ("Tint", Color) = (0, 0, 0, 1)
		_MainTex ("Texture", 2D) = "white" {}
		_Smoothness ("Smoothness", Range(0, 1)) = 0
		_Metallic ("Metalness", Range(0, 1)) = 0
		[HDR] _Emission ("Emission", color) = (0,0,0)

		[IntRange] _StencilRef ("Stencil Reference Value", Range(0,255)) = 0
	}
	SubShader {
		Tags{ "RenderType"="Opaque" "Queue"="Geometry"}

        //stencil operation
		Stencil{
			Ref [_StencilRef]
			Comp Equal
		}

		CGPROGRAM

		#pragma surface surf NoLighting noambiant
		#pragma target 3.0

		sampler2D _MainTex;
		//fixed4 _Color;

		//half _Smoothness;
		//half _Metallic;
		//half3 _Emission;

		struct Input {
			float2 uv_MainTex;
		};

		fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten) {
			return fixed4(0, 0, 0, 0);//half4(s.Albedo, s.Alpha);
		}

		void surf (Input i, inout SurfaceOutput o) {
			o.Emission = tex2D(_MainTex, i.uv_MainTex);
			//col *= _Color;
			//o.Albedo = col.rgb;
			//o.Metallic = _Metallic;
			//o.Smoothness = _Smoothness;
			//o.Emission = _Emission;
		}
		ENDCG
	}
	FallBack "Standard"
}