﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ErpPanorama.Presentation.ws_integrens {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ws_integrens.ws_integrensSoap")]
    public interface ws_integrensSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ws_intfac_add_clienteDacta", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ws_intfac_add_clienteDacta(string as_ruccli);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/sendBill_retper", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string sendBill_retper(string as_xmlcab, string as_xmldet, string as_xmlley, string as_xmldes, string as_xmlmsg, string as_flgprc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/consulta_estpro_retper", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string consulta_estpro_retper(string as_xmlcab);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ws_intfac_checkestpro_ComEle", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ws_intfac_checkestpro_ComEle(int ai_nroact, string as_fecemi);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ws_intfac_checkfecanu_ComEle", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ws_intfac_checkfecanu_ComEle(int ai_nroact, string as_fecemi);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ws_intfac_returnestpro_ComEle", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ws_intfac_returnestpro_ComEle(string as_xmlcon);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/sendBill", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string sendBill(string as_xmlcab, string as_xmldet, string as_xmldes, string as_xmladi, string as_flgprc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ws_intfac_checkestpro_DocEle", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ws_intfac_checkestpro_DocEle(string as_numruc, int ai_nroact, string as_fecemi);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ws_intfac_returnestpro_DocEle", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ws_intfac_returnestpro_DocEle(string as_xmlcon);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/uf_facele_cn_documentos_procesados", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string uf_facele_cn_documentos_procesados(string as_xmldoc);
        
        // CODEGEN: El parámetro 'uf_facele_cn_documento_fisicoResult' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/uf_facele_cn_documento_fisico", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ErpPanorama.Presentation.ws_integrens.uf_facele_cn_documento_fisicoResponse uf_facele_cn_documento_fisico(ErpPanorama.Presentation.ws_integrens.uf_facele_cn_documento_fisicoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/uf_facele_upd_datosvendedor", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string uf_facele_upd_datosvendedor(string as_xmldat, string as_param1, string as_param2, string as_param3);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ws_reppro_docele", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ws_reppro_docele(string as_numruc, string as_altido, string as_sersun, string as_numsun, string as_flgprc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ws_reppro_comele", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ws_reppro_comele(string as_numruc, string as_altido, string as_sersun, string as_numsun, string as_flgprc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ws_get_licenc", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ws_get_licenc();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ws_gen_licencia", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ws_gen_licencia(string as_regist);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/uf_GetMacAddress", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string uf_GetMacAddress();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/uf_get_maeemifac_syscncele", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string uf_get_maeemifac_syscncele(string as_nudoid, string as_estreg);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="uf_facele_cn_documento_fisico", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class uf_facele_cn_documento_fisicoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string as_numruc;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string as_altido;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string as_sersun;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string as_numsun;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public string as_format;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=5)]
        public string as_tamfrm;
        
        public uf_facele_cn_documento_fisicoRequest() {
        }
        
        public uf_facele_cn_documento_fisicoRequest(string as_numruc, string as_altido, string as_sersun, string as_numsun, string as_format, string as_tamfrm) {
            this.as_numruc = as_numruc;
            this.as_altido = as_altido;
            this.as_sersun = as_sersun;
            this.as_numsun = as_numsun;
            this.as_format = as_format;
            this.as_tamfrm = as_tamfrm;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="uf_facele_cn_documento_fisicoResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class uf_facele_cn_documento_fisicoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] uf_facele_cn_documento_fisicoResult;
        
        public uf_facele_cn_documento_fisicoResponse() {
        }
        
        public uf_facele_cn_documento_fisicoResponse(byte[] uf_facele_cn_documento_fisicoResult) {
            this.uf_facele_cn_documento_fisicoResult = uf_facele_cn_documento_fisicoResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ws_integrensSoapChannel : ErpPanorama.Presentation.ws_integrens.ws_integrensSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ws_integrensSoapClient : System.ServiceModel.ClientBase<ErpPanorama.Presentation.ws_integrens.ws_integrensSoap>, ErpPanorama.Presentation.ws_integrens.ws_integrensSoap {
        
        public ws_integrensSoapClient() {
        }
        
        public ws_integrensSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ws_integrensSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ws_integrensSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ws_integrensSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ws_intfac_add_clienteDacta(string as_ruccli) {
            return base.Channel.ws_intfac_add_clienteDacta(as_ruccli);
        }
        
        public string sendBill_retper(string as_xmlcab, string as_xmldet, string as_xmlley, string as_xmldes, string as_xmlmsg, string as_flgprc) {
            return base.Channel.sendBill_retper(as_xmlcab, as_xmldet, as_xmlley, as_xmldes, as_xmlmsg, as_flgprc);
        }
        
        public string consulta_estpro_retper(string as_xmlcab) {
            return base.Channel.consulta_estpro_retper(as_xmlcab);
        }
        
        public string ws_intfac_checkestpro_ComEle(int ai_nroact, string as_fecemi) {
            return base.Channel.ws_intfac_checkestpro_ComEle(ai_nroact, as_fecemi);
        }
        
        public string ws_intfac_checkfecanu_ComEle(int ai_nroact, string as_fecemi) {
            return base.Channel.ws_intfac_checkfecanu_ComEle(ai_nroact, as_fecemi);
        }
        
        public string ws_intfac_returnestpro_ComEle(string as_xmlcon) {
            return base.Channel.ws_intfac_returnestpro_ComEle(as_xmlcon);
        }
        
        public string sendBill(string as_xmlcab, string as_xmldet, string as_xmldes, string as_xmladi, string as_flgprc) {
            return base.Channel.sendBill(as_xmlcab, as_xmldet, as_xmldes, as_xmladi, as_flgprc);
        }
        
        public string ws_intfac_checkestpro_DocEle(string as_numruc, int ai_nroact, string as_fecemi) {
            return base.Channel.ws_intfac_checkestpro_DocEle(as_numruc, ai_nroact, as_fecemi);
        }
        
        public string ws_intfac_returnestpro_DocEle(string as_xmlcon) {
            return base.Channel.ws_intfac_returnestpro_DocEle(as_xmlcon);
        }
        
        public string uf_facele_cn_documentos_procesados(string as_xmldoc) {
            return base.Channel.uf_facele_cn_documentos_procesados(as_xmldoc);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ErpPanorama.Presentation.ws_integrens.uf_facele_cn_documento_fisicoResponse ErpPanorama.Presentation.ws_integrens.ws_integrensSoap.uf_facele_cn_documento_fisico(ErpPanorama.Presentation.ws_integrens.uf_facele_cn_documento_fisicoRequest request) {
            return base.Channel.uf_facele_cn_documento_fisico(request);
        }
        
        public byte[] uf_facele_cn_documento_fisico(string as_numruc, string as_altido, string as_sersun, string as_numsun, string as_format, string as_tamfrm) {
            ErpPanorama.Presentation.ws_integrens.uf_facele_cn_documento_fisicoRequest inValue = new ErpPanorama.Presentation.ws_integrens.uf_facele_cn_documento_fisicoRequest();
            inValue.as_numruc = as_numruc;
            inValue.as_altido = as_altido;
            inValue.as_sersun = as_sersun;
            inValue.as_numsun = as_numsun;
            inValue.as_format = as_format;
            inValue.as_tamfrm = as_tamfrm;
            ErpPanorama.Presentation.ws_integrens.uf_facele_cn_documento_fisicoResponse retVal = ((ErpPanorama.Presentation.ws_integrens.ws_integrensSoap)(this)).uf_facele_cn_documento_fisico(inValue);
            return retVal.uf_facele_cn_documento_fisicoResult;
        }
        
        public string uf_facele_upd_datosvendedor(string as_xmldat, string as_param1, string as_param2, string as_param3) {
            return base.Channel.uf_facele_upd_datosvendedor(as_xmldat, as_param1, as_param2, as_param3);
        }
        
        public string ws_reppro_docele(string as_numruc, string as_altido, string as_sersun, string as_numsun, string as_flgprc) {
            return base.Channel.ws_reppro_docele(as_numruc, as_altido, as_sersun, as_numsun, as_flgprc);
        }
        
        public string ws_reppro_comele(string as_numruc, string as_altido, string as_sersun, string as_numsun, string as_flgprc) {
            return base.Channel.ws_reppro_comele(as_numruc, as_altido, as_sersun, as_numsun, as_flgprc);
        }
        
        public string ws_get_licenc() {
            return base.Channel.ws_get_licenc();
        }
        
        public string ws_gen_licencia(string as_regist) {
            return base.Channel.ws_gen_licencia(as_regist);
        }
        
        public string uf_GetMacAddress() {
            return base.Channel.uf_GetMacAddress();
        }
        
        public string uf_get_maeemifac_syscncele(string as_nudoid, string as_estreg) {
            return base.Channel.uf_get_maeemifac_syscncele(as_nudoid, as_estreg);
        }
    }
}
