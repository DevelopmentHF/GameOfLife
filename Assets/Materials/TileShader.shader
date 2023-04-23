Shader "Tile Surface" {

	Properties {
		_Smoothness ("Smoothness", Range(0,1)) = 0.5
		_zShift ("z Shift", Range(0, 10)) = 10
	}
	
	SubShader {
		CGPROGRAM
		#pragma surface ConfigureSurface Standard fullforwardshadows
		#pragma target 3.0

		struct Input {
			float3 worldPos;
		};

		float _Smoothness;
		float _zShift;

		void ConfigureSurface (Input input, inout SurfaceOutputStandard surface) {
			surface.Albedo = input.worldPos * .4 + 2;
			surface.Albedo.z = _zShift;
			surface.Smoothness = _Smoothness;
		}
		ENDCG
	}
	
	FallBack "Diffuse"
}