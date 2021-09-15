namespace GLC.Integration.CarowiseOne.ClassicBrands_Chicagoamaz {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CarowiseOne.ClassicBrands_Chicagoamaz.ClassicBrand_Amazon_FF", typeof(global::GLC.Integration.CarowiseOne.ClassicBrands_Chicagoamaz.ClassicBrand_Amazon_FF))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment", typeof(global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment))]
    public sealed class FlatFiletoUniversalShipment : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s0 userCSharp"" version=""1.0"" xmlns:s0=""http://GLC.Integration.CarowiseOne.ClassicBrands_Chicagoamaz.ClassicBrand_Amazon_FF""  xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"" xmlns:ns0=""http://www.cargowise.com/Schemas/Universal/2011/11"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s0:CB_Amazon"" />
  </xsl:template>
  <xsl:template match=""/s0:CB_Amazon"">
    <ns0:UniversalShipment>
      <xsl:variable name=""varv1"">GDS</xsl:variable>
      <xsl:variable name=""varv2"">US</xsl:variable>
      <!--<xsl:variable name=""varv3"">GLCGDSTRN</xsl:variable>-->
      <!--PROD Value-->
      <xsl:variable name=""varv3"">GLCGDSLAX</xsl:variable>
      <xsl:variable name=""varv4"">GLC</xsl:variable>
      <!--<xsl:variable name=""varv5"">TRN</xsl:variable>-->
      <!--PROD Value-->
      <xsl:variable name=""varv5"">GDS</xsl:variable>
      <xsl:variable name=""varv6"">WarehouseOrder</xsl:variable>
      <xsl:for-each select=""//CB_Amazon_Child2"">
        <xsl:variable name=""varOrderNum"" select=""concat(CB_Amazon_Child2_Child1/text(),'|',CB_Amazon_Child2_Child9/text(),'|',CB_Amazon_Child2_Child15/text())""/>
        <xsl:value-of select=""userCSharp:storeval($varOrderNum)""/>
      </xsl:for-each>

      <xsl:value-of select=""userCSharp:setOrderNo()""/>

      <xsl:variable name=""ordcnt"" select=""userCSharp:inccnt()""/>
      <xsl:value-of select=""userCSharp:setordcntval()""/>

      <xsl:for-each select=""//CB_Amazon_Child2"">
        <xsl:variable name=""ordloopcnt"" select=""userCSharp:getordercnt()""/>
        <xsl:if test="" $ordloopcnt != 0"">
          <xsl:variable name=""orderNo"" select=""userCSharp:getorderval($ordloopcnt)""/>
          <xsl:variable name=""Requireddate"" select=""userCSharp:getbasedindex($orderNo,1)"" />
      <ns0:Shipment>
        <ns0:DataContext>
          <ns0:Company>
            <ns0:Code>
              <xsl:value-of select=""$varv1"" />
            </ns0:Code>
            <ns0:Country>
              <ns0:Code>
                <xsl:value-of select=""$varv2"" />
              </ns0:Code>
            </ns0:Country>
          </ns0:Company>
          <ns0:DataProvider>
            <xsl:value-of select=""$varv3"" />
          </ns0:DataProvider>
          <ns0:EnterpriseID>
            <xsl:value-of select=""$varv4"" />
          </ns0:EnterpriseID>
          <ns0:ServerID>
            <xsl:value-of select=""$varv5"" />
          </ns0:ServerID>
          <ns0:DataTargetCollection>
            <ns0:DataTarget>
              <ns0:Type>
                <xsl:value-of select=""$varv6"" />
              </ns0:Type>
            </ns0:DataTarget>
          </ns0:DataTargetCollection>
        </ns0:DataContext>

      <ns0:LocalProcessing>
          <ns0:DeliveryRequiredBy>
            <xsl:value-of select=""userCSharp:DateimeConversion(CB_Amazon_Child2_Child9/text())"" />
          </ns0:DeliveryRequiredBy>
        </ns0:LocalProcessing>
        
        <!--<xsl:for-each select=""CB_Amazon_Child2"">-->
          <ns0:Order>
            <ns0:OrderNumber>
              <xsl:value-of select=""userCSharp:getbasedindex($orderNo,0)"" />
            </ns0:OrderNumber>
            <ns0:ClientReference>
              <xsl:value-of select=""userCSharp:getbasedindex($orderNo,2)"" />
            </ns0:ClientReference>
            <ns0:Type>
                <ns0:Code>ORD</ns0:Code>
                <ns0:Description>ORDER</ns0:Description>
              </ns0:Type>

              <ns0:Warehouse>
                <ns0:Code>CHN</ns0:Code>
              </ns0:Warehouse>
            <ns0:OrderLineCollection>
              <xsl:for-each select=""//CB_Amazon_Child2"">
                <xsl:variable name=""ordeNo"" select=""userCSharp:getbasedindex($orderNo,0)""/>
                <xsl:variable name=""ordeNo_1"" select=""CB_Amazon_Child2_Child1/text()""/>
                <xsl:if test=""$ordeNo = $ordeNo_1"">
                  <ns0:OrderLine>
                    <ns0:OrderedQty>
                      <xsl:value-of select=""CB_Amazon_Child2_Child4/text()"" />
                    </ns0:OrderedQty>
                    <ns0:Product>
                      <ns0:Code>
                        <xsl:value-of select=""CB_Amazon_Child2_Child5/text()"" />
                      </ns0:Code>
                      <ns0:Description>
                        <xsl:value-of select=""CB_Amazon_Child2_Child6/text()"" />
                      </ns0:Description>
                    </ns0:Product>
                    <ns0:CustomizedFieldCollection>
                      <ns0:CustomizedField>
                        <ns0:Key>CustomerPart#</ns0:Key>
                        <ns0:DataType>String</ns0:DataType>
                        <ns0:Value>
                          <xsl:value-of select=""CB_Amazon_Child2_Child25/text()"" />
                        </ns0:Value>
                      </ns0:CustomizedField>
                    </ns0:CustomizedFieldCollection>
                  </ns0:OrderLine>
                </xsl:if>
              </xsl:for-each>
            </ns0:OrderLineCollection>
          </ns0:Order>

          <xsl:for-each select=""//CB_Amazon_Child2"">
            <xsl:variable name=""ordeNo"" select=""userCSharp:getbasedindex($orderNo,0)""/>
            <xsl:variable name=""ordeNo_1"" select=""CB_Amazon_Child2_Child1/text()""/>

            <xsl:if test=""$ordeNo = $ordeNo_1"">
              <xsl:value-of select=""userCSharp:setorgaddcnt()""/>
              <xsl:variable name=""vargetorgadd"" select=""userCSharp:getorgaddcnt()""/>
              <xsl:if test=""$vargetorgadd='1'"">
          <ns0:OrganizationAddressCollection>
          
            <ns0:OrganizationAddress>
              <ns0:AddressType>ConsigneeDocumentaryAddress</ns0:AddressType>
              <ns0:Address1>
                <xsl:value-of select=""CB_Amazon_Child2_Child18/text()"" />
              </ns0:Address1>
              <ns0:Address2>
                <xsl:value-of select=""CB_Amazon_Child2_Child19/text()"" />
              </ns0:Address2>
              <ns0:City>
                <xsl:value-of select=""CB_Amazon_Child2_Child20/text()"" />
              </ns0:City>
              <ns0:CompanyName>
                <xsl:value-of select=""CB_Amazon_Child2_Child17/text()"" />
              </ns0:CompanyName>
              <ns0:Country>
                <ns0:Code>US
                  <!--<xsl:value-of select=""CB_Amazon_Child2_Child23/text()"" />-->
                </ns0:Code>
                <ns0:Name>
                  <xsl:value-of select=""CB_Amazon_Child2_Child23/text()"" />
                </ns0:Name>
              </ns0:Country>
              <ns0:Postcode>
                <xsl:value-of select=""CB_Amazon_Child2_Child22/text()"" />
              </ns0:Postcode>
              <ns0:State>
                <xsl:value-of select=""CB_Amazon_Child2_Child21/text()"" />
              </ns0:State>
            </ns0:OrganizationAddress>
            <ns0:OrganizationAddress>
              <ns0:AddressType>ConsignorDocumentaryAddress</ns0:AddressType>
              <ns0:OrganizationCode>CLABRAUS</ns0:OrganizationCode>
            </ns0:OrganizationAddress>
          
        </ns0:OrganizationAddressCollection>

        <CustomizedFieldCollection>
          <CustomizedField>
            <DataType>String</DataType>
            <Key>CancelDate</Key>
            <Value>
              <xsl:value-of select=""userCSharp:DateimeConversion(CB_Amazon_Child2_Child11/text())"" />
            </Value>
          </CustomizedField>
          <CustomizedField>
            <DataType>String</DataType>
            <Key>Notes</Key>
            <Value>
              <xsl:value-of select=""CB_Amazon_Child2_Child24/text()"" />
            </Value>
          </CustomizedField>
          </CustomizedFieldCollection>
              </xsl:if>
            </xsl:if>
          </xsl:for-each>
        <!--</xsl:for-each>-->
      </ns0:Shipment>
        </xsl:if>
        <xsl:value-of select=""userCSharp:setficnt()""/>
      </xsl:for-each>
    </ns0:UniversalShipment>
  </xsl:template>

  <msxsl:script language=""C#"" implements-prefix=""userCSharp"">
    <![CDATA[     
 
 public int setorgcnt=0;
 public string strOrderNo="""";
 public string[] strtest;
 public int countord=0;
 public int setcnt=0;
 public string strdisnictval="""";
 
 public void setorgaddcnt()
 {
   setorgcnt=setorgcnt+1;
 }
 
 public string getorgaddcnt()
 {
  return setorgcnt.ToString();
 }
 public string DateimeConversion(string strin)           
 {                       
    if(strin !="""")
    {
    DateTime strdatetime = new DateTime();            
    strdatetime = DateTime.Parse(strin);            
    strin = strdatetime.ToString(""yyyy-MM-ddTHH:mm:ss"");
    }
    return strin;             
  }
 
 public string getbasedindex(string strin,int pos)
 {
     string[] str2=strin.Split('|');
     string str3=str2[pos];
     return str3;
 }
 
 public string getorderval(int cnt)
 {
  string strin=strtest[cnt];
  return strin;
  }
  
  public string getordercnt()
  {   
   return countord.ToString();
  }
  
  public void setordcntval()
  {
    countord= setcnt;
  }
  
  public void setficnt()
  {
  setorgcnt=0;
    if(countord !=0)
    {
     countord=countord-1;
     }
  }
  
 public string inccnt()
 {
   return setcnt.ToString();
  }
 public void storeval(string strorder)
 {
  if(strdisnictval != strorder)
  {
    strOrderNo=strOrderNo+"",""+strorder;
    strdisnictval=strorder;
    setcnt=setcnt+1;
   }
  
 }
  public void setOrderNo()
   {
      strtest=strOrderNo.Split(',');
   }
  
  
   
  
  ]]>
  </msxsl:script>
</xsl:stylesheet>";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"GLC.Integration.CarowiseOne.ClassicBrands_Chicagoamaz.ClassicBrand_Amazon_FF";
        
        private const global::GLC.Integration.CarowiseOne.ClassicBrands_Chicagoamaz.ClassicBrand_Amazon_FF _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
        
        private const global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment _trgSchemaTypeReference0 = null;
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override int UseXSLTransform {
            get {
                return _useXSLTransform;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"GLC.Integration.CarowiseOne.ClassicBrands_Chicagoamaz.ClassicBrand_Amazon_FF";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
                return _TrgSchemas;
            }
        }
    }
}
