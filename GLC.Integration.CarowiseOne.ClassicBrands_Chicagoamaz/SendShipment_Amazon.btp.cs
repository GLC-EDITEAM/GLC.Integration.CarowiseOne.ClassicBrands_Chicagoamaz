namespace GLC.Integration.CarowiseOne.ClassicBrands_Chicagoamaz
{
    using System;
    using System.Collections.Generic;
    using Microsoft.BizTalk.PipelineOM;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    
    
    public sealed class SendShipment_Amazon : Microsoft.BizTalk.PipelineOM.SendPipeline
    {
        
        private const string _strPipeline = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instanc"+
"e\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" MajorVersion=\"1\" MinorVersion=\"0\">  <Description /> "+
" <CategoryId>8c6b051c-0ff5-4fc2-9ae5-5016cb726282</CategoryId>  <FriendlyName>Transmit</FriendlyName"+
">  <Stages>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"1\" Name=\"Pre-Assemble\" minO"+
"ccurs=\"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4101-4cce-4536-83fa-4a5040674ad6\" />      <Co"+
"mponents>        <Component>          <Name>GLC.Intergration.CargowiseOne.CBAmazon.PipelineCompoents"+
".DebatchShipment,GLC.Integration.CarowiseOne.CBAmazon.PipelineComponent, Version=1.0.0.0, Culture=ne"+
"utral, PublicKeyToken=b4422dd80deac6e5</Name>          <ComponentName>DebatchShipment_amazon</Compon"+
"entName>          <Description>DebatchShipment_amazon</Description>          <Version>1.0</Version> "+
"         <Properties />          <CachedDisplayName>DebatchShipment_amazon</CachedDisplayName>      "+
"    <CachedIsManaged>true</CachedIsManaged>        </Component>      </Components>    </Stage>    <S"+
"tage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"2\" Name=\"Assemble\" minOccurs=\"0\" maxOccurs=\""+
"1\" execMethod=\"All\" stageId=\"9d0e4107-4cce-4536-83fa-4a5040674ad6\" />      <Components />    </Stage"+
">    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"3\" Name=\"Encode\" minOccurs=\"0\" maxOcc"+
"urs=\"-1\" execMethod=\"All\" stageId=\"9d0e4108-4cce-4536-83fa-4a5040674ad6\" />      <Components />    <"+
"/Stage>  </Stages></Document>";
        
        private const string _versionDependentGuid = "6ef85c87-831b-4803-8dee-c0c235405be9";
        
        public SendShipment_Amazon()
        {
            Microsoft.BizTalk.PipelineOM.Stage stage = this.AddStage(new System.Guid("9d0e4101-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp0 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("GLC.Intergration.CargowiseOne.CBAmazon.PipelineCompoents.DebatchShipment,GLC.Integration.CarowiseOne.CBAmazon.PipelineComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b4422dd80deac6e5");;
            if (comp0 is IPersistPropertyBag)
            {
                string comp0XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties /></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp0XmlProperties);;
                ((IPersistPropertyBag)(comp0)).Load(pb, 0);
            }
            this.AddComponent(stage, comp0);
        }
        
        public override string XmlContent
        {
            get
            {
                return _strPipeline;
            }
        }
        
        public override System.Guid VersionDependentGuid
        {
            get
            {
                return new System.Guid(_versionDependentGuid);
            }
        }
    }
}
