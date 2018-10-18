using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.TestTools.UUTR;

[Unique]
public class SuiteModifier_SetRenderPipeline : TestSuiteModifier
{
    public RenderPipelineAsset renderPipelineAsset;
    
    public override void Apply()
    {
        GraphicsSettings.renderPipelineAsset = renderPipelineAsset;
    }
}
