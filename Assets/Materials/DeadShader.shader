Shader "DeadTile" {

	Properties {
	}
	
	SubShader {
		CGPROGRAM
		#pragma surface ConfigureSurface Standard fullforwardshadows
		#pragma target 3.0

		struct Input {
			float3 worldPos;
		};

		void ConfigureSurface (Input input, inout SurfaceOutputStandard surface) {
			surface.Albedo = (0.6, 0.6, 0.6, 0.6);
		}
		ENDCG
	}
	
	FallBack "Diffuse"
}