// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Sprite Shaders Ultimate/URP Lit/Fading/Directional Glow Fade Lit"
{
	Properties
	{
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		_MainTex("MainTex", 2D) = "white" {}
		_MaskMap("Mask Map", 2D) = "white" {}
		_NormalMap("Normal Map", 2D) = "bump" {}
		_NormalIntensity("Normal Intensity", Range( 0 , 3)) = 1
		[KeywordEnum(UV,UV_Raw,Object,Object_Scaled,World,UI_Element,Screen)] _ShaderSpace("Shader Space", Float) = 0
		_PixelsPerUnit("Pixels Per Unit", Float) = 100
		_ScreenWidthUnits("Screen Width Units", Float) = 10
		_RectWidth("Rect Width", Float) = 100
		_RectHeight("Rect Height", Float) = 100
		_DirectionalGlowFadeFade("Directional Glow Fade: Fade", Float) = 0
		_DirectionalGlowFadeRotation("Directional Glow Fade: Rotation", Range( 0 , 360)) = 0
		[HDR]_DirectionalGlowFadeEdgeColor("Directional Glow Fade: Edge Color", Color) = (11.98431,0.6901961,0.6901961,0)
		_DirectionalGlowFadeWidth("Directional Glow Fade: Width", Float) = 0.1
		_DirectionalGlowFadeNoiseScale("Directional Glow Fade: Noise Scale", Vector) = (0.4,0.4,0,0)
		_DirectionalGlowFadeNoiseFactor("Directional Glow Fade: Noise Factor", Float) = 0.2
		_DirectionalGlowFadeNoiseTexture("Directional Glow Fade: Noise Texture", 2D) = "white" {}
		[ASEEnd][Toggle]_DirectionalGlowFadeInvert("Directional Glow Fade: Invert", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}

	}

	SubShader
	{
		LOD 0

		

		Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Transparent" "Queue"="Transparent" "PreviewType"="Plane" }

		Cull Off
		HLSLINCLUDE
		#pragma target 2.0
		ENDHLSL

		
		Pass
		{
			Name "Sprite Lit"
			Tags { "LightMode"="Universal2D" }
			
			Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
			ZTest LEqual
			ZWrite Off
			Offset 0 , 0
			ColorMask RGBA
			

			HLSLPROGRAM
			#define ASE_SRP_VERSION 70301

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma vertex vert
			#pragma fragment frag

			#pragma multi_compile _ ETC1_EXTERNAL_ALPHA
			#pragma multi_compile _ USE_SHAPE_LIGHT_TYPE_0
			#pragma multi_compile _ USE_SHAPE_LIGHT_TYPE_1
			#pragma multi_compile _ USE_SHAPE_LIGHT_TYPE_2
			#pragma multi_compile _ USE_SHAPE_LIGHT_TYPE_3

			#define _SURFACE_TYPE_TRANSPARENT 1
			#define SHADERPASS_SPRITELIT

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Shaders/2D/Include/LightingUtility.hlsl"
			
			#if USE_SHAPE_LIGHT_TYPE_0
			SHAPE_LIGHT(0)
			#endif

			#if USE_SHAPE_LIGHT_TYPE_1
			SHAPE_LIGHT(1)
			#endif

			#if USE_SHAPE_LIGHT_TYPE_2
			SHAPE_LIGHT(2)
			#endif

			#if USE_SHAPE_LIGHT_TYPE_3
			SHAPE_LIGHT(3)
			#endif

			#include "Packages/com.unity.render-pipelines.universal/Shaders/2D/Include/CombinedShapeLightShared.hlsl"

			#define ASE_NEEDS_FRAG_POSITION
			#pragma shader_feature_local _SHADERSPACE_UV _SHADERSPACE_UV_RAW _SHADERSPACE_OBJECT _SHADERSPACE_OBJECT_SCALED _SHADERSPACE_WORLD _SHADERSPACE_UI_ELEMENT _SHADERSPACE_SCREEN


			sampler2D _MainTex;
			sampler2D _DirectionalGlowFadeNoiseTexture;
			sampler2D _MaskMap;
			sampler2D _NormalMap;
			CBUFFER_START( UnityPerMaterial )
			float4 _DirectionalGlowFadeEdgeColor;
			float4 _MainTex_TexelSize;
			float4 _MainTex_ST;
			float2 _DirectionalGlowFadeNoiseScale;
			float _DirectionalGlowFadeInvert;
			float _DirectionalGlowFadeRotation;
			float _PixelsPerUnit;
			float _RectWidth;
			float _RectHeight;
			float _ScreenWidthUnits;
			float _DirectionalGlowFadeFade;
			float _DirectionalGlowFadeNoiseFactor;
			float _DirectionalGlowFadeWidth;
			float _NormalIntensity;
			CBUFFER_END


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float4 uv0 : TEXCOORD0;
				float4 color : COLOR;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				float4 texCoord0 : TEXCOORD0;
				float4 color : TEXCOORD1;
				float4 screenPosition : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord5 : TEXCOORD5;
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			#if ETC1_EXTERNAL_ALPHA
				TEXTURE2D(_AlphaTex); SAMPLER(sampler_AlphaTex);
				float _EnableAlphaTexture;
			#endif

			float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
			{
				original -= center;
				float C = cos( angle );
				float S = sin( angle );
				float t = 1 - C;
				float m00 = t * u.x * u.x + C;
				float m01 = t * u.x * u.y - S * u.z;
				float m02 = t * u.x * u.z + S * u.y;
				float m10 = t * u.x * u.y + S * u.z;
				float m11 = t * u.y * u.y + C;
				float m12 = t * u.y * u.z - S * u.x;
				float m20 = t * u.x * u.z - S * u.y;
				float m21 = t * u.y * u.z + S * u.x;
				float m22 = t * u.z * u.z + C;
				float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
				return mul( finalMatrix, original ) + center;
			}
			

			VertexOutput vert ( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				o.ase_texcoord4.xyz = ase_worldPos;
				float4 ase_clipPos = TransformObjectToHClip((v.vertex).xyz);
				float4 screenPos = ComputeScreenPos(ase_clipPos);
				o.ase_texcoord5 = screenPos;
				
				o.ase_texcoord3 = v.vertex;
				o.ase_color = v.color;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord4.w = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = defaultVertexValue;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif
				v.normal = v.normal;
				v.tangent.xyz = v.tangent.xyz;

				VertexPositionInputs vertexInput = GetVertexPositionInputs(v.vertex.xyz);

				o.texCoord0 = v.uv0;
				o.color = v.color;
				o.clipPos = vertexInput.positionCS;
				o.screenPosition = ComputeScreenPos( o.clipPos, _ProjectionParams.x );
				return o;
			}

			half4 frag ( VertexOutput IN  ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				float2 texCoord2_g177 = IN.texCoord0.xy * float2( 1,1 ) + float2( 0,0 );
				float2 texCoord22_g177 = IN.texCoord0.xy * float2( 1,1 ) + float2( 0,0 );
				float3 ase_objectScale = float3( length( GetObjectToWorldMatrix()[ 0 ].xyz ), length( GetObjectToWorldMatrix()[ 1 ].xyz ), length( GetObjectToWorldMatrix()[ 2 ].xyz ) );
				float3 ase_worldPos = IN.ase_texcoord4.xyz;
				float2 texCoord23_g177 = IN.texCoord0.xy * float2( 1,1 ) + float2( 0,0 );
				float2 appendResult28_g177 = (float2(_RectWidth , _RectHeight));
				float4 screenPos = IN.ase_texcoord5;
				float4 ase_screenPosNorm = screenPos / screenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				#if defined(_SHADERSPACE_UV)
				float2 staticSwitch1_g177 = ( texCoord2_g177 / ( _PixelsPerUnit * (_MainTex_TexelSize).xy ) );
				#elif defined(_SHADERSPACE_UV_RAW)
				float2 staticSwitch1_g177 = texCoord22_g177;
				#elif defined(_SHADERSPACE_OBJECT)
				float2 staticSwitch1_g177 = (IN.ase_texcoord3.xyz).xy;
				#elif defined(_SHADERSPACE_OBJECT_SCALED)
				float2 staticSwitch1_g177 = ( (IN.ase_texcoord3.xyz).xy * (ase_objectScale).xy );
				#elif defined(_SHADERSPACE_WORLD)
				float2 staticSwitch1_g177 = (ase_worldPos).xy;
				#elif defined(_SHADERSPACE_UI_ELEMENT)
				float2 staticSwitch1_g177 = ( texCoord23_g177 * ( appendResult28_g177 / _PixelsPerUnit ) );
				#elif defined(_SHADERSPACE_SCREEN)
				float2 staticSwitch1_g177 = ( ( (ase_screenPosNorm).xy * (_ScreenParams).xy ) / ( _ScreenParams.x / _ScreenWidthUnits ) );
				#else
				float2 staticSwitch1_g177 = ( texCoord2_g177 / ( _PixelsPerUnit * (_MainTex_TexelSize).xy ) );
				#endif
				float2 temp_output_171_0_g175 = staticSwitch1_g177;
				float3 rotatedValue136_g175 = RotateAroundAxis( float3( 0,0,0 ), float3( temp_output_171_0_g175 ,  0.0 ), float3( 0,0,1 ), ( ( ( _DirectionalGlowFadeRotation / 360.0 ) + -0.25 ) * PI ) );
				float3 break130_g175 = rotatedValue136_g175;
				float temp_output_168_0_g175 = max( ( ( break130_g175.x + break130_g175.y + _DirectionalGlowFadeFade + ( tex2D( _DirectionalGlowFadeNoiseTexture, ( temp_output_171_0_g175 * _DirectionalGlowFadeNoiseScale ) ).r * _DirectionalGlowFadeNoiseFactor ) ) / max( _DirectionalGlowFadeWidth , 0.001 ) ) , 0.0 );
				float temp_output_161_0_g175 = step( 0.1 , (( _DirectionalGlowFadeInvert )?( ( 1.0 - temp_output_168_0_g175 ) ):( temp_output_168_0_g175 )) );
				float2 uv_MainTex = IN.texCoord0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
				float4 temp_output_1_0_g175 = tex2D( _MainTex, uv_MainTex );
				float clampResult154_g175 = clamp( temp_output_161_0_g175 , 0.0 , 1.0 );
				float4 appendResult3_g175 = (float4(( ( (_DirectionalGlowFadeEdgeColor).rgb * ( temp_output_161_0_g175 - step( 1.0 , (( _DirectionalGlowFadeInvert )?( ( 1.0 - temp_output_168_0_g175 ) ):( temp_output_168_0_g175 )) ) ) ) + (temp_output_1_0_g175).rgb ) , ( temp_output_1_0_g175.a * clampResult154_g175 )));
				
				float2 temp_output_8_0_g173 = IN.texCoord0.xy;
				
				float3 unpack14_g173 = UnpackNormalScale( tex2D( _NormalMap, temp_output_8_0_g173 ), _NormalIntensity );
				unpack14_g173.z = lerp( 1, unpack14_g173.z, saturate(_NormalIntensity) );
				
				float4 Color = ( appendResult3_g175 * IN.ase_color );
				float Mask = tex2D( _MaskMap, temp_output_8_0_g173 ).r;
				float3 Normal = unpack14_g173;

				#if ETC1_EXTERNAL_ALPHA
					float4 alpha = SAMPLE_TEXTURE2D(_AlphaTex, sampler_AlphaTex, IN.texCoord0.xy);
					Color.a = lerp ( Color.a, alpha.r, _EnableAlphaTexture);
				#endif
				
				Color *= IN.color;

				return CombinedShapeLightShared( Color, Mask, IN.screenPosition.xy / IN.screenPosition.w );
			}

			ENDHLSL
		}

		
		Pass
		{
			
			Name "Sprite Normal"
			Tags { "LightMode"="NormalsRendering" }
			
			Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
			ZTest LEqual
			ZWrite Off
			Offset 0 , 0
			ColorMask RGBA
			

			HLSLPROGRAM
			#define ASE_SRP_VERSION 70301

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma vertex vert
			#pragma fragment frag

			#define _SURFACE_TYPE_TRANSPARENT 1
			#define SHADERPASS_SPRITENORMAL

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Shaders/2D/Include/NormalsRenderingShared.hlsl"
			
			#define ASE_NEEDS_FRAG_POSITION
			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _SHADERSPACE_UV _SHADERSPACE_UV_RAW _SHADERSPACE_OBJECT _SHADERSPACE_OBJECT_SCALED _SHADERSPACE_WORLD _SHADERSPACE_UI_ELEMENT _SHADERSPACE_SCREEN


			sampler2D _MainTex;
			sampler2D _DirectionalGlowFadeNoiseTexture;
			sampler2D _NormalMap;
			CBUFFER_START( UnityPerMaterial )
			float4 _DirectionalGlowFadeEdgeColor;
			float4 _MainTex_TexelSize;
			float4 _MainTex_ST;
			float2 _DirectionalGlowFadeNoiseScale;
			float _DirectionalGlowFadeInvert;
			float _DirectionalGlowFadeRotation;
			float _PixelsPerUnit;
			float _RectWidth;
			float _RectHeight;
			float _ScreenWidthUnits;
			float _DirectionalGlowFadeFade;
			float _DirectionalGlowFadeNoiseFactor;
			float _DirectionalGlowFadeWidth;
			float _NormalIntensity;
			CBUFFER_END


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float4 uv0 : TEXCOORD0;
				float4 color : COLOR;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				float4 texCoord0 : TEXCOORD0;
				float4 color : TEXCOORD1;
				float3 normalWS : TEXCOORD2;
				float4 tangentWS : TEXCOORD3;
				float3 bitangentWS : TEXCOORD4;
				float4 ase_texcoord5 : TEXCOORD5;
				float4 ase_texcoord6 : TEXCOORD6;
				float4 ase_texcoord7 : TEXCOORD7;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
			{
				original -= center;
				float C = cos( angle );
				float S = sin( angle );
				float t = 1 - C;
				float m00 = t * u.x * u.x + C;
				float m01 = t * u.x * u.y - S * u.z;
				float m02 = t * u.x * u.z + S * u.y;
				float m10 = t * u.x * u.y + S * u.z;
				float m11 = t * u.y * u.y + C;
				float m12 = t * u.y * u.z - S * u.x;
				float m20 = t * u.x * u.z - S * u.y;
				float m21 = t * u.y * u.z + S * u.x;
				float m22 = t * u.z * u.z + C;
				float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
				return mul( finalMatrix, original ) + center;
			}
			

			VertexOutput vert ( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				o.ase_texcoord6.xyz = ase_worldPos;
				float4 ase_clipPos = TransformObjectToHClip((v.vertex).xyz);
				float4 screenPos = ComputeScreenPos(ase_clipPos);
				o.ase_texcoord7 = screenPos;
				
				o.ase_texcoord5 = v.vertex;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord6.w = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = defaultVertexValue;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif
				v.normal = v.normal;
				v.tangent.xyz = v.tangent.xyz;

				VertexPositionInputs vertexInput = GetVertexPositionInputs(v.vertex.xyz);

				o.texCoord0 = v.uv0;
				o.color = v.color;
				o.clipPos = vertexInput.positionCS;

				float3 normalWS = TransformObjectToWorldNormal( v.normal );
				o.normalWS = NormalizeNormalPerVertex( normalWS );
				float4 tangentWS = float4( TransformObjectToWorldDir( v.tangent.xyz ), v.tangent.w );
				o.tangentWS = normalize( tangentWS );
				o.bitangentWS = cross( normalWS, tangentWS.xyz ) * tangentWS.w;
				return o;
			}

			half4 frag ( VertexOutput IN  ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				float2 texCoord2_g177 = IN.texCoord0.xy * float2( 1,1 ) + float2( 0,0 );
				float2 texCoord22_g177 = IN.texCoord0.xy * float2( 1,1 ) + float2( 0,0 );
				float3 ase_objectScale = float3( length( GetObjectToWorldMatrix()[ 0 ].xyz ), length( GetObjectToWorldMatrix()[ 1 ].xyz ), length( GetObjectToWorldMatrix()[ 2 ].xyz ) );
				float3 ase_worldPos = IN.ase_texcoord6.xyz;
				float2 texCoord23_g177 = IN.texCoord0.xy * float2( 1,1 ) + float2( 0,0 );
				float2 appendResult28_g177 = (float2(_RectWidth , _RectHeight));
				float4 screenPos = IN.ase_texcoord7;
				float4 ase_screenPosNorm = screenPos / screenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				#if defined(_SHADERSPACE_UV)
				float2 staticSwitch1_g177 = ( texCoord2_g177 / ( _PixelsPerUnit * (_MainTex_TexelSize).xy ) );
				#elif defined(_SHADERSPACE_UV_RAW)
				float2 staticSwitch1_g177 = texCoord22_g177;
				#elif defined(_SHADERSPACE_OBJECT)
				float2 staticSwitch1_g177 = (IN.ase_texcoord5.xyz).xy;
				#elif defined(_SHADERSPACE_OBJECT_SCALED)
				float2 staticSwitch1_g177 = ( (IN.ase_texcoord5.xyz).xy * (ase_objectScale).xy );
				#elif defined(_SHADERSPACE_WORLD)
				float2 staticSwitch1_g177 = (ase_worldPos).xy;
				#elif defined(_SHADERSPACE_UI_ELEMENT)
				float2 staticSwitch1_g177 = ( texCoord23_g177 * ( appendResult28_g177 / _PixelsPerUnit ) );
				#elif defined(_SHADERSPACE_SCREEN)
				float2 staticSwitch1_g177 = ( ( (ase_screenPosNorm).xy * (_ScreenParams).xy ) / ( _ScreenParams.x / _ScreenWidthUnits ) );
				#else
				float2 staticSwitch1_g177 = ( texCoord2_g177 / ( _PixelsPerUnit * (_MainTex_TexelSize).xy ) );
				#endif
				float2 temp_output_171_0_g175 = staticSwitch1_g177;
				float3 rotatedValue136_g175 = RotateAroundAxis( float3( 0,0,0 ), float3( temp_output_171_0_g175 ,  0.0 ), float3( 0,0,1 ), ( ( ( _DirectionalGlowFadeRotation / 360.0 ) + -0.25 ) * PI ) );
				float3 break130_g175 = rotatedValue136_g175;
				float temp_output_168_0_g175 = max( ( ( break130_g175.x + break130_g175.y + _DirectionalGlowFadeFade + ( tex2D( _DirectionalGlowFadeNoiseTexture, ( temp_output_171_0_g175 * _DirectionalGlowFadeNoiseScale ) ).r * _DirectionalGlowFadeNoiseFactor ) ) / max( _DirectionalGlowFadeWidth , 0.001 ) ) , 0.0 );
				float temp_output_161_0_g175 = step( 0.1 , (( _DirectionalGlowFadeInvert )?( ( 1.0 - temp_output_168_0_g175 ) ):( temp_output_168_0_g175 )) );
				float2 uv_MainTex = IN.texCoord0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
				float4 temp_output_1_0_g175 = tex2D( _MainTex, uv_MainTex );
				float clampResult154_g175 = clamp( temp_output_161_0_g175 , 0.0 , 1.0 );
				float4 appendResult3_g175 = (float4(( ( (_DirectionalGlowFadeEdgeColor).rgb * ( temp_output_161_0_g175 - step( 1.0 , (( _DirectionalGlowFadeInvert )?( ( 1.0 - temp_output_168_0_g175 ) ):( temp_output_168_0_g175 )) ) ) ) + (temp_output_1_0_g175).rgb ) , ( temp_output_1_0_g175.a * clampResult154_g175 )));
				
				float2 temp_output_8_0_g173 = IN.texCoord0.xy;
				float3 unpack14_g173 = UnpackNormalScale( tex2D( _NormalMap, temp_output_8_0_g173 ), _NormalIntensity );
				unpack14_g173.z = lerp( 1, unpack14_g173.z, saturate(_NormalIntensity) );
				
				float4 Color = ( appendResult3_g175 * IN.color );
				float3 Normal = unpack14_g173;
				
				Color *= IN.color;

				return NormalsRenderingShared( Color, Normal, IN.tangentWS.xyz, IN.bitangentWS, IN.normalWS);
			}

			ENDHLSL
		}

		
		Pass
		{
			
			Name "Sprite Forward"
			Tags { "LightMode"="UniversalForward" }

			Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
			ZTest LEqual
			ZWrite Off
			Offset 0 , 0
			ColorMask RGBA
			

			HLSLPROGRAM
			#define ASE_SRP_VERSION 70301

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma vertex vert
			#pragma fragment frag

			#pragma multi_compile _ ETC1_EXTERNAL_ALPHA

			#define _SURFACE_TYPE_TRANSPARENT 1
			#define SHADERPASS_SPRITEFORWARD

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

			#define ASE_NEEDS_FRAG_POSITION
			#define ASE_NEEDS_FRAG_COLOR
			#pragma shader_feature_local _SHADERSPACE_UV _SHADERSPACE_UV_RAW _SHADERSPACE_OBJECT _SHADERSPACE_OBJECT_SCALED _SHADERSPACE_WORLD _SHADERSPACE_UI_ELEMENT _SHADERSPACE_SCREEN


			sampler2D _MainTex;
			sampler2D _DirectionalGlowFadeNoiseTexture;
			CBUFFER_START( UnityPerMaterial )
			float4 _DirectionalGlowFadeEdgeColor;
			float4 _MainTex_TexelSize;
			float4 _MainTex_ST;
			float2 _DirectionalGlowFadeNoiseScale;
			float _DirectionalGlowFadeInvert;
			float _DirectionalGlowFadeRotation;
			float _PixelsPerUnit;
			float _RectWidth;
			float _RectHeight;
			float _ScreenWidthUnits;
			float _DirectionalGlowFadeFade;
			float _DirectionalGlowFadeNoiseFactor;
			float _DirectionalGlowFadeWidth;
			float _NormalIntensity;
			CBUFFER_END


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float4 uv0 : TEXCOORD0;
				float4 color : COLOR;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				float4 texCoord0 : TEXCOORD0;
				float4 color : TEXCOORD1;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			#if ETC1_EXTERNAL_ALPHA
				TEXTURE2D( _AlphaTex ); SAMPLER( sampler_AlphaTex );
				float _EnableAlphaTexture;
			#endif

			float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
			{
				original -= center;
				float C = cos( angle );
				float S = sin( angle );
				float t = 1 - C;
				float m00 = t * u.x * u.x + C;
				float m01 = t * u.x * u.y - S * u.z;
				float m02 = t * u.x * u.z + S * u.y;
				float m10 = t * u.x * u.y + S * u.z;
				float m11 = t * u.y * u.y + C;
				float m12 = t * u.y * u.z - S * u.x;
				float m20 = t * u.x * u.z - S * u.y;
				float m21 = t * u.y * u.z + S * u.x;
				float m22 = t * u.z * u.z + C;
				float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
				return mul( finalMatrix, original ) + center;
			}
			

			VertexOutput vert( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );

				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				o.ase_texcoord3.xyz = ase_worldPos;
				float4 ase_clipPos = TransformObjectToHClip((v.vertex).xyz);
				float4 screenPos = ComputeScreenPos(ase_clipPos);
				o.ase_texcoord4 = screenPos;
				
				o.ase_texcoord2 = v.vertex;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord3.w = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3( 0, 0, 0 );
				#endif
				float3 vertexValue = defaultVertexValue;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif
				v.normal = v.normal;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( v.vertex.xyz );

				o.texCoord0 = v.uv0;
				o.color = v.color;
				o.clipPos = vertexInput.positionCS;

				return o;
			}

			half4 frag( VertexOutput IN  ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				float2 texCoord2_g177 = IN.texCoord0.xy * float2( 1,1 ) + float2( 0,0 );
				float2 texCoord22_g177 = IN.texCoord0.xy * float2( 1,1 ) + float2( 0,0 );
				float3 ase_objectScale = float3( length( GetObjectToWorldMatrix()[ 0 ].xyz ), length( GetObjectToWorldMatrix()[ 1 ].xyz ), length( GetObjectToWorldMatrix()[ 2 ].xyz ) );
				float3 ase_worldPos = IN.ase_texcoord3.xyz;
				float2 texCoord23_g177 = IN.texCoord0.xy * float2( 1,1 ) + float2( 0,0 );
				float2 appendResult28_g177 = (float2(_RectWidth , _RectHeight));
				float4 screenPos = IN.ase_texcoord4;
				float4 ase_screenPosNorm = screenPos / screenPos.w;
				ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
				#if defined(_SHADERSPACE_UV)
				float2 staticSwitch1_g177 = ( texCoord2_g177 / ( _PixelsPerUnit * (_MainTex_TexelSize).xy ) );
				#elif defined(_SHADERSPACE_UV_RAW)
				float2 staticSwitch1_g177 = texCoord22_g177;
				#elif defined(_SHADERSPACE_OBJECT)
				float2 staticSwitch1_g177 = (IN.ase_texcoord2.xyz).xy;
				#elif defined(_SHADERSPACE_OBJECT_SCALED)
				float2 staticSwitch1_g177 = ( (IN.ase_texcoord2.xyz).xy * (ase_objectScale).xy );
				#elif defined(_SHADERSPACE_WORLD)
				float2 staticSwitch1_g177 = (ase_worldPos).xy;
				#elif defined(_SHADERSPACE_UI_ELEMENT)
				float2 staticSwitch1_g177 = ( texCoord23_g177 * ( appendResult28_g177 / _PixelsPerUnit ) );
				#elif defined(_SHADERSPACE_SCREEN)
				float2 staticSwitch1_g177 = ( ( (ase_screenPosNorm).xy * (_ScreenParams).xy ) / ( _ScreenParams.x / _ScreenWidthUnits ) );
				#else
				float2 staticSwitch1_g177 = ( texCoord2_g177 / ( _PixelsPerUnit * (_MainTex_TexelSize).xy ) );
				#endif
				float2 temp_output_171_0_g175 = staticSwitch1_g177;
				float3 rotatedValue136_g175 = RotateAroundAxis( float3( 0,0,0 ), float3( temp_output_171_0_g175 ,  0.0 ), float3( 0,0,1 ), ( ( ( _DirectionalGlowFadeRotation / 360.0 ) + -0.25 ) * PI ) );
				float3 break130_g175 = rotatedValue136_g175;
				float temp_output_168_0_g175 = max( ( ( break130_g175.x + break130_g175.y + _DirectionalGlowFadeFade + ( tex2D( _DirectionalGlowFadeNoiseTexture, ( temp_output_171_0_g175 * _DirectionalGlowFadeNoiseScale ) ).r * _DirectionalGlowFadeNoiseFactor ) ) / max( _DirectionalGlowFadeWidth , 0.001 ) ) , 0.0 );
				float temp_output_161_0_g175 = step( 0.1 , (( _DirectionalGlowFadeInvert )?( ( 1.0 - temp_output_168_0_g175 ) ):( temp_output_168_0_g175 )) );
				float2 uv_MainTex = IN.texCoord0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
				float4 temp_output_1_0_g175 = tex2D( _MainTex, uv_MainTex );
				float clampResult154_g175 = clamp( temp_output_161_0_g175 , 0.0 , 1.0 );
				float4 appendResult3_g175 = (float4(( ( (_DirectionalGlowFadeEdgeColor).rgb * ( temp_output_161_0_g175 - step( 1.0 , (( _DirectionalGlowFadeInvert )?( ( 1.0 - temp_output_168_0_g175 ) ):( temp_output_168_0_g175 )) ) ) ) + (temp_output_1_0_g175).rgb ) , ( temp_output_1_0_g175.a * clampResult154_g175 )));
				
				float4 Color = ( appendResult3_g175 * IN.color );

				#if ETC1_EXTERNAL_ALPHA
					float4 alpha = SAMPLE_TEXTURE2D( _AlphaTex, sampler_AlphaTex, IN.texCoord0.xy );
					Color.a = lerp( Color.a, alpha.r, _EnableAlphaTexture );
				#endif

				Color *= IN.color;

				return Color;
			}

			ENDHLSL
		}
		
	}
	CustomEditor "SpriteShadersUltimate.SingleShaderGUI"
	Fallback "Hidden/InternalErrorShader"
	
}
/*ASEBEGIN
Version=18900
232;255;1374;641;1630.018;734.5364;1.59426;True;True
Node;AmplifyShaderEditor.TexturePropertyNode;69;-1156.99,-459.0573;Inherit;True;Property;_MainTex;MainTex;0;0;Create;True;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.SamplerNode;68;-750.1906,-295.8271;Inherit;True;Property;_TextureSample1;Texture Sample 0;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;83;-732.4497,-433.2213;Inherit;False;ShaderSpace;5;;177;be729ef05db9c224caec82a3516038dc;0;1;3;SAMPLER2D;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.FunctionNode;82;-301.8137,-389.9497;Inherit;False;_DirectionalGlowFade;11;;175;4409eccaf97c4e84cbeb8d08b5b4f41f;0;3;171;FLOAT2;0,0;False;170;SAMPLER2D;;False;1;COLOR;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.FunctionNode;66;23.38802,234.6282;Inherit;False;LitHandler;1;;173;851662d67a92ce04d84817ff63c501f2;0;1;8;FLOAT2;0,0;False;2;COLOR;0;FLOAT3;5
Node;AmplifyShaderEditor.FunctionNode;76;33.67749,-128.6291;Inherit;False;TintVertex;-1;;174;b0b94dd27c0f3da49a89feecae766dcc;0;1;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;16;112,96;Float;False;False;-1;2;UnityEditor.ShaderGraph.PBRMasterGUI;0;13;New Amplify Shader;199187dac283dbe4a8cb1ea611d70c58;True;Sprite Normal;0;1;Sprite Normal;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Transparent=RenderType;Queue=Transparent=Queue=0;True;0;0;False;True;2;5;False;-1;10;False;-1;3;1;False;-1;10;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;-1;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;True;2;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;1;LightMode=NormalsRendering;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;17;112,96;Float;False;False;-1;2;UnityEditor.ShaderGraph.PBRMasterGUI;0;13;New Amplify Shader;199187dac283dbe4a8cb1ea611d70c58;True;Sprite Forward;0;2;Sprite Forward;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;RenderPipeline=UniversalPipeline;RenderType=Transparent=RenderType;Queue=Transparent=Queue=0;True;0;0;False;True;2;5;False;-1;10;False;-1;3;1;False;-1;10;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;-1;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;True;2;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;1;LightMode=UniversalForward;False;0;Hidden/InternalErrorShader;0;0;Standard;0;False;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;15;295.6955,138.9342;Float;False;True;-1;2;SpriteShadersUltimate.SingleShaderGUI;0;12;Sprite Shaders Ultimate/URP Lit/Fading/Directional Glow Fade Lit;199187dac283dbe4a8cb1ea611d70c58;True;Sprite Lit;0;0;Sprite Lit;6;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;4;RenderPipeline=UniversalPipeline;RenderType=Transparent=RenderType;Queue=Transparent=Queue=0;PreviewType=Plane;True;0;0;False;True;2;5;False;-1;10;False;-1;3;1;False;-1;10;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;-1;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;True;2;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;1;LightMode=Universal2D;False;0;Hidden/InternalErrorShader;0;0;Standard;1;Vertex Position;1;0;3;True;True;True;False;;False;0
WireConnection;68;0;69;0
WireConnection;83;3;69;0
WireConnection;82;171;83;0
WireConnection;82;1;68;0
WireConnection;76;1;82;0
WireConnection;15;1;76;0
WireConnection;15;2;66;0
WireConnection;15;3;66;5
ASEEND*/
//CHKSM=92E51755CB9019938A500E99C47AC5835D73A302